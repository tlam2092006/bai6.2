using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace bai_6._2;

public partial class Form1 : Form
{
    private readonly HrService _hrService = new();
    private TextBox _connectionStringTextBox = null!;
    private DataGridView _employeeGrid = null!;
    private TextBox _searchNameTextBox = null!;
    private TextBox _searchIdentityTextBox = null!;
    private ComboBox _searchDepartmentComboBox = null!;
    private TextBox _employeeNameTextBox = null!;
    private TextBox _identityNumberTextBox = null!;
    private ComboBox _employeeDepartmentComboBox = null!;
    private DateTimePicker _birthDatePicker = null!;
    private NumericUpDown _baseSalaryInput = null!;
    private NumericUpDown _salaryCoefficientInput = null!;
    private DataGridView _attendanceGrid = null!;
    private DateTimePicker _attendanceMonthPicker = null!;
    private DataGridView _payrollGrid = null!;
    private DateTimePicker _payrollMonthPicker = null!;
    private Button _saveAttendanceButton = null!;
    private SqlDataAdapter? _attendanceAdapter;
    private DataTable? _attendanceTable;
    private int? _selectedEmployeeId;

    public Form1()
    {
        InitializeComponent();
        Text = "Hệ thống quản lý nhân sự và tính lương";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1000, 650);
        ClientSize = new Size(1250, 780);
        _connectionStringTextBox.Text = HrDatabaseSettings.DefaultConnectionString;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void ConnectButton_Click(object? sender, EventArgs e) => LoadEmployeeData();

    private void SearchButton_Click(object? sender, EventArgs e) => SearchEmployees();

    private void ShowAllButton_Click(object? sender, EventArgs e)
    {
        _searchNameTextBox.Clear();
        _searchIdentityTextBox.Clear();
        if (_searchDepartmentComboBox.Items.Count > 0)
            _searchDepartmentComboBox.SelectedIndex = 0;
        SearchEmployees();
    }

    private void AddEmployeeButton_Click(object? sender, EventArgs e) => SaveEmployee(isNew: true);

    private void UpdateEmployeeButton_Click(object? sender, EventArgs e) => SaveEmployee(isNew: false);

    private void DeleteEmployeeButton_Click(object? sender, EventArgs e) => DeleteEmployee();

    private void ClearEmployeeButton_Click(object? sender, EventArgs e) => ClearEmployeeForm();

    private void EmployeeGrid_SelectionChanged(object? sender, EventArgs e) => PopulateEmployeeForm();

    private void LoadAttendanceButton_Click(object? sender, EventArgs e) => LoadAttendance();

    private void SaveAttendanceButton_Click(object? sender, EventArgs e) => SaveAttendance();

    private void ViewPayrollButton_Click(object? sender, EventArgs e) => LoadPayroll();

    private void ClosePayrollButton_Click(object? sender, EventArgs e) => ClosePayrollMonth();

