namespace QUANLYTHUVIEN
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDX = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPhanQuyen = new System.Windows.Forms.Button();
            this.tabThuVien = new System.Windows.Forms.TabControl();
            this.sachTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelSach = new System.Windows.Forms.TableLayoutPanel();
            this.btnUpdateSach = new System.Windows.Forms.Button();
            this.btnImportSach = new System.Windows.Forms.Button();
            this.btnDeleteSach = new System.Windows.Forms.Button();
            this.btnReloadSach = new System.Windows.Forms.Button();
            this.btnExportSach = new System.Windows.Forms.Button();
            this.sachListView = new System.Windows.Forms.ListView();
            this.btnAddSach = new System.Windows.Forms.Button();
            this.docGiaTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelDocGia = new System.Windows.Forms.TableLayoutPanel();
            this.btnReloadDocGia = new System.Windows.Forms.Button();
            this.btnImportDocGia = new System.Windows.Forms.Button();
            this.btnDeleteDocGia = new System.Windows.Forms.Button();
            this.btnAddDocGia = new System.Windows.Forms.Button();
            this.btnExportDocGia = new System.Windows.Forms.Button();
            this.docGiaListView = new System.Windows.Forms.ListView();
            this.btnUpdateDocGia = new System.Windows.Forms.Button();
            this.nhanVienTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelNhanVien = new System.Windows.Forms.TableLayoutPanel();
            this.btnReloadNhanVien = new System.Windows.Forms.Button();
            this.btnImportNhanVien = new System.Windows.Forms.Button();
            this.btnDeleteNhanVien = new System.Windows.Forms.Button();
            this.btnAddNhanVien = new System.Windows.Forms.Button();
            this.btnExportNhanVien = new System.Windows.Forms.Button();
            this.nhanVienListView = new System.Windows.Forms.ListView();
            this.btnUpdateNhanVien = new System.Windows.Forms.Button();
            this.muonTraTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMuonTra = new System.Windows.Forms.TableLayoutPanel();
            this.btnReloadMuonTra = new System.Windows.Forms.Button();
            this.btnImportMuonTra = new System.Windows.Forms.Button();
            this.btnDeleteMuonTra = new System.Windows.Forms.Button();
            this.btnAddMuonTra = new System.Windows.Forms.Button();
            this.btnExportMuonTra = new System.Windows.Forms.Button();
            this.muonTraListView = new System.Windows.Forms.ListView();
            this.btnUpdateMuonTra = new System.Windows.Forms.Button();
            this.comboBoxHienThi = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tabThuVien.SuspendLayout();
            this.sachTab.SuspendLayout();
            this.tableLayoutPanelSach.SuspendLayout();
            this.docGiaTab.SuspendLayout();
            this.tableLayoutPanelDocGia.SuspendLayout();
            this.nhanVienTab.SuspendLayout();
            this.tableLayoutPanelNhanVien.SuspendLayout();
            this.muonTraTab.SuspendLayout();
            this.tableLayoutPanelMuonTra.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDX
            // 
            this.btnDX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDX.AutoSize = true;
            this.btnDX.BackColor = System.Drawing.Color.Blue;
            this.btnDX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDX.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDX.Location = new System.Drawing.Point(893, 12);
            this.btnDX.Name = "btnDX";
            this.btnDX.Size = new System.Drawing.Size(165, 34);
            this.btnDX.TabIndex = 1;
            this.btnDX.Text = "Đăng xuất";
            this.btnDX.UseVisualStyleBackColor = false;
            this.btnDX.Click += new System.EventHandler(this.btnDX_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnPhanQuyen);
            this.panel1.Controls.Add(this.btnDX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 507);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 49);
            this.panel1.TabIndex = 0;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhanQuyen.AutoSize = true;
            this.btnPhanQuyen.BackColor = System.Drawing.Color.Blue;
            this.btnPhanQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanQuyen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPhanQuyen.Location = new System.Drawing.Point(703, 12);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Size = new System.Drawing.Size(132, 34);
            this.btnPhanQuyen.TabIndex = 9;
            this.btnPhanQuyen.Text = "Phân quyền";
            this.btnPhanQuyen.UseVisualStyleBackColor = false;
            this.btnPhanQuyen.Click += new System.EventHandler(this.btnPhanQuyen_Click);
            // 
            // tabThuVien
            // 
            this.tabThuVien.Controls.Add(this.sachTab);
            this.tabThuVien.Controls.Add(this.docGiaTab);
            this.tabThuVien.Controls.Add(this.nhanVienTab);
            this.tabThuVien.Controls.Add(this.muonTraTab);
            this.tabThuVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabThuVien.Location = new System.Drawing.Point(0, 0);
            this.tabThuVien.Name = "tabThuVien";
            this.tabThuVien.SelectedIndex = 0;
            this.tabThuVien.Size = new System.Drawing.Size(1071, 401);
            this.tabThuVien.TabIndex = 11;
            // 
            // sachTab
            // 
            this.sachTab.Controls.Add(this.tableLayoutPanelSach);
            this.sachTab.Location = new System.Drawing.Point(4, 25);
            this.sachTab.Name = "sachTab";
            this.sachTab.Padding = new System.Windows.Forms.Padding(3);
            this.sachTab.Size = new System.Drawing.Size(1063, 372);
            this.sachTab.TabIndex = 0;
            this.sachTab.Text = "Sách";
            this.sachTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSach
            // 
            this.tableLayoutPanelSach.ColumnCount = 7;
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSach.Controls.Add(this.btnUpdateSach, 4, 0);
            this.tableLayoutPanelSach.Controls.Add(this.btnImportSach, 1, 0);
            this.tableLayoutPanelSach.Controls.Add(this.btnDeleteSach, 5, 0);
            this.tableLayoutPanelSach.Controls.Add(this.btnReloadSach, 6, 0);
            this.tableLayoutPanelSach.Controls.Add(this.btnExportSach, 0, 0);
            this.tableLayoutPanelSach.Controls.Add(this.sachListView, 0, 1);
            this.tableLayoutPanelSach.Controls.Add(this.btnAddSach, 3, 0);
            this.tableLayoutPanelSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSach.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelSach.Name = "tableLayoutPanelSach";
            this.tableLayoutPanelSach.RowCount = 2;
            this.tableLayoutPanelSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSach.Size = new System.Drawing.Size(1057, 366);
            this.tableLayoutPanelSach.TabIndex = 1;
            // 
            // btnUpdateSach
            // 
            this.btnUpdateSach.AutoSize = true;
            this.btnUpdateSach.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnUpdateSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateSach.Location = new System.Drawing.Point(805, 3);
            this.btnUpdateSach.Name = "btnUpdateSach";
            this.btnUpdateSach.Size = new System.Drawing.Size(79, 44);
            this.btnUpdateSach.TabIndex = 13;
            this.btnUpdateSach.Text = "Update";
            this.btnUpdateSach.UseVisualStyleBackColor = false;
            this.btnUpdateSach.Click += new System.EventHandler(this.btnUpdateSach_Click);
            // 
            // btnImportSach
            // 
            this.btnImportSach.AutoSize = true;
            this.btnImportSach.BackColor = System.Drawing.Color.Blue;
            this.btnImportSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportSach.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportSach.Location = new System.Drawing.Point(88, 3);
            this.btnImportSach.Name = "btnImportSach";
            this.btnImportSach.Size = new System.Drawing.Size(79, 44);
            this.btnImportSach.TabIndex = 10;
            this.btnImportSach.Text = "Import";
            this.btnImportSach.UseVisualStyleBackColor = false;
            this.btnImportSach.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDeleteSach
            // 
            this.btnDeleteSach.AutoSize = true;
            this.btnDeleteSach.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnDeleteSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteSach.Location = new System.Drawing.Point(890, 3);
            this.btnDeleteSach.Name = "btnDeleteSach";
            this.btnDeleteSach.Size = new System.Drawing.Size(79, 44);
            this.btnDeleteSach.TabIndex = 10;
            this.btnDeleteSach.Text = "Delete";
            this.btnDeleteSach.UseVisualStyleBackColor = false;
            this.btnDeleteSach.Click += new System.EventHandler(this.btnDeleteSach_Click);
            // 
            // btnReloadSach
            // 
            this.btnReloadSach.AutoSize = true;
            this.btnReloadSach.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnReloadSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadSach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReloadSach.Location = new System.Drawing.Point(975, 3);
            this.btnReloadSach.Name = "btnReloadSach";
            this.btnReloadSach.Size = new System.Drawing.Size(79, 44);
            this.btnReloadSach.TabIndex = 8;
            this.btnReloadSach.Text = "Reload";
            this.btnReloadSach.UseVisualStyleBackColor = false;
            this.btnReloadSach.Click += new System.EventHandler(this.btnReloadSach_Click);
            // 
            // btnExportSach
            // 
            this.btnExportSach.AutoSize = true;
            this.btnExportSach.BackColor = System.Drawing.Color.Blue;
            this.btnExportSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportSach.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportSach.Location = new System.Drawing.Point(3, 3);
            this.btnExportSach.Name = "btnExportSach";
            this.btnExportSach.Size = new System.Drawing.Size(79, 44);
            this.btnExportSach.TabIndex = 10;
            this.btnExportSach.Text = "Export";
            this.btnExportSach.UseVisualStyleBackColor = false;
            this.btnExportSach.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // sachListView
            // 
            this.tableLayoutPanelSach.SetColumnSpan(this.sachListView, 7);
            this.sachListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sachListView.FullRowSelect = true;
            this.sachListView.GridLines = true;
            this.sachListView.HideSelection = false;
            this.sachListView.Location = new System.Drawing.Point(3, 53);
            this.sachListView.Name = "sachListView";
            this.sachListView.Size = new System.Drawing.Size(1051, 310);
            this.sachListView.TabIndex = 0;
            this.sachListView.TabStop = false;
            this.sachListView.UseCompatibleStateImageBehavior = false;
            this.sachListView.View = System.Windows.Forms.View.Details;
            // 
            // btnAddSach
            // 
            this.btnAddSach.AutoSize = true;
            this.btnAddSach.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnAddSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddSach.Location = new System.Drawing.Point(720, 3);
            this.btnAddSach.Name = "btnAddSach";
            this.btnAddSach.Size = new System.Drawing.Size(79, 44);
            this.btnAddSach.TabIndex = 11;
            this.btnAddSach.Text = "Add";
            this.btnAddSach.UseVisualStyleBackColor = false;
            this.btnAddSach.Click += new System.EventHandler(this.btnAddSach_Click);
            // 
            // docGiaTab
            // 
            this.docGiaTab.Controls.Add(this.tableLayoutPanelDocGia);
            this.docGiaTab.Location = new System.Drawing.Point(4, 25);
            this.docGiaTab.Name = "docGiaTab";
            this.docGiaTab.Padding = new System.Windows.Forms.Padding(3);
            this.docGiaTab.Size = new System.Drawing.Size(1063, 372);
            this.docGiaTab.TabIndex = 1;
            this.docGiaTab.Text = "Độc giả";
            this.docGiaTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelDocGia
            // 
            this.tableLayoutPanelDocGia.ColumnCount = 7;
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelDocGia.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelDocGia.Controls.Add(this.btnReloadDocGia, 6, 0);
            this.tableLayoutPanelDocGia.Controls.Add(this.btnImportDocGia, 1, 0);
            this.tableLayoutPanelDocGia.Controls.Add(this.btnDeleteDocGia, 4, 0);
            this.tableLayoutPanelDocGia.Controls.Add(this.btnAddDocGia, 5, 0);
            this.tableLayoutPanelDocGia.Controls.Add(this.btnExportDocGia, 0, 0);
            this.tableLayoutPanelDocGia.Controls.Add(this.docGiaListView, 0, 1);
            this.tableLayoutPanelDocGia.Controls.Add(this.btnUpdateDocGia, 3, 0);
            this.tableLayoutPanelDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDocGia.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelDocGia.Name = "tableLayoutPanelDocGia";
            this.tableLayoutPanelDocGia.RowCount = 2;
            this.tableLayoutPanelDocGia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelDocGia.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDocGia.Size = new System.Drawing.Size(1057, 366);
            this.tableLayoutPanelDocGia.TabIndex = 2;
            // 
            // btnReloadDocGia
            // 
            this.btnReloadDocGia.AutoSize = true;
            this.btnReloadDocGia.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnReloadDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadDocGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReloadDocGia.Location = new System.Drawing.Point(975, 3);
            this.btnReloadDocGia.Name = "btnReloadDocGia";
            this.btnReloadDocGia.Size = new System.Drawing.Size(79, 44);
            this.btnReloadDocGia.TabIndex = 13;
            this.btnReloadDocGia.Text = "Reload";
            this.btnReloadDocGia.UseVisualStyleBackColor = false;
            // 
            // btnImportDocGia
            // 
            this.btnImportDocGia.AutoSize = true;
            this.btnImportDocGia.BackColor = System.Drawing.Color.Blue;
            this.btnImportDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportDocGia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportDocGia.Location = new System.Drawing.Point(88, 3);
            this.btnImportDocGia.Name = "btnImportDocGia";
            this.btnImportDocGia.Size = new System.Drawing.Size(79, 44);
            this.btnImportDocGia.TabIndex = 10;
            this.btnImportDocGia.Text = "Import";
            this.btnImportDocGia.UseVisualStyleBackColor = false;
            this.btnImportDocGia.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDeleteDocGia
            // 
            this.btnDeleteDocGia.AutoSize = true;
            this.btnDeleteDocGia.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnDeleteDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDocGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteDocGia.Location = new System.Drawing.Point(805, 3);
            this.btnDeleteDocGia.Name = "btnDeleteDocGia";
            this.btnDeleteDocGia.Size = new System.Drawing.Size(79, 44);
            this.btnDeleteDocGia.TabIndex = 10;
            this.btnDeleteDocGia.Text = "Delete";
            this.btnDeleteDocGia.UseVisualStyleBackColor = false;
            this.btnDeleteDocGia.Click += new System.EventHandler(this.btnDeleteDocGia_Click);
            // 
            // btnAddDocGia
            // 
            this.btnAddDocGia.AutoSize = true;
            this.btnAddDocGia.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnAddDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDocGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddDocGia.Location = new System.Drawing.Point(890, 3);
            this.btnAddDocGia.Name = "btnAddDocGia";
            this.btnAddDocGia.Size = new System.Drawing.Size(79, 44);
            this.btnAddDocGia.TabIndex = 8;
            this.btnAddDocGia.Text = "Add";
            this.btnAddDocGia.UseVisualStyleBackColor = false;
            this.btnAddDocGia.Click += new System.EventHandler(this.btnAddDocGia_Click);
            // 
            // btnExportDocGia
            // 
            this.btnExportDocGia.AutoSize = true;
            this.btnExportDocGia.BackColor = System.Drawing.Color.Blue;
            this.btnExportDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDocGia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportDocGia.Location = new System.Drawing.Point(3, 3);
            this.btnExportDocGia.Name = "btnExportDocGia";
            this.btnExportDocGia.Size = new System.Drawing.Size(79, 44);
            this.btnExportDocGia.TabIndex = 10;
            this.btnExportDocGia.Text = "Export";
            this.btnExportDocGia.UseVisualStyleBackColor = false;
            this.btnExportDocGia.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // docGiaListView
            // 
            this.tableLayoutPanelDocGia.SetColumnSpan(this.docGiaListView, 7);
            this.docGiaListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docGiaListView.FullRowSelect = true;
            this.docGiaListView.GridLines = true;
            this.docGiaListView.HideSelection = false;
            this.docGiaListView.Location = new System.Drawing.Point(3, 53);
            this.docGiaListView.Name = "docGiaListView";
            this.docGiaListView.Size = new System.Drawing.Size(1051, 310);
            this.docGiaListView.TabIndex = 0;
            this.docGiaListView.TabStop = false;
            this.docGiaListView.UseCompatibleStateImageBehavior = false;
            this.docGiaListView.View = System.Windows.Forms.View.Details;
            // 
            // btnUpdateDocGia
            // 
            this.btnUpdateDocGia.AutoSize = true;
            this.btnUpdateDocGia.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnUpdateDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDocGia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateDocGia.Location = new System.Drawing.Point(720, 3);
            this.btnUpdateDocGia.Name = "btnUpdateDocGia";
            this.btnUpdateDocGia.Size = new System.Drawing.Size(79, 44);
            this.btnUpdateDocGia.TabIndex = 11;
            this.btnUpdateDocGia.Text = "Update";
            this.btnUpdateDocGia.UseVisualStyleBackColor = false;
            this.btnUpdateDocGia.Click += new System.EventHandler(this.btnUpdateDocGia_Click);
            // 
            // nhanVienTab
            // 
            this.nhanVienTab.Controls.Add(this.tableLayoutPanelNhanVien);
            this.nhanVienTab.Location = new System.Drawing.Point(4, 25);
            this.nhanVienTab.Name = "nhanVienTab";
            this.nhanVienTab.Padding = new System.Windows.Forms.Padding(3);
            this.nhanVienTab.Size = new System.Drawing.Size(1063, 372);
            this.nhanVienTab.TabIndex = 2;
            this.nhanVienTab.Text = "Nhân viên";
            this.nhanVienTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelNhanVien
            // 
            this.tableLayoutPanelNhanVien.ColumnCount = 7;
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelNhanVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelNhanVien.Controls.Add(this.btnReloadNhanVien, 6, 0);
            this.tableLayoutPanelNhanVien.Controls.Add(this.btnImportNhanVien, 1, 0);
            this.tableLayoutPanelNhanVien.Controls.Add(this.btnDeleteNhanVien, 4, 0);
            this.tableLayoutPanelNhanVien.Controls.Add(this.btnAddNhanVien, 5, 0);
            this.tableLayoutPanelNhanVien.Controls.Add(this.btnExportNhanVien, 0, 0);
            this.tableLayoutPanelNhanVien.Controls.Add(this.nhanVienListView, 0, 1);
            this.tableLayoutPanelNhanVien.Controls.Add(this.btnUpdateNhanVien, 3, 0);
            this.tableLayoutPanelNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelNhanVien.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelNhanVien.Name = "tableLayoutPanelNhanVien";
            this.tableLayoutPanelNhanVien.RowCount = 2;
            this.tableLayoutPanelNhanVien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelNhanVien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelNhanVien.Size = new System.Drawing.Size(1057, 366);
            this.tableLayoutPanelNhanVien.TabIndex = 2;
            // 
            // btnReloadNhanVien
            // 
            this.btnReloadNhanVien.AutoSize = true;
            this.btnReloadNhanVien.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnReloadNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadNhanVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReloadNhanVien.Location = new System.Drawing.Point(975, 3);
            this.btnReloadNhanVien.Name = "btnReloadNhanVien";
            this.btnReloadNhanVien.Size = new System.Drawing.Size(79, 44);
            this.btnReloadNhanVien.TabIndex = 13;
            this.btnReloadNhanVien.Text = "Reload";
            this.btnReloadNhanVien.UseVisualStyleBackColor = false;
            // 
            // btnImportNhanVien
            // 
            this.btnImportNhanVien.AutoSize = true;
            this.btnImportNhanVien.BackColor = System.Drawing.Color.Blue;
            this.btnImportNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportNhanVien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportNhanVien.Location = new System.Drawing.Point(88, 3);
            this.btnImportNhanVien.Name = "btnImportNhanVien";
            this.btnImportNhanVien.Size = new System.Drawing.Size(79, 44);
            this.btnImportNhanVien.TabIndex = 10;
            this.btnImportNhanVien.Text = "Import";
            this.btnImportNhanVien.UseVisualStyleBackColor = false;
            this.btnImportNhanVien.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDeleteNhanVien
            // 
            this.btnDeleteNhanVien.AutoSize = true;
            this.btnDeleteNhanVien.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnDeleteNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteNhanVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteNhanVien.Location = new System.Drawing.Point(805, 3);
            this.btnDeleteNhanVien.Name = "btnDeleteNhanVien";
            this.btnDeleteNhanVien.Size = new System.Drawing.Size(79, 44);
            this.btnDeleteNhanVien.TabIndex = 10;
            this.btnDeleteNhanVien.Text = "Delete";
            this.btnDeleteNhanVien.UseVisualStyleBackColor = false;
            this.btnDeleteNhanVien.Click += new System.EventHandler(this.btnDeleteNhanVien_Click);
            // 
            // btnAddNhanVien
            // 
            this.btnAddNhanVien.AutoSize = true;
            this.btnAddNhanVien.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnAddNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNhanVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNhanVien.Location = new System.Drawing.Point(890, 3);
            this.btnAddNhanVien.Name = "btnAddNhanVien";
            this.btnAddNhanVien.Size = new System.Drawing.Size(79, 44);
            this.btnAddNhanVien.TabIndex = 8;
            this.btnAddNhanVien.Text = "Add";
            this.btnAddNhanVien.UseVisualStyleBackColor = false;
            this.btnAddNhanVien.Click += new System.EventHandler(this.btnAddNhanVien_Click);
            // 
            // btnExportNhanVien
            // 
            this.btnExportNhanVien.AutoSize = true;
            this.btnExportNhanVien.BackColor = System.Drawing.Color.Blue;
            this.btnExportNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportNhanVien.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportNhanVien.Location = new System.Drawing.Point(3, 3);
            this.btnExportNhanVien.Name = "btnExportNhanVien";
            this.btnExportNhanVien.Size = new System.Drawing.Size(79, 44);
            this.btnExportNhanVien.TabIndex = 10;
            this.btnExportNhanVien.Text = "Export";
            this.btnExportNhanVien.UseVisualStyleBackColor = false;
            this.btnExportNhanVien.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // nhanVienListView
            // 
            this.tableLayoutPanelNhanVien.SetColumnSpan(this.nhanVienListView, 7);
            this.nhanVienListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nhanVienListView.FullRowSelect = true;
            this.nhanVienListView.GridLines = true;
            this.nhanVienListView.HideSelection = false;
            this.nhanVienListView.Location = new System.Drawing.Point(3, 53);
            this.nhanVienListView.Name = "nhanVienListView";
            this.nhanVienListView.Size = new System.Drawing.Size(1051, 310);
            this.nhanVienListView.TabIndex = 0;
            this.nhanVienListView.TabStop = false;
            this.nhanVienListView.UseCompatibleStateImageBehavior = false;
            this.nhanVienListView.View = System.Windows.Forms.View.Details;
            // 
            // btnUpdateNhanVien
            // 
            this.btnUpdateNhanVien.AutoSize = true;
            this.btnUpdateNhanVien.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnUpdateNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateNhanVien.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateNhanVien.Location = new System.Drawing.Point(720, 3);
            this.btnUpdateNhanVien.Name = "btnUpdateNhanVien";
            this.btnUpdateNhanVien.Size = new System.Drawing.Size(79, 44);
            this.btnUpdateNhanVien.TabIndex = 11;
            this.btnUpdateNhanVien.Text = "Update";
            this.btnUpdateNhanVien.UseVisualStyleBackColor = false;
            this.btnUpdateNhanVien.Click += new System.EventHandler(this.btnUpdateNhanVien_Click);
            // 
            // muonTraTab
            // 
            this.muonTraTab.Controls.Add(this.tableLayoutPanelMuonTra);
            this.muonTraTab.Location = new System.Drawing.Point(4, 25);
            this.muonTraTab.Name = "muonTraTab";
            this.muonTraTab.Padding = new System.Windows.Forms.Padding(3);
            this.muonTraTab.Size = new System.Drawing.Size(1063, 372);
            this.muonTraTab.TabIndex = 3;
            this.muonTraTab.Text = "Mượn trả";
            this.muonTraTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMuonTra
            // 
            this.tableLayoutPanelMuonTra.ColumnCount = 8;
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMuonTra.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMuonTra.Controls.Add(this.btnReloadMuonTra, 7, 0);
            this.tableLayoutPanelMuonTra.Controls.Add(this.btnImportMuonTra, 1, 0);
            this.tableLayoutPanelMuonTra.Controls.Add(this.btnDeleteMuonTra, 5, 0);
            this.tableLayoutPanelMuonTra.Controls.Add(this.btnAddMuonTra, 6, 0);
            this.tableLayoutPanelMuonTra.Controls.Add(this.btnExportMuonTra, 0, 0);
            this.tableLayoutPanelMuonTra.Controls.Add(this.muonTraListView, 0, 1);
            this.tableLayoutPanelMuonTra.Controls.Add(this.btnUpdateMuonTra, 4, 0);
            this.tableLayoutPanelMuonTra.Controls.Add(this.comboBoxHienThi, 3, 0);
            this.tableLayoutPanelMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMuonTra.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMuonTra.Name = "tableLayoutPanelMuonTra";
            this.tableLayoutPanelMuonTra.RowCount = 2;
            this.tableLayoutPanelMuonTra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMuonTra.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMuonTra.Size = new System.Drawing.Size(1057, 366);
            this.tableLayoutPanelMuonTra.TabIndex = 2;
            // 
            // btnReloadMuonTra
            // 
            this.btnReloadMuonTra.AutoSize = true;
            this.btnReloadMuonTra.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnReloadMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReloadMuonTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadMuonTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReloadMuonTra.Location = new System.Drawing.Point(975, 3);
            this.btnReloadMuonTra.Name = "btnReloadMuonTra";
            this.btnReloadMuonTra.Size = new System.Drawing.Size(79, 44);
            this.btnReloadMuonTra.TabIndex = 13;
            this.btnReloadMuonTra.Text = "Reload";
            this.btnReloadMuonTra.UseVisualStyleBackColor = false;
            // 
            // btnImportMuonTra
            // 
            this.btnImportMuonTra.AutoSize = true;
            this.btnImportMuonTra.BackColor = System.Drawing.Color.Blue;
            this.btnImportMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportMuonTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportMuonTra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnImportMuonTra.Location = new System.Drawing.Point(88, 3);
            this.btnImportMuonTra.Name = "btnImportMuonTra";
            this.btnImportMuonTra.Size = new System.Drawing.Size(79, 44);
            this.btnImportMuonTra.TabIndex = 10;
            this.btnImportMuonTra.Text = "Import";
            this.btnImportMuonTra.UseVisualStyleBackColor = false;
            this.btnImportMuonTra.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnDeleteMuonTra
            // 
            this.btnDeleteMuonTra.AutoSize = true;
            this.btnDeleteMuonTra.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnDeleteMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteMuonTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMuonTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteMuonTra.Location = new System.Drawing.Point(805, 3);
            this.btnDeleteMuonTra.Name = "btnDeleteMuonTra";
            this.btnDeleteMuonTra.Size = new System.Drawing.Size(79, 44);
            this.btnDeleteMuonTra.TabIndex = 10;
            this.btnDeleteMuonTra.Text = "Delete";
            this.btnDeleteMuonTra.UseVisualStyleBackColor = false;
            this.btnDeleteMuonTra.Click += new System.EventHandler(this.btnDeleteMuonTra_Click);
            // 
            // btnAddMuonTra
            // 
            this.btnAddMuonTra.AutoSize = true;
            this.btnAddMuonTra.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnAddMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddMuonTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMuonTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddMuonTra.Location = new System.Drawing.Point(890, 3);
            this.btnAddMuonTra.Name = "btnAddMuonTra";
            this.btnAddMuonTra.Size = new System.Drawing.Size(79, 44);
            this.btnAddMuonTra.TabIndex = 8;
            this.btnAddMuonTra.Text = "Add";
            this.btnAddMuonTra.UseVisualStyleBackColor = false;
            this.btnAddMuonTra.Click += new System.EventHandler(this.btnAddMuonTra_Click);
            // 
            // btnExportMuonTra
            // 
            this.btnExportMuonTra.AutoSize = true;
            this.btnExportMuonTra.BackColor = System.Drawing.Color.Blue;
            this.btnExportMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportMuonTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMuonTra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportMuonTra.Location = new System.Drawing.Point(3, 3);
            this.btnExportMuonTra.Name = "btnExportMuonTra";
            this.btnExportMuonTra.Size = new System.Drawing.Size(79, 44);
            this.btnExportMuonTra.TabIndex = 10;
            this.btnExportMuonTra.Text = "Export";
            this.btnExportMuonTra.UseVisualStyleBackColor = false;
            this.btnExportMuonTra.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // muonTraListView
            // 
            this.tableLayoutPanelMuonTra.SetColumnSpan(this.muonTraListView, 8);
            this.muonTraListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muonTraListView.FullRowSelect = true;
            this.muonTraListView.GridLines = true;
            this.muonTraListView.HideSelection = false;
            this.muonTraListView.Location = new System.Drawing.Point(3, 53);
            this.muonTraListView.Name = "muonTraListView";
            this.muonTraListView.Size = new System.Drawing.Size(1051, 310);
            this.muonTraListView.TabIndex = 0;
            this.muonTraListView.TabStop = false;
            this.muonTraListView.UseCompatibleStateImageBehavior = false;
            this.muonTraListView.View = System.Windows.Forms.View.Details;
            // 
            // btnUpdateMuonTra
            // 
            this.btnUpdateMuonTra.AutoSize = true;
            this.btnUpdateMuonTra.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnUpdateMuonTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateMuonTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMuonTra.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateMuonTra.Location = new System.Drawing.Point(720, 3);
            this.btnUpdateMuonTra.Name = "btnUpdateMuonTra";
            this.btnUpdateMuonTra.Size = new System.Drawing.Size(79, 44);
            this.btnUpdateMuonTra.TabIndex = 11;
            this.btnUpdateMuonTra.Text = "Update";
            this.btnUpdateMuonTra.UseVisualStyleBackColor = false;
            this.btnUpdateMuonTra.Click += new System.EventHandler(this.btnUpdateMuonTra_Click);
            // 
            // comboBoxHienThi
            // 
            this.comboBoxHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHienThi.DropDownWidth = 400;
            this.comboBoxHienThi.FormattingEnabled = true;
            this.comboBoxHienThi.Location = new System.Drawing.Point(570, 14);
            this.comboBoxHienThi.Name = "comboBoxHienThi";
            this.comboBoxHienThi.Size = new System.Drawing.Size(144, 24);
            this.comboBoxHienThi.TabIndex = 14;
            this.comboBoxHienThi.SelectedIndexChanged += new System.EventHandler(this.comboBoxHienThi_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1071, 106);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(280, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý thư viện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabThuVien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1071, 401);
            this.panel3.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 556);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabThuVien.ResumeLayout(false);
            this.sachTab.ResumeLayout(false);
            this.tableLayoutPanelSach.ResumeLayout(false);
            this.tableLayoutPanelSach.PerformLayout();
            this.docGiaTab.ResumeLayout(false);
            this.tableLayoutPanelDocGia.ResumeLayout(false);
            this.tableLayoutPanelDocGia.PerformLayout();
            this.nhanVienTab.ResumeLayout(false);
            this.tableLayoutPanelNhanVien.ResumeLayout(false);
            this.tableLayoutPanelNhanVien.PerformLayout();
            this.muonTraTab.ResumeLayout(false);
            this.tableLayoutPanelMuonTra.ResumeLayout(false);
            this.tableLayoutPanelMuonTra.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPhanQuyen;
        private System.Windows.Forms.TabControl tabThuVien;
        private System.Windows.Forms.TabPage sachTab;
        private System.Windows.Forms.TabPage docGiaTab;
        private System.Windows.Forms.TabPage nhanVienTab;
        private System.Windows.Forms.TabPage muonTraTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDocGia;
        private System.Windows.Forms.Button btnImportDocGia;
        private System.Windows.Forms.Button btnDeleteDocGia;
        private System.Windows.Forms.Button btnAddDocGia;
        private System.Windows.Forms.Button btnExportDocGia;
        private System.Windows.Forms.ListView docGiaListView;
        private System.Windows.Forms.Button btnUpdateDocGia;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelNhanVien;
        private System.Windows.Forms.Button btnImportNhanVien;
        private System.Windows.Forms.Button btnDeleteNhanVien;
        private System.Windows.Forms.Button btnAddNhanVien;
        private System.Windows.Forms.Button btnExportNhanVien;
        private System.Windows.Forms.ListView nhanVienListView;
        private System.Windows.Forms.Button btnUpdateNhanVien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMuonTra;
        private System.Windows.Forms.Button btnImportMuonTra;
        private System.Windows.Forms.Button btnDeleteMuonTra;
        private System.Windows.Forms.Button btnAddMuonTra;
        private System.Windows.Forms.Button btnExportMuonTra;
        private System.Windows.Forms.ListView muonTraListView;
        private System.Windows.Forms.Button btnUpdateMuonTra;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSach;
        private System.Windows.Forms.Button btnUpdateSach;
        private System.Windows.Forms.Button btnImportSach;
        private System.Windows.Forms.Button btnDeleteSach;
        private System.Windows.Forms.Button btnReloadSach;
        private System.Windows.Forms.Button btnExportSach;
        private System.Windows.Forms.ListView sachListView;
        private System.Windows.Forms.Button btnAddSach;
        private System.Windows.Forms.Button btnReloadDocGia;
        private System.Windows.Forms.Button btnReloadNhanVien;
        private System.Windows.Forms.Button btnReloadMuonTra;
        private System.Windows.Forms.ComboBox comboBoxHienThi;
    }
}