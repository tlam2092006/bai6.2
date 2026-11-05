namespace bai_6._2
{
    partial class Form1
    {
        private TableLayoutPanel rootLayout;
        private TableLayoutPanel connectionPanel;
        private Label connectionLabel;
        private Button connectButton;
        private TabControl mainTabs;
        private TabPage employeeTab;
        private TabPage attendanceTab;
        private TabPage payrollTab;
        private TableLayoutPanel employeePageLayout;
        private FlowLayoutPanel employeeSearchPanel;
        private Label searchNameLabel;
        private Label searchDepartmentLabel;
        private Label searchIdentityLabel;
        private Button searchButton;
        private Button showAllButton;
        private TableLayoutPanel employeeEditor;
        private Label employeeNameLabel;
        private Label identityNumberLabel;
        private Label birthDateLabel;
        private Label employeeDepartmentLabel;
        private Label baseSalaryLabel;
        private Label salaryCoefficientLabel;
        private FlowLayoutPanel employeeActions;
        private Button addEmployeeButton;
        private Button updateEmployeeButton;
        private Button deleteEmployeeButton;
        private Button clearEmployeeButton;
        private TableLayoutPanel attendancePageLayout;
        private FlowLayoutPanel attendanceToolbar;
        private Label attendanceMonthLabel;
        private Button loadAttendanceButton;
        private TableLayoutPanel payrollPageLayout;
        private FlowLayoutPanel payrollToolbar;
        private Label payrollMonthLabel;
        private Button viewPayrollButton;
        private Button closePayrollButton;

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _connectionStringTextBox = new TextBox();
            _employeeGrid = new DataGridView();
            _searchNameTextBox = new TextBox();
            _searchIdentityTextBox = new TextBox();
            _searchDepartmentComboBox = new ComboBox();
            _employeeNameTextBox = new TextBox();
            _identityNumberTextBox = new TextBox();
            _employeeDepartmentComboBox = new ComboBox();
            _birthDatePicker = new DateTimePicker();
            _baseSalaryInput = new NumericUpDown();
            _salaryCoefficientInput = new NumericUpDown();
            _attendanceGrid = new DataGridView();
            _attendanceMonthPicker = new DateTimePicker();
            _payrollGrid = new DataGridView();
            _payrollMonthPicker = new DateTimePicker();
            rootLayout = new TableLayoutPanel();
            connectionPanel = new TableLayoutPanel();
            connectionLabel = new Label();
            connectButton = new Button();
            mainTabs = new TabControl();
            employeeTab = new TabPage();
            employeePageLayout = new TableLayoutPanel();
            employeeSearchPanel = new FlowLayoutPanel();
            searchNameLabel = new Label();
            searchDepartmentLabel = new Label();
            searchIdentityLabel = new Label();
            searchButton = new Button();
            showAllButton = new Button();
            employeeEditor = new TableLayoutPanel();
            employeeNameLabel = new Label();
            identityNumberLabel = new Label();
            birthDateLabel = new Label();
            employeeDepartmentLabel = new Label();
            baseSalaryLabel = new Label();
            salaryCoefficientLabel = new Label();
            employeeActions = new FlowLayoutPanel();
            addEmployeeButton = new Button();
            updateEmployeeButton = new Button();
            deleteEmployeeButton = new Button();
            clearEmployeeButton = new Button();
            attendanceTab = new TabPage();
            attendancePageLayout = new TableLayoutPanel();
            attendanceToolbar = new FlowLayoutPanel();
            attendanceMonthLabel = new Label();
            loadAttendanceButton = new Button();
            _saveAttendanceButton = new Button();
            payrollTab = new TabPage();
            payrollPageLayout = new TableLayoutPanel();
            payrollToolbar = new FlowLayoutPanel();
            payrollMonthLabel = new Label();
            viewPayrollButton = new Button();
            closePayrollButton = new Button();
            ((System.ComponentModel.ISupportInitialize)_employeeGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_baseSalaryInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_salaryCoefficientInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_attendanceGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_payrollGrid).BeginInit();
            rootLayout.SuspendLayout();
            connectionPanel.SuspendLayout();
            mainTabs.SuspendLayout();
            employeeTab.SuspendLayout();
            employeePageLayout.SuspendLayout();
            employeeSearchPanel.SuspendLayout();
            employeeEditor.SuspendLayout();
            employeeActions.SuspendLayout();
            attendanceTab.SuspendLayout();
            attendancePageLayout.SuspendLayout();
            attendanceToolbar.SuspendLayout();
            payrollTab.SuspendLayout();
            payrollPageLayout.SuspendLayout();
            payrollToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // _connectionStringTextBox
            // 
            _connectionStringTextBox.Dock = DockStyle.Fill;
            _connectionStringTextBox.Location = new Point(158, 3);
            _connectionStringTextBox.Name = "_connectionStringTextBox";
            _connectionStringTextBox.Size = new Size(937, 27);
            _connectionStringTextBox.TabIndex = 1;
            // 
            // _employeeGrid
            // 
            _employeeGrid.AllowUserToAddRows = false;
            _employeeGrid.AllowUserToDeleteRows = false;
            _employeeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _employeeGrid.ColumnHeadersHeight = 29;
            _employeeGrid.Dock = DockStyle.Fill;
            _employeeGrid.Location = new Point(9, 262);
            _employeeGrid.MultiSelect = false;
            _employeeGrid.Name = "_employeeGrid";
            _employeeGrid.ReadOnly = true;
            _employeeGrid.RowHeadersWidth = 51;
            _employeeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _employeeGrid.Size = new Size(1202, 406);
            _employeeGrid.TabIndex = 2;
            _employeeGrid.SelectionChanged += EmployeeGrid_SelectionChanged;
            // 
            // _searchNameTextBox
            // 
            _searchNameTextBox.Location = new Point(66, 3);
            _searchNameTextBox.Name = "_searchNameTextBox";
            _searchNameTextBox.Size = new Size(180, 27);
            _searchNameTextBox.TabIndex = 1;
            // 
            // _searchIdentityTextBox
            // 
            _searchIdentityTextBox.Location = new Point(583, 3);
            _searchIdentityTextBox.Name = "_searchIdentityTextBox";
            _searchIdentityTextBox.Size = new Size(150, 27);
            _searchIdentityTextBox.TabIndex = 5;
            // 
            // _searchDepartmentComboBox
            // 
            _searchDepartmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _searchDepartmentComboBox.Location = new Point(341, 3);
            _searchDepartmentComboBox.Name = "_searchDepartmentComboBox";
            _searchDepartmentComboBox.Size = new Size(180, 28);
            _searchDepartmentComboBox.TabIndex = 3;
            // 
            // _employeeNameTextBox
            // 
            _employeeNameTextBox.Dock = DockStyle.Fill;
            _employeeNameTextBox.Location = new Point(132, 7);
            _employeeNameTextBox.Name = "_employeeNameTextBox";
            _employeeNameTextBox.Size = new Size(466, 27);
            _employeeNameTextBox.TabIndex = 1;
            // 
            // _identityNumberTextBox
            // 
            _identityNumberTextBox.Dock = DockStyle.Fill;
            _identityNumberTextBox.Location = new Point(729, 7);
            _identityNumberTextBox.Name = "_identityNumberTextBox";
            _identityNumberTextBox.Size = new Size(466, 27);
            _identityNumberTextBox.TabIndex = 3;
            // 
            // _employeeDepartmentComboBox
            // 
            _employeeDepartmentComboBox.Dock = DockStyle.Fill;
            _employeeDepartmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _employeeDepartmentComboBox.Location = new Point(729, 54);
            _employeeDepartmentComboBox.Name = "_employeeDepartmentComboBox";
            _employeeDepartmentComboBox.Size = new Size(466, 28);
            _employeeDepartmentComboBox.TabIndex = 7;
            // 
            // _birthDatePicker
            // 
            _birthDatePicker.Checked = false;
            _birthDatePicker.Dock = DockStyle.Fill;
            _birthDatePicker.Format = DateTimePickerFormat.Short;
            _birthDatePicker.Location = new Point(132, 54);
            _birthDatePicker.Name = "_birthDatePicker";
            _birthDatePicker.ShowCheckBox = true;
            _birthDatePicker.Size = new Size(466, 27);
            _birthDatePicker.TabIndex = 5;
            // 
            // _baseSalaryInput
            // 
            _baseSalaryInput.DecimalPlaces = 2;
            _baseSalaryInput.Dock = DockStyle.Fill;
            _baseSalaryInput.Location = new Point(132, 101);
            _baseSalaryInput.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            _baseSalaryInput.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            _baseSalaryInput.Name = "_baseSalaryInput";
            _baseSalaryInput.Size = new Size(466, 27);
            _baseSalaryInput.TabIndex = 9;
            _baseSalaryInput.Value = new decimal(new int[] { 10000000, 0, 0, 0 });
            // 
            // _salaryCoefficientInput
            // 
            _salaryCoefficientInput.DecimalPlaces = 2;
            _salaryCoefficientInput.Dock = DockStyle.Fill;
            _salaryCoefficientInput.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            _salaryCoefficientInput.Location = new Point(729, 101);
            _salaryCoefficientInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _salaryCoefficientInput.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            _salaryCoefficientInput.Name = "_salaryCoefficientInput";
            _salaryCoefficientInput.Size = new Size(466, 27);
            _salaryCoefficientInput.TabIndex = 11;
            _salaryCoefficientInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // _attendanceGrid
            // 
            _attendanceGrid.AllowUserToAddRows = false;
            _attendanceGrid.AllowUserToDeleteRows = false;
            _attendanceGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _attendanceGrid.ColumnHeadersHeight = 29;
            _attendanceGrid.Dock = DockStyle.Fill;
            _attendanceGrid.Location = new Point(9, 57);
            _attendanceGrid.Name = "_attendanceGrid";
            _attendanceGrid.RowHeadersWidth = 51;
            _attendanceGrid.Size = new Size(174, 1);
            _attendanceGrid.TabIndex = 1;
            _attendanceGrid.CellValidating += AttendanceGrid_CellValidating;
            // 
            // _attendanceMonthPicker
            // 
            _attendanceMonthPicker.CustomFormat = "MM/yyyy";
            _attendanceMonthPicker.Format = DateTimePickerFormat.Custom;
            _attendanceMonthPicker.Location = new Point(97, 3);
            _attendanceMonthPicker.Name = "_attendanceMonthPicker";
            _attendanceMonthPicker.Size = new Size(110, 27);
            _attendanceMonthPicker.TabIndex = 1;
            // 
            // _payrollGrid
            // 
            _payrollGrid.AllowUserToAddRows = false;
            _payrollGrid.AllowUserToDeleteRows = false;
            _payrollGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _payrollGrid.ColumnHeadersHeight = 29;
            _payrollGrid.Dock = DockStyle.Fill;
            _payrollGrid.Location = new Point(9, 57);
            _payrollGrid.Name = "_payrollGrid";
            _payrollGrid.ReadOnly = true;
            _payrollGrid.RowHeadersWidth = 51;
            _payrollGrid.Size = new Size(174, 1);
            _payrollGrid.TabIndex = 1;
            // 
            // _payrollMonthPicker
            // 
            _payrollMonthPicker.CustomFormat = "MM/yyyy";
            _payrollMonthPicker.Format = DateTimePickerFormat.Custom;
            _payrollMonthPicker.Location = new Point(97, 3);
            _payrollMonthPicker.Name = "_payrollMonthPicker";
            _payrollMonthPicker.Size = new Size(110, 27);
            _payrollMonthPicker.TabIndex = 1;
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 1;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            rootLayout.Controls.Add(connectionPanel, 0, 0);
            rootLayout.Controls.Add(mainTabs, 0, 1);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(8);
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.Size = new Size(1250, 780);
            rootLayout.TabIndex = 0;
            // 
            // connectionPanel
            // 
            connectionPanel.ColumnCount = 3;
            connectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            connectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            connectionPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            connectionPanel.Controls.Add(connectionLabel, 0, 0);
            connectionPanel.Controls.Add(_connectionStringTextBox, 1, 0);
            connectionPanel.Controls.Add(connectButton, 2, 0);
            connectionPanel.Dock = DockStyle.Fill;
            connectionPanel.Location = new Point(11, 11);
            connectionPanel.Name = "connectionPanel";
            connectionPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            connectionPanel.Size = new Size(1228, 42);
            connectionPanel.TabIndex = 0;
            // 
            // connectionLabel
            // 
            connectionLabel.Dock = DockStyle.Fill;
            connectionLabel.Location = new Point(3, 0);
            connectionLabel.Name = "connectionLabel";
            connectionLabel.Size = new Size(149, 42);
            connectionLabel.TabIndex = 0;
            connectionLabel.Text = "Connection string:";
            connectionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // connectButton
            // 
            connectButton.Dock = DockStyle.Fill;
            connectButton.Location = new Point(1101, 3);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(124, 36);
            connectButton.TabIndex = 2;
            connectButton.Text = "Kết nối / tải lại";
            connectButton.Click += ConnectButton_Click;
            // 
            // mainTabs
            // 
            mainTabs.Controls.Add(employeeTab);
            mainTabs.Controls.Add(attendanceTab);
            mainTabs.Controls.Add(payrollTab);
            mainTabs.Dock = DockStyle.Fill;
            mainTabs.Location = new Point(11, 59);
            mainTabs.Name = "mainTabs";
            mainTabs.SelectedIndex = 0;
            mainTabs.Size = new Size(1228, 710);
            mainTabs.TabIndex = 1;
            // 
            // employeeTab
            // 
            employeeTab.Controls.Add(employeePageLayout);
            employeeTab.Location = new Point(4, 29);
            employeeTab.Name = "employeeTab";
            employeeTab.Size = new Size(1220, 677);
            employeeTab.TabIndex = 0;
            employeeTab.Text = "Nhân viên";
            // 
            // employeePageLayout
            // 
            employeePageLayout.ColumnCount = 1;
            employeePageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            employeePageLayout.Controls.Add(employeeSearchPanel, 0, 0);
            employeePageLayout.Controls.Add(employeeEditor, 0, 1);
            employeePageLayout.Controls.Add(_employeeGrid, 0, 2);
            employeePageLayout.Dock = DockStyle.Fill;
            employeePageLayout.Location = new Point(0, 0);
            employeePageLayout.Name = "employeePageLayout";
            employeePageLayout.Padding = new Padding(6);
            employeePageLayout.RowCount = 3;
            employeePageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            employeePageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 195F));
            employeePageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            employeePageLayout.Size = new Size(1220, 677);
            employeePageLayout.TabIndex = 0;
            // 
            // employeeSearchPanel
            // 
            employeeSearchPanel.AutoScroll = true;
            employeeSearchPanel.Controls.Add(searchNameLabel);
            employeeSearchPanel.Controls.Add(_searchNameTextBox);
            employeeSearchPanel.Controls.Add(searchDepartmentLabel);
            employeeSearchPanel.Controls.Add(_searchDepartmentComboBox);
            employeeSearchPanel.Controls.Add(searchIdentityLabel);
            employeeSearchPanel.Controls.Add(_searchIdentityTextBox);
            employeeSearchPanel.Controls.Add(searchButton);
            employeeSearchPanel.Controls.Add(showAllButton);
            employeeSearchPanel.Dock = DockStyle.Fill;
            employeeSearchPanel.Location = new Point(9, 9);
            employeeSearchPanel.Name = "employeeSearchPanel";
            employeeSearchPanel.Size = new Size(1202, 52);
            employeeSearchPanel.TabIndex = 0;
            employeeSearchPanel.WrapContents = false;
            // 
            // searchNameLabel
            // 
            searchNameLabel.AutoSize = true;
            searchNameLabel.Location = new Point(3, 0);
            searchNameLabel.Name = "searchNameLabel";
            searchNameLabel.Padding = new Padding(0, 8, 0, 0);
            searchNameLabel.Size = new Size(57, 28);
            searchNameLabel.TabIndex = 0;
            searchNameLabel.Text = "Họ tên:";
            // 
            // searchDepartmentLabel
            // 
            searchDepartmentLabel.AutoSize = true;
            searchDepartmentLabel.Location = new Point(252, 0);
            searchDepartmentLabel.Name = "searchDepartmentLabel";
            searchDepartmentLabel.Padding = new Padding(0, 8, 0, 0);
            searchDepartmentLabel.Size = new Size(83, 28);
            searchDepartmentLabel.TabIndex = 2;
            searchDepartmentLabel.Text = "Phòng ban:";
            // 
            // searchIdentityLabel
            // 
            searchIdentityLabel.AutoSize = true;
            searchIdentityLabel.Location = new Point(527, 0);
            searchIdentityLabel.Name = "searchIdentityLabel";
            searchIdentityLabel.Padding = new Padding(0, 8, 0, 0);
            searchIdentityLabel.Size = new Size(50, 28);
            searchIdentityLabel.TabIndex = 4;
            searchIdentityLabel.Text = "CCCD:";
            // 
            // searchButton
            // 
            searchButton.AutoSize = true;
            searchButton.Location = new Point(739, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(80, 30);
            searchButton.TabIndex = 6;
            searchButton.Text = "Tìm kiếm";
            searchButton.Click += SearchButton_Click;
            // 
            // showAllButton
            // 
            showAllButton.AutoSize = true;
            showAllButton.Location = new Point(825, 3);
            showAllButton.Name = "showAllButton";
            showAllButton.Size = new Size(112, 30);
            showAllButton.TabIndex = 7;
            showAllButton.Text = "Hiển thị tất cả";
            showAllButton.Click += ShowAllButton_Click;
            // 
            // employeeEditor
            // 
            employeeEditor.ColumnCount = 4;
            employeeEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            employeeEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            employeeEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 125F));
            employeeEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            employeeEditor.Controls.Add(employeeNameLabel, 0, 0);
            employeeEditor.Controls.Add(_employeeNameTextBox, 1, 0);
            employeeEditor.Controls.Add(identityNumberLabel, 2, 0);
            employeeEditor.Controls.Add(_identityNumberTextBox, 3, 0);
            employeeEditor.Controls.Add(birthDateLabel, 0, 1);
            employeeEditor.Controls.Add(_birthDatePicker, 1, 1);
            employeeEditor.Controls.Add(employeeDepartmentLabel, 2, 1);
            employeeEditor.Controls.Add(_employeeDepartmentComboBox, 3, 1);
            employeeEditor.Controls.Add(baseSalaryLabel, 0, 2);
            employeeEditor.Controls.Add(_baseSalaryInput, 1, 2);
            employeeEditor.Controls.Add(salaryCoefficientLabel, 2, 2);
            employeeEditor.Controls.Add(_salaryCoefficientInput, 3, 2);
            employeeEditor.Controls.Add(employeeActions, 0, 3);
            employeeEditor.Dock = DockStyle.Fill;
            employeeEditor.Location = new Point(9, 67);
            employeeEditor.Name = "employeeEditor";
            employeeEditor.Padding = new Padding(4);
            employeeEditor.RowCount = 4;
            employeeEditor.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            employeeEditor.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            employeeEditor.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            employeeEditor.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            employeeEditor.Size = new Size(1202, 189);
            employeeEditor.TabIndex = 1;
            // 
            // employeeNameLabel
            // 
            employeeNameLabel.Dock = DockStyle.Fill;
            employeeNameLabel.Location = new Point(7, 4);
            employeeNameLabel.Name = "employeeNameLabel";
            employeeNameLabel.Size = new Size(119, 47);
            employeeNameLabel.TabIndex = 0;
            employeeNameLabel.Text = "Họ tên:";
            employeeNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // identityNumberLabel
            // 
            identityNumberLabel.Dock = DockStyle.Fill;
            identityNumberLabel.Location = new Point(604, 4);
            identityNumberLabel.Name = "identityNumberLabel";
            identityNumberLabel.Size = new Size(119, 47);
            identityNumberLabel.TabIndex = 2;
            identityNumberLabel.Text = "CCCD:";
            identityNumberLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // birthDateLabel
            // 
            birthDateLabel.Dock = DockStyle.Fill;
            birthDateLabel.Location = new Point(7, 51);
            birthDateLabel.Name = "birthDateLabel";
            birthDateLabel.Size = new Size(119, 47);
            birthDateLabel.TabIndex = 4;
            birthDateLabel.Text = "Ngày sinh:";
            birthDateLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // employeeDepartmentLabel
            // 
            employeeDepartmentLabel.Dock = DockStyle.Fill;
            employeeDepartmentLabel.Location = new Point(604, 51);
            employeeDepartmentLabel.Name = "employeeDepartmentLabel";
            employeeDepartmentLabel.Size = new Size(119, 47);
            employeeDepartmentLabel.TabIndex = 6;
            employeeDepartmentLabel.Text = "Phòng ban:";
            employeeDepartmentLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // baseSalaryLabel
            // 
            baseSalaryLabel.Dock = DockStyle.Fill;
            baseSalaryLabel.Location = new Point(7, 98);
            baseSalaryLabel.Name = "baseSalaryLabel";
            baseSalaryLabel.Size = new Size(119, 47);
            baseSalaryLabel.TabIndex = 8;
            baseSalaryLabel.Text = "Lương cơ bản:";
            baseSalaryLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // salaryCoefficientLabel
            // 
            salaryCoefficientLabel.Dock = DockStyle.Fill;
            salaryCoefficientLabel.Location = new Point(604, 98);
            salaryCoefficientLabel.Name = "salaryCoefficientLabel";
            salaryCoefficientLabel.Size = new Size(119, 47);
            salaryCoefficientLabel.TabIndex = 10;
            salaryCoefficientLabel.Text = "Hệ số lương:";
            salaryCoefficientLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // employeeActions
            // 
            employeeEditor.SetColumnSpan(employeeActions, 4);
            employeeActions.Controls.Add(addEmployeeButton);
            employeeActions.Controls.Add(updateEmployeeButton);
            employeeActions.Controls.Add(deleteEmployeeButton);
            employeeActions.Controls.Add(clearEmployeeButton);
            employeeActions.Dock = DockStyle.Fill;
            employeeActions.Location = new Point(7, 148);
            employeeActions.Name = "employeeActions";
            employeeActions.Size = new Size(1188, 34);
            employeeActions.TabIndex = 12;
            employeeActions.WrapContents = false;
            // 
            // addEmployeeButton
            // 
            addEmployeeButton.AutoSize = true;
            addEmployeeButton.Location = new Point(3, 3);
            addEmployeeButton.Name = "addEmployeeButton";
            addEmployeeButton.Size = new Size(75, 30);
            addEmployeeButton.TabIndex = 0;
            addEmployeeButton.Text = "Thêm";
            addEmployeeButton.Click += AddEmployeeButton_Click;
            // 
            // updateEmployeeButton
            // 
            updateEmployeeButton.AutoSize = true;
            updateEmployeeButton.Location = new Point(84, 3);
            updateEmployeeButton.Name = "updateEmployeeButton";
            updateEmployeeButton.Size = new Size(214, 30);
            updateEmployeeButton.TabIndex = 1;
            updateEmployeeButton.Text = "Cập nhật / chuyển phòng ban";
            updateEmployeeButton.Click += UpdateEmployeeButton_Click;
            // 
            // deleteEmployeeButton
            // 
            deleteEmployeeButton.AutoSize = true;
            deleteEmployeeButton.Location = new Point(304, 3);
            deleteEmployeeButton.Name = "deleteEmployeeButton";
            deleteEmployeeButton.Size = new Size(75, 30);
            deleteEmployeeButton.TabIndex = 2;
            deleteEmployeeButton.Text = "Xóa";
            deleteEmployeeButton.Click += DeleteEmployeeButton_Click;
            // 
            // clearEmployeeButton
            // 
            clearEmployeeButton.AutoSize = true;
            clearEmployeeButton.Location = new Point(385, 3);
            clearEmployeeButton.Name = "clearEmployeeButton";
            clearEmployeeButton.Size = new Size(143, 30);
            clearEmployeeButton.TabIndex = 3;
            clearEmployeeButton.Text = "Làm mới biểu mẫu";
            clearEmployeeButton.Click += ClearEmployeeButton_Click;
            // 
            // attendanceTab
            // 
            attendanceTab.Controls.Add(attendancePageLayout);
            attendanceTab.Location = new Point(4, 29);
            attendanceTab.Name = "attendanceTab";
            attendanceTab.Size = new Size(192, 0);
            attendanceTab.TabIndex = 1;
            attendanceTab.Text = "Chấm công";
            // 
            // attendancePageLayout
            // 
            attendancePageLayout.ColumnCount = 1;
            attendancePageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            attendancePageLayout.Controls.Add(attendanceToolbar, 0, 0);
            attendancePageLayout.Controls.Add(_attendanceGrid, 0, 1);
            attendancePageLayout.Dock = DockStyle.Fill;
            attendancePageLayout.Location = new Point(0, 0);
            attendancePageLayout.Name = "attendancePageLayout";
            attendancePageLayout.Padding = new Padding(6);
            attendancePageLayout.RowCount = 2;
            attendancePageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            attendancePageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            attendancePageLayout.Size = new Size(192, 0);
            attendancePageLayout.TabIndex = 0;
            // 
            // attendanceToolbar
            // 
            attendanceToolbar.Controls.Add(attendanceMonthLabel);
            attendanceToolbar.Controls.Add(_attendanceMonthPicker);
            attendanceToolbar.Controls.Add(loadAttendanceButton);
            attendanceToolbar.Controls.Add(_saveAttendanceButton);
            attendanceToolbar.Dock = DockStyle.Fill;
            attendanceToolbar.Location = new Point(9, 9);
            attendanceToolbar.Name = "attendanceToolbar";
            attendanceToolbar.Size = new Size(174, 42);
            attendanceToolbar.TabIndex = 0;
            attendanceToolbar.WrapContents = false;
            // 
            // attendanceMonthLabel
            // 
            attendanceMonthLabel.AutoSize = true;
            attendanceMonthLabel.Location = new Point(3, 0);
            attendanceMonthLabel.Name = "attendanceMonthLabel";
            attendanceMonthLabel.Padding = new Padding(0, 8, 0, 0);
            attendanceMonthLabel.Size = new Size(88, 28);
            attendanceMonthLabel.TabIndex = 0;
            attendanceMonthLabel.Text = "Tháng/năm:";
            // 
            // loadAttendanceButton
            // 
            loadAttendanceButton.AutoSize = true;
            loadAttendanceButton.Location = new Point(213, 3);
            loadAttendanceButton.Name = "loadAttendanceButton";
            loadAttendanceButton.Size = new Size(116, 30);
            loadAttendanceButton.TabIndex = 2;
            loadAttendanceButton.Text = "Tải chấm công";
            loadAttendanceButton.Click += LoadAttendanceButton_Click;
            // 
            // _saveAttendanceButton
            // 
            _saveAttendanceButton.AutoSize = true;
            _saveAttendanceButton.Enabled = false;
            _saveAttendanceButton.Location = new Point(335, 3);
            _saveAttendanceButton.Name = "_saveAttendanceButton";
            _saveAttendanceButton.Size = new Size(120, 30);
            _saveAttendanceButton.TabIndex = 3;
            _saveAttendanceButton.Text = "Lưu chấm công";
            _saveAttendanceButton.Click += SaveAttendanceButton_Click;
            // 
            // payrollTab
            // 
            payrollTab.Controls.Add(payrollPageLayout);
            payrollTab.Location = new Point(4, 29);
            payrollTab.Name = "payrollTab";
            payrollTab.Size = new Size(192, 0);
            payrollTab.TabIndex = 2;
            payrollTab.Text = "Tính lương / Chốt lương";
            // 
            // payrollPageLayout
            // 
            payrollPageLayout.ColumnCount = 1;
            payrollPageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            payrollPageLayout.Controls.Add(payrollToolbar, 0, 0);
            payrollPageLayout.Controls.Add(_payrollGrid, 0, 1);
            payrollPageLayout.Dock = DockStyle.Fill;
            payrollPageLayout.Location = new Point(0, 0);
            payrollPageLayout.Name = "payrollPageLayout";
            payrollPageLayout.Padding = new Padding(6);
            payrollPageLayout.RowCount = 2;
            payrollPageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            payrollPageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            payrollPageLayout.Size = new Size(192, 0);
            payrollPageLayout.TabIndex = 0;
            // 
            // payrollToolbar
            // 
            payrollToolbar.Controls.Add(payrollMonthLabel);
            payrollToolbar.Controls.Add(_payrollMonthPicker);
            payrollToolbar.Controls.Add(viewPayrollButton);
            payrollToolbar.Controls.Add(closePayrollButton);
            payrollToolbar.Dock = DockStyle.Fill;
            payrollToolbar.Location = new Point(9, 9);
            payrollToolbar.Name = "payrollToolbar";
            payrollToolbar.Size = new Size(174, 42);
            payrollToolbar.TabIndex = 0;
            payrollToolbar.WrapContents = false;
            // 
            // payrollMonthLabel
            // 
            payrollMonthLabel.AutoSize = true;
            payrollMonthLabel.Location = new Point(3, 0);
            payrollMonthLabel.Name = "payrollMonthLabel";
            payrollMonthLabel.Padding = new Padding(0, 8, 0, 0);
            payrollMonthLabel.Size = new Size(88, 28);
            payrollMonthLabel.TabIndex = 0;
            payrollMonthLabel.Text = "Tháng/năm:";
            // 
            // viewPayrollButton
            // 
            viewPayrollButton.AutoSize = true;
            viewPayrollButton.Location = new Point(213, 3);
            viewPayrollButton.Name = "viewPayrollButton";
            viewPayrollButton.Size = new Size(130, 30);
            viewPayrollButton.TabIndex = 2;
            viewPayrollButton.Text = "Xem bảng lương";
            viewPayrollButton.Click += ViewPayrollButton_Click;
            // 
            // closePayrollButton
            // 
            closePayrollButton.AutoSize = true;
            closePayrollButton.Location = new Point(349, 3);
            closePayrollButton.Name = "closePayrollButton";
            closePayrollButton.Size = new Size(135, 30);
            closePayrollButton.TabIndex = 3;
            closePayrollButton.Text = "Chốt lương tháng";
            closePayrollButton.Click += ClosePayrollButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 780);
            Controls.Add(rootLayout);
            MinimumSize = new Size(1000, 650);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý nhân sự và tính lương";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)_employeeGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)_baseSalaryInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)_salaryCoefficientInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)_attendanceGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)_payrollGrid).EndInit();
            rootLayout.ResumeLayout(false);
            connectionPanel.ResumeLayout(false);
            connectionPanel.PerformLayout();
            mainTabs.ResumeLayout(false);
            employeeTab.ResumeLayout(false);
            employeePageLayout.ResumeLayout(false);
            employeeSearchPanel.ResumeLayout(false);
            employeeSearchPanel.PerformLayout();
            employeeEditor.ResumeLayout(false);
            employeeEditor.PerformLayout();
            employeeActions.ResumeLayout(false);
            employeeActions.PerformLayout();
            attendanceTab.ResumeLayout(false);
            attendancePageLayout.ResumeLayout(false);
            attendanceToolbar.ResumeLayout(false);
            attendanceToolbar.PerformLayout();
            payrollTab.ResumeLayout(false);
            payrollPageLayout.ResumeLayout(false);
            payrollToolbar.ResumeLayout(false);
            payrollToolbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
