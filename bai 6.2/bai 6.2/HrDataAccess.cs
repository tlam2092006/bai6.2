using System.Data;
using Microsoft.Data.SqlClient;

namespace bai_6._2;

internal sealed class HrDataAccess
{
    public DataTable GetDepartments(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);
        using var adapter = new SqlDataAdapter(
            "SELECT MaPB, TenPB FROM dbo.PhongBan ORDER BY TenPB;", connection);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public DataTable SearchEmployees(string connectionString, string? name, int? departmentId, string? identityNumber)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand(
            "SELECT nv.MaNV, nv.HoTen, nv.NgaySinh, nv.CCCD, nv.MaPB, pb.TenPB, nv.LuongCoBan, nv.HeSoLuong " +
            "FROM dbo.NhanVien AS nv LEFT JOIN dbo.PhongBan AS pb ON pb.MaPB = nv.MaPB " +
            "WHERE (@HoTen = N'' OR nv.HoTen LIKE N'%' + @HoTen + N'%') " +
            "AND (@MaPB IS NULL OR nv.MaPB = @MaPB) " +
            "AND (@CCCD = '' OR nv.CCCD LIKE '%' + @CCCD + '%') ORDER BY nv.MaNV;", connection);
        command.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = name?.Trim() ?? string.Empty;
        command.Parameters.Add("@MaPB", SqlDbType.Int).Value = departmentId.HasValue ? departmentId.Value : DBNull.Value;
        command.Parameters.Add("@CCCD", SqlDbType.VarChar, 20).Value = identityNumber?.Trim() ?? string.Empty;
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public int SaveEmployee(string connectionString, int? employeeId, string name, DateTime? birthDate,
        string? identityNumber, int? departmentId, decimal baseSalary, double salaryCoefficient)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand
        {
            Connection = connection
        };

        if (employeeId.HasValue)
        {
            command.CommandText =
                "UPDATE dbo.NhanVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, CCCD = @CCCD, " +
                "MaPB = @MaPB, LuongCoBan = @LuongCoBan, HeSoLuong = @HeSoLuong WHERE MaNV = @MaNV; " +
                "IF @@ROWCOUNT = 0 THROW 51001, N'Không tìm thấy nhân viên cần cập nhật.', 1;";
            command.Parameters.Add("@MaNV", SqlDbType.Int).Value = employeeId.Value;
        }
        else
        {
            command.CommandText =
                "INSERT INTO dbo.NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) " +
                "VALUES (@HoTen, @NgaySinh, @CCCD, @MaPB, @LuongCoBan, @HeSoLuong); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);";
        }