    private void BuildMainLayout()
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Padding = new Padding(8)
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var connectionPanel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3 };
        connectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155));
        connectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        connectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
        connectionPanel.Controls.Add(new Label
        {
            Text = "Connection string:",
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.Fill
        }, 0, 0);
        _connectionStringTextBox.Dock = DockStyle.Fill;
        connectionPanel.Controls.Add(_connectionStringTextBox, 1, 0);
        var connectButton = new Button { Text = "Kết nối / tải lại", Dock = DockStyle.Fill };
        connectButton.Click += (_, _) => LoadEmployeeData();
        connectionPanel.Controls.Add(connectButton, 2, 0);
        root.Controls.Add(connectionPanel, 0, 0);

        var tabs = new TabControl { Dock = DockStyle.Fill };
        var employeeTab = new TabPage("Nhân viên");
        employeeTab.Controls.Add(BuildEmployeePage());
        tabs.TabPages.Add(employeeTab);
        var attendanceTab = new TabPage("Chấm công");
        attendanceTab.Controls.Add(BuildAttendancePage());
        tabs.TabPages.Add(attendanceTab);
        var payrollTab = new TabPage("Tính lương / Chốt lương");
        payrollTab.Controls.Add(BuildPayrollPage());
        tabs.TabPages.Add(payrollTab);
        root.Controls.Add(tabs, 0, 1);
        Controls.Add(root);
    }

    private Control BuildAttendancePage()
    {
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(6) };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var toolbar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false };
        toolbar.Controls.Add(new Label { Text = "Tháng/năm:", AutoSize = true, Padding = new Padding(0, 8, 0, 0) });
        _attendanceMonthPicker.Format = DateTimePickerFormat.Custom;
        _attendanceMonthPicker.CustomFormat = "MM/yyyy";
        _attendanceMonthPicker.Width = 110;
        toolbar.Controls.Add(_attendanceMonthPicker);
        var loadButton = new Button { Text = "Tải chấm công", AutoSize = true };
        loadButton.Click += (_, _) => { LoadAttendance(); };
        toolbar.Controls.Add(loadButton);
        _saveAttendanceButton = new Button { Text = "Lưu chấm công", AutoSize = true, Enabled = false };
        _saveAttendanceButton.Click += (_, _) => SaveAttendance();
        toolbar.Controls.Add(_saveAttendanceButton);
        layout.Controls.Add(toolbar, 0, 0);

        _attendanceGrid.Dock = DockStyle.Fill;
        _attendanceGrid.AllowUserToAddRows = false;
        _attendanceGrid.AllowUserToDeleteRows = false;
        _attendanceGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _attendanceGrid.CellValidating += AttendanceGrid_CellValidating;
        layout.Controls.Add(_attendanceGrid, 0, 1);
        return layout;
    }

    private Control BuildPayrollPage()
    {
        var layout = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(6) };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var toolbar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false };
        toolbar.Controls.Add(new Label { Text = "Tháng/năm:", AutoSize = true, Padding = new Padding(0, 8, 0, 0) });
        _payrollMonthPicker.Format = DateTimePickerFormat.Custom;
        _payrollMonthPicker.CustomFormat = "MM/yyyy";
        _payrollMonthPicker.Width = 110;
        toolbar.Controls.Add(_payrollMonthPicker);
        var viewButton = new Button { Text = "Xem bảng lương", AutoSize = true };
        viewButton.Click += (_, _) => LoadPayroll();
        toolbar.Controls.Add(viewButton);
        var closeButton = new Button { Text = "Chốt lương tháng", AutoSize = true };
        closeButton.Click += (_, _) => ClosePayrollMonth();
        toolbar.Controls.Add(closeButton);
        layout.Controls.Add(toolbar, 0, 0);

        _payrollGrid.Dock = DockStyle.Fill;
        _payrollGrid.ReadOnly = true;
        _payrollGrid.AllowUserToAddRows = false;
        _payrollGrid.AllowUserToDeleteRows = false;
        _payrollGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        layout.Controls.Add(_payrollGrid, 0, 1);
        return layout;
    }

    private bool LoadAttendance()
    {
        try
        {
            var month = _attendanceMonthPicker.Value.ToString("MM/yyyy", CultureInfo.InvariantCulture);
            var connectionString = _connectionStringTextBox.Text.Trim();
            var adapter = _hrService.CreateAttendanceAdapter(connectionString, month);
            var table = new DataTable();
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);

            var employees = _hrService.GetEmployees(connectionString);
            var existingEmployeeIds = table.Rows.Cast<DataRow>()
                .Select(row => Convert.ToInt32(row["MaNV"]))
                .ToHashSet();
            foreach (DataRow employee in employees.Rows)
            {
                var employeeId = Convert.ToInt32(employee["MaNV"]);
                if (existingEmployeeIds.Contains(employeeId))
                    continue;
                var row = table.NewRow();
                row["MaNV"] = employeeId;
                row["ThangNam"] = month;
                row["SoNgayCong"] = 0d;
                row["SoGioOT"] = 0d;
                table.Rows.Add(row);
            }

            DisposeAttendanceAdapter();
            _attendanceAdapter = adapter;
            _attendanceTable = table;
            _attendanceGrid.DataSource = table;
            ConfigureAttendanceGrid();
            var monthClosed = _hrService.IsMonthClosed(connectionString, month);
            _attendanceGrid.ReadOnly = monthClosed;
            _saveAttendanceButton!.Enabled = !monthClosed;
            if (monthClosed)
                MessageBox.Show("Tháng này đã chốt lương; dữ liệu chấm công ở chế độ chỉ đọc.",
                    "Chấm công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        catch (Exception ex)
        {
            ShowError(ex);
            return false;
        }
    }

    private void ConfigureAttendanceGrid()
    {
        if (_attendanceGrid.Columns.Contains("MaCong"))
            _attendanceGrid.Columns["MaCong"]!.Visible = false;
        if (_attendanceGrid.Columns.Contains("ThangNam"))
            _attendanceGrid.Columns["ThangNam"]!.Visible = false;
        if (_attendanceGrid.Columns.Contains("MaNV"))
            _attendanceGrid.Columns["MaNV"]!.HeaderText = "Mã nhân viên";
        if (_attendanceGrid.Columns.Contains("SoNgayCong"))
            _attendanceGrid.Columns["SoNgayCong"]!.HeaderText = "Số ngày công";
        if (_attendanceGrid.Columns.Contains("SoGioOT"))
            _attendanceGrid.Columns["SoGioOT"]!.HeaderText = "Số giờ OT";
    }

    private void AttendanceGrid_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.RowIndex < 0 || _attendanceGrid.Columns[e.ColumnIndex].Name is not ("SoNgayCong" or "SoGioOT"))
            return;
        if (!double.TryParse(Convert.ToString(e.FormattedValue), NumberStyles.Number,
                CultureInfo.CurrentCulture, out var value) || value < 0 ||
            (_attendanceGrid.Columns[e.ColumnIndex].Name == "SoNgayCong" && value > 31))
        {
            e.Cancel = true;
            MessageBox.Show("Số ngày công phải từ 0 đến 31; số giờ OT phải từ 0 trở lên.",
                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void SaveAttendance()
    {
        if (_attendanceAdapter is null || _attendanceTable is null)
        {
            MessageBox.Show("Vui lòng tải bảng chấm công trước.", "Chấm công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var month = _attendanceMonthPicker.Value.ToString("MM/yyyy", CultureInfo.InvariantCulture);
            if (_hrService.IsMonthClosed(_connectionStringTextBox.Text.Trim(), month))
                throw new InvalidOperationException("Tháng này đã chốt lương và không thể thay đổi chấm công.");
            _attendanceGrid.EndEdit();
            BindingContext[_attendanceTable]?.EndCurrentEdit();
            using var commandBuilder = new SqlCommandBuilder(_attendanceAdapter);
            _attendanceAdapter.Update(_attendanceTable);
            if (!LoadAttendance())
                return;
            MessageBox.Show("Đã lưu chấm công.", "Chấm công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void DisposeAttendanceAdapter()
    {
        var connection = _attendanceAdapter?.SelectCommand?.Connection;
        _attendanceAdapter?.Dispose();
        connection?.Dispose();
        _attendanceAdapter = null;
        _attendanceTable = null;
    }

    private void LoadPayroll()
    {
        try
        {
            var month = _payrollMonthPicker.Value.ToString("MM/yyyy", CultureInfo.InvariantCulture);
            _payrollGrid.DataSource = _hrService.GetPayroll(_connectionStringTextBox.Text.Trim(), month);
            if (_payrollGrid.Columns.Contains("MaNV"))
                _payrollGrid.Columns["MaNV"]!.HeaderText = "Mã nhân viên";
            if (_payrollGrid.Columns.Contains("HoTen"))
                _payrollGrid.Columns["HoTen"]!.HeaderText = "Họ tên";
            if (_payrollGrid.Columns.Contains("ThangNam"))
                _payrollGrid.Columns["ThangNam"]!.HeaderText = "Tháng/năm";
            if (_payrollGrid.Columns.Contains("ThucLinh"))
                _payrollGrid.Columns["ThucLinh"]!.HeaderText = "Thực lĩnh";
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ClosePayrollMonth()
    {
        var month = _payrollMonthPicker.Value.ToString("MM/yyyy", CultureInfo.InvariantCulture);
        if (_attendanceTable?.GetChanges() is not null &&
            _attendanceMonthPicker.Value.ToString("MM/yyyy", CultureInfo.InvariantCulture) == month)
        {
            MessageBox.Show("Vui lòng lưu chấm công của tháng này trước khi chốt lương.",
                "Chốt lương", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (MessageBox.Show($"Chốt lương tháng {month}? Sau khi chốt, chấm công tháng này sẽ bị khóa.",
                "Xác nhận chốt lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            var count = _hrService.ClosePayrollMonth(_connectionStringTextBox.Text.Trim(), month);
            LoadPayroll();
            MessageBox.Show($"Đã chốt lương tháng {month} cho {count} nhân viên.",
                "Chốt lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private Control BuildEmployeePage()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Padding = new Padding(6)
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 195));
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var searchPanel = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, AutoScroll = true };
        searchPanel.Controls.Add(new Label { Text = "Họ tên:", AutoSize = true, Padding = new Padding(0, 8, 0, 0) });
        _searchNameTextBox.Width = 180;
        searchPanel.Controls.Add(_searchNameTextBox);
        searchPanel.Controls.Add(new Label { Text = "Phòng ban:", AutoSize = true, Padding = new Padding(0, 8, 0, 0) });
        _searchDepartmentComboBox.Width = 180;
        _searchDepartmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        searchPanel.Controls.Add(_searchDepartmentComboBox);
        searchPanel.Controls.Add(new Label { Text = "CCCD:", AutoSize = true, Padding = new Padding(0, 8, 0, 0) });
        _searchIdentityTextBox.Width = 150;
        searchPanel.Controls.Add(_searchIdentityTextBox);
        var searchButton = new Button { Text = "Tìm kiếm", AutoSize = true };
        searchButton.Click += (_, _) => SearchEmployees();
        searchPanel.Controls.Add(searchButton);
        var showAllButton = new Button { Text = "Hiển thị tất cả", AutoSize = true };
        showAllButton.Click += (_, _) =>
        {
            _searchNameTextBox.Clear();
            _searchIdentityTextBox.Clear();
            if (_searchDepartmentComboBox.Items.Count > 0)
                _searchDepartmentComboBox.SelectedIndex = 0;
            SearchEmployees();
        };
        searchPanel.Controls.Add(showAllButton);
        layout.Controls.Add(searchPanel, 0, 0);

        var editor = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4, RowCount = 3, Padding = new Padding(4) };
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125));
        editor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        for (var i = 0; i < 3; i++)
            editor.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));

        AddEditorField(editor, "Họ tên:", _employeeNameTextBox, 0, 0);
        AddEditorField(editor, "CCCD:", _identityNumberTextBox, 2, 0);
        _birthDatePicker.Format = DateTimePickerFormat.Short;
        _birthDatePicker.ShowCheckBox = true;
        _birthDatePicker.Checked = false;
        AddEditorField(editor, "Ngày sinh:", _birthDatePicker, 0, 1);
        _employeeDepartmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        AddEditorField(editor, "Phòng ban:", _employeeDepartmentComboBox, 2, 1);
        _baseSalaryInput.Minimum = 0.01m;
        _baseSalaryInput.Maximum = 1000000000m;
        _baseSalaryInput.DecimalPlaces = 2;
        _baseSalaryInput.Value = 10000000m;
        AddEditorField(editor, "Lương cơ bản:", _baseSalaryInput, 0, 2);
        _salaryCoefficientInput.Minimum = 0.01m;
        _salaryCoefficientInput.Maximum = 1000m;
        _salaryCoefficientInput.DecimalPlaces = 2;
        _salaryCoefficientInput.Increment = 0.1m;
        _salaryCoefficientInput.Value = 1m;
        AddEditorField(editor, "Hệ số lương:", _salaryCoefficientInput, 2, 2);

        var buttons = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false };
        var addButton = new Button { Text = "Thêm", AutoSize = true };
        addButton.Click += (_, _) => SaveEmployee(isNew: true);
        buttons.Controls.Add(addButton);
        var updateButton = new Button { Text = "Cập nhật / chuyển phòng ban", AutoSize = true };
        updateButton.Click += (_, _) => SaveEmployee(isNew: false);
        buttons.Controls.Add(updateButton);
        var deleteButton = new Button { Text = "Xóa", AutoSize = true };
        deleteButton.Click += (_, _) => DeleteEmployee();
        buttons.Controls.Add(deleteButton);
        var clearButton = new Button { Text = "Làm mới biểu mẫu", AutoSize = true };
        clearButton.Click += (_, _) => ClearEmployeeForm();
        buttons.Controls.Add(clearButton);
        editor.Controls.Add(buttons, 0, 3);
        editor.SetColumnSpan(buttons, 4);
        editor.RowCount = 4;
        editor.RowStyles.Add(new RowStyle(SizeType.Absolute, 38));
        layout.Controls.Add(editor, 0, 1);

        _employeeGrid.Dock = DockStyle.Fill;
        _employeeGrid.ReadOnly = true;
        _employeeGrid.AllowUserToAddRows = false;
        _employeeGrid.AllowUserToDeleteRows = false;
        _employeeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _employeeGrid.MultiSelect = false;
        _employeeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _employeeGrid.SelectionChanged += (_, _) => PopulateEmployeeForm();
        layout.Controls.Add(_employeeGrid, 0, 2);
        return layout;
    }

    private static void AddEditorField(TableLayoutPanel panel, string label, Control control, int column, int row)
    {
        panel.Controls.Add(new Label { Text = label, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, column, row);
        control.Dock = DockStyle.Fill;
        panel.Controls.Add(control, column + 1, row);
    }

    private void LoadEmployeeData()
    {
        try
        {
            var departments = _hrService.GetDepartments(_connectionStringTextBox.Text.Trim());
            var searchDepartments = new DataTable();
            searchDepartments.Columns.Add("MaPB", typeof(int)).AllowDBNull = true;
            searchDepartments.Columns.Add("TenPB", typeof(string));
            var allDepartmentsRow = searchDepartments.NewRow();
            allDepartmentsRow["MaPB"] = DBNull.Value;
            allDepartmentsRow["TenPB"] = "Tất cả phòng ban";
            searchDepartments.Rows.InsertAt(allDepartmentsRow, 0);
            foreach (DataRow department in departments.Rows)
                searchDepartments.Rows.Add(department["MaPB"], department["TenPB"]);
            _searchDepartmentComboBox.DataSource = searchDepartments;
            _searchDepartmentComboBox.DisplayMember = "TenPB";
            _searchDepartmentComboBox.ValueMember = "MaPB";
            _searchDepartmentComboBox.SelectedIndex = 0;
            _employeeDepartmentComboBox.DataSource = departments;
            _employeeDepartmentComboBox.DisplayMember = "TenPB";
            _employeeDepartmentComboBox.ValueMember = "MaPB";
            SearchEmployees();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void SearchEmployees()
    {
        try
        {
            var departmentId = _searchDepartmentComboBox.SelectedValue is int value ? value : (int?)null;
            _employeeGrid.DataSource = _hrService.SearchEmployees(
                _connectionStringTextBox.Text.Trim(), _searchNameTextBox.Text,
                departmentId, _searchIdentityTextBox.Text);
            if (_employeeGrid.Columns.Contains("MaNV"))
                _employeeGrid.Columns["MaNV"]!.HeaderText = "Mã NV";
            if (_employeeGrid.Columns.Contains("HoTen"))
                _employeeGrid.Columns["HoTen"]!.HeaderText = "Họ tên";
            if (_employeeGrid.Columns.Contains("NgaySinh"))
                _employeeGrid.Columns["NgaySinh"]!.HeaderText = "Ngày sinh";
            if (_employeeGrid.Columns.Contains("CCCD"))
                _employeeGrid.Columns["CCCD"]!.HeaderText = "CCCD";
            if (_employeeGrid.Columns.Contains("TenPB"))
                _employeeGrid.Columns["TenPB"]!.HeaderText = "Phòng ban";
            if (_employeeGrid.Columns.Contains("LuongCoBan"))
                _employeeGrid.Columns["LuongCoBan"]!.HeaderText = "Lương cơ bản";
            if (_employeeGrid.Columns.Contains("HeSoLuong"))
                _employeeGrid.Columns["HeSoLuong"]!.HeaderText = "Hệ số lương";
            if (_employeeGrid.Columns.Contains("MaPB"))
                _employeeGrid.Columns["MaPB"]!.Visible = false;
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void SaveEmployee(bool isNew)
    {
        try
        {
            if (!isNew && !_selectedEmployeeId.HasValue)
                throw new InvalidOperationException("Vui lòng chọn nhân viên cần cập nhật.");
            var departmentId = _employeeDepartmentComboBox.SelectedValue is int value ? value : (int?)null;
            var savedEmployeeId = _hrService.SaveEmployee(
                _connectionStringTextBox.Text.Trim(), isNew ? null : _selectedEmployeeId, _employeeNameTextBox.Text,
                _birthDatePicker.Checked ? _birthDatePicker.Value.Date : null,
                _identityNumberTextBox.Text, departmentId, _baseSalaryInput.Value,
                (double)_salaryCoefficientInput.Value);
            ClearEmployeeForm();
            SearchEmployees();
            MessageBox.Show($"Đã lưu hồ sơ nhân viên (mã {savedEmployeeId}).", "HRM", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void DeleteEmployee()
    {
        if (!_selectedEmployeeId.HasValue)
        {
            MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "HRM", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            return;

        try
        {
            _hrService.DeleteEmployee(_connectionStringTextBox.Text.Trim(), _selectedEmployeeId.Value);
            ClearEmployeeForm();
            SearchEmployees();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void PopulateEmployeeForm()
    {
        if (_employeeGrid.CurrentRow?.DataBoundItem is not DataRowView row)
            return;
        _selectedEmployeeId = Convert.ToInt32(row["MaNV"]);
        _employeeNameTextBox.Text = Convert.ToString(row["HoTen"]) ?? string.Empty;
        _identityNumberTextBox.Text = row["CCCD"] == DBNull.Value ? string.Empty : Convert.ToString(row["CCCD"]) ?? string.Empty;
        if (row["NgaySinh"] == DBNull.Value)
            _birthDatePicker.Checked = false;
        else
        {
            _birthDatePicker.Value = Convert.ToDateTime(row["NgaySinh"]);
            _birthDatePicker.Checked = true;
        }
        if (row["MaPB"] == DBNull.Value)
            _employeeDepartmentComboBox.SelectedIndex = -1;
        else
            _employeeDepartmentComboBox.SelectedValue = Convert.ToInt32(row["MaPB"]);
        _baseSalaryInput.Value = Math.Clamp(Convert.ToDecimal(row["LuongCoBan"]), _baseSalaryInput.Minimum, _baseSalaryInput.Maximum);
        _salaryCoefficientInput.Value = Math.Clamp(Convert.ToDecimal(row["HeSoLuong"]), _salaryCoefficientInput.Minimum, _salaryCoefficientInput.Maximum);
    }

    private void ClearEmployeeForm()
    {
        _selectedEmployeeId = null;
        _employeeGrid.ClearSelection();
        _employeeGrid.CurrentCell = null;
        _employeeNameTextBox.Clear();
        _identityNumberTextBox.Clear();
        _birthDatePicker.Checked = false;
        if (_employeeDepartmentComboBox.Items.Count > 0)
            _employeeDepartmentComboBox.SelectedIndex = 0;
        _baseSalaryInput.Value = 10000000m;
        _salaryCoefficientInput.Value = 1m;
    }

    private static void ShowError(Exception exception)
    {
        var message = exception is SqlException sqlException
            ? $"SQL Server: {sqlException.Message}"
            : exception.Message;
        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
