using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace bai_6._2;

internal sealed class HrService
{
    private readonly HrDataAccess _dataAccess = new();

    public DataTable GetDepartments(string connectionString) => _dataAccess.GetDepartments(connectionString);

    public DataTable SearchEmployees(string connectionString, string? name, int? departmentId, string? identityNumber) =>
        _dataAccess.SearchEmployees(connectionString, name, departmentId, identityNumber);

    public DataTable GetEmployees(string connectionString) => _dataAccess.GetEmployees(connectionString);

    public int SaveEmployee(string connectionString, int? employeeId, string name, DateTime? birthDate,
        string? identityNumber, int? departmentId, decimal baseSalary, double salaryCoefficient)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 100)
            throw new ArgumentException("Họ tên không được để trống và tối đa 100 ký tự.");
        if (identityNumber?.Trim().Length > 20)
            throw new ArgumentException("CCCD tối đa 20 ký tự.");
        if (baseSalary <= 0)
            throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
        if (salaryCoefficient <= 0 || double.IsNaN(salaryCoefficient) || double.IsInfinity(salaryCoefficient))
            throw new ArgumentException("Hệ số lương phải là số lớn hơn 0.");

        return _dataAccess.SaveEmployee(connectionString, employeeId, name.Trim(), birthDate,
            identityNumber, departmentId, baseSalary, salaryCoefficient);
    }

    public void DeleteEmployee(string connectionString, int employeeId) =>
        _dataAccess.DeleteEmployee(connectionString, employeeId);

    public SqlDataAdapter CreateAttendanceAdapter(string connectionString, string month) =>
        _dataAccess.CreateAttendanceAdapter(connectionString, ValidateMonth(month));

    public bool IsMonthClosed(string connectionString, string month) =>
        _dataAccess.IsMonthClosed(connectionString, ValidateMonth(month));

    public DataTable GetPayroll(string connectionString, string month) =>
        _dataAccess.GetPayroll(connectionString, ValidateMonth(month));

    public int ClosePayrollMonth(string connectionString, string month) =>
        _dataAccess.ClosePayrollMonth(connectionString, ValidateMonth(month));

    public static string ValidateMonth(string month)
    {
        if (!DateTime.TryParseExact(month, "MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var parsed))
            throw new ArgumentException("Tháng phải có định dạng MM/yyyy.");
        return parsed.ToString("MM/yyyy", CultureInfo.InvariantCulture);
    }
}