        AddEmployeeParameters(command, name, birthDate, identityNumber, departmentId, baseSalary, salaryCoefficient);
        connection.Open();
        if (employeeId.HasValue)
        {
            command.ExecuteNonQuery();
            return employeeId.Value;
        }
        return (int)command.ExecuteScalar()!;
    }

    public void DeleteEmployee(string connectionString, int employeeId)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand("DELETE FROM dbo.NhanVien WHERE MaNV = @MaNV;", connection);
        command.Parameters.Add("@MaNV", SqlDbType.Int).Value = employeeId;
        connection.Open();
        if (command.ExecuteNonQuery() == 0)
            throw new InvalidOperationException("Không tìm thấy nhân viên cần xóa.");
    }

    public DataTable GetEmployees(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);
        using var adapter = new SqlDataAdapter(
            "SELECT MaNV, HoTen FROM dbo.NhanVien ORDER BY HoTen;", connection);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public SqlDataAdapter CreateAttendanceAdapter(string connectionString, string month)
    {
        var connection = new SqlConnection(connectionString);
        var command = new SqlCommand(
            "SELECT MaCong, MaNV, ThangNam, SoNgayCong, SoGioOT FROM dbo.BangChamCong WHERE ThangNam = @ThangNam;",
            connection);
        command.Parameters.Add("@ThangNam", SqlDbType.VarChar, 7).Value = month;
        return new SqlDataAdapter(command);
    }

    public bool IsMonthClosed(string connectionString, string month)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand(
            "SELECT CASE WHEN EXISTS (SELECT 1 FROM dbo.ThangLuongDaChot WHERE ThangNam = @ThangNam) THEN 1 ELSE 0 END;",
            connection);
        command.Parameters.Add("@ThangNam", SqlDbType.VarChar, 7).Value = month;
        connection.Open();
        return (int)command.ExecuteScalar()! == 1;
    }

    public DataTable GetPayroll(string connectionString, string month)
    {
        using var connection = new SqlConnection(connectionString);
        using var command = new SqlCommand(
            "SELECT bl.MaNV, nv.HoTen, bl.ThangNam, bl.ThucLinh " +
            "FROM dbo.BangLuong AS bl INNER JOIN dbo.NhanVien AS nv ON nv.MaNV = bl.MaNV " +
            "WHERE bl.ThangNam = @ThangNam ORDER BY nv.HoTen;", connection);
        command.Parameters.Add("@ThangNam", SqlDbType.VarChar, 7).Value = month;
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public int ClosePayrollMonth(string connectionString, string month)
    {
        const string sql = "IF EXISTS (SELECT 1 FROM dbo.ThangLuongDaChot WITH (UPDLOCK, HOLDLOCK) WHERE ThangNam = @ThangNam) " +
                           "THROW 51002, N'Tháng này đã được chốt lương.', 1; " +
                           "INSERT INTO dbo.ThangLuongDaChot (ThangNam) VALUES (@ThangNam); " +
                           "INSERT INTO dbo.BangLuong (MaNV, ThangNam, ThucLinh) " +
                           "SELECT nv.MaNV, @ThangNam, " +
                           "CAST(ROUND((nv.LuongCoBan * CAST(nv.HeSoLuong AS decimal(18,6)) / 22.0) * " +
                           "COALESCE(CAST(cc.SoNgayCong AS decimal(10,4)), 0) + " +
                           "COALESCE(CAST(cc.SoGioOT AS decimal(10,4)), 0) * 50000.0, 2) AS decimal(18,2)) " +
                           "FROM dbo.NhanVien AS nv LEFT JOIN dbo.BangChamCong AS cc " +
                           "ON cc.MaNV = nv.MaNV AND cc.ThangNam = @ThangNam; " +
                           "SELECT COUNT(*) FROM dbo.BangLuong WHERE ThangNam = @ThangNam;";

        using var connection = new SqlConnection(connectionString);
        connection.Open();
        using var transaction = connection.BeginTransaction(IsolationLevel.Serializable);
        try
        {
            using var command = new SqlCommand(sql, connection, transaction);
            command.Parameters.Add("@ThangNam", SqlDbType.VarChar, 7).Value = month;
            var insertedCount = Convert.ToInt32(command.ExecuteScalar());
            transaction.Commit();
            return insertedCount;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    private static void AddEmployeeParameters(SqlCommand command, string name, DateTime? birthDate,
        string? identityNumber, int? departmentId, decimal baseSalary, double salaryCoefficient)
    {
        command.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = name;
        command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = birthDate.HasValue ? birthDate.Value : DBNull.Value;
        command.Parameters.Add("@CCCD", SqlDbType.VarChar, 20).Value = string.IsNullOrWhiteSpace(identityNumber)
            ? DBNull.Value
            : identityNumber.Trim();
        command.Parameters.Add("@MaPB", SqlDbType.Int).Value = departmentId.HasValue ? departmentId.Value : DBNull.Value;
        command.Parameters.Add("@LuongCoBan", SqlDbType.Decimal).Value = baseSalary;
        command.Parameters["@LuongCoBan"].Precision = 18;
        command.Parameters["@LuongCoBan"].Scale = 2;
        command.Parameters.Add("@HeSoLuong", SqlDbType.Float).Value = salaryCoefficient;
    }
}
