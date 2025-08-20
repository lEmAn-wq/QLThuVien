namespace QUANLYTHUVIEN
{
    partial class FormPhanQuyen
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
            this.btn_TaoNguoiDung = new System.Windows.Forms.Button();
            this.btn_XoaNguoiDung = new System.Windows.Forms.Button();
            this.grboxUser = new System.Windows.Forms.GroupBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.groupBoxQuyen = new System.Windows.Forms.GroupBox();
            this.checkedListBoxQuyen = new System.Windows.Forms.CheckedListBox();
            this.groupBoxNhomQuyen = new System.Windows.Forms.GroupBox();
            this.checkedListBoxNhomQuyen = new System.Windows.Forms.CheckedListBox();
            this.txt_TenUser = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.grboxUser.SuspendLayout();
            this.groupBoxQuyen.SuspendLayout();
            this.groupBoxNhomQuyen.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_TaoNguoiDung
            // 
            this.btn_TaoNguoiDung.AutoSize = true;
            this.btn_TaoNguoiDung.Location = new System.Drawing.Point(354, 191);
            this.btn_TaoNguoiDung.Margin = new System.Windows.Forms.Padding(5);
            this.btn_TaoNguoiDung.Name = "btn_TaoNguoiDung";
            this.btn_TaoNguoiDung.Size = new System.Drawing.Size(155, 41);
            this.btn_TaoNguoiDung.TabIndex = 3;
            this.btn_TaoNguoiDung.Text = "Tạo người dùng";
            this.btn_TaoNguoiDung.UseVisualStyleBackColor = true;
            this.btn_TaoNguoiDung.Click += new System.EventHandler(this.btn_TaoNguoiDung_Click);
            // 
            // btn_XoaNguoiDung
            // 
            this.btn_XoaNguoiDung.AutoSize = true;
            this.btn_XoaNguoiDung.Location = new System.Drawing.Point(354, 71);
            this.btn_XoaNguoiDung.Margin = new System.Windows.Forms.Padding(5);
            this.btn_XoaNguoiDung.Name = "btn_XoaNguoiDung";
            this.btn_XoaNguoiDung.Size = new System.Drawing.Size(155, 41);
            this.btn_XoaNguoiDung.TabIndex = 4;
            this.btn_XoaNguoiDung.Text = "Xóa người dùng";
            this.btn_XoaNguoiDung.UseVisualStyleBackColor = true;
            this.btn_XoaNguoiDung.Click += new System.EventHandler(this.btn_XoaNguoiDung_Click);
            // 
            // grboxUser
            // 
            this.grboxUser.Controls.Add(this.comboBoxUser);
            this.grboxUser.Location = new System.Drawing.Point(20, 42);
            this.grboxUser.Margin = new System.Windows.Forms.Padding(5);
            this.grboxUser.Name = "grboxUser";
            this.grboxUser.Padding = new System.Windows.Forms.Padding(5);
            this.grboxUser.Size = new System.Drawing.Size(313, 97);
            this.grboxUser.TabIndex = 5;
            this.grboxUser.TabStop = false;
            this.grboxUser.Text = "User";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(5, 28);
            this.comboBoxUser.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(303, 31);
            this.comboBoxUser.TabIndex = 1;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            // 
            // groupBoxQuyen
            // 
            this.groupBoxQuyen.Controls.Add(this.checkedListBoxQuyen);
            this.groupBoxQuyen.Location = new System.Drawing.Point(25, 266);
            this.groupBoxQuyen.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxQuyen.Name = "groupBoxQuyen";
            this.groupBoxQuyen.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxQuyen.Size = new System.Drawing.Size(333, 177);
            this.groupBoxQuyen.TabIndex = 6;
            this.groupBoxQuyen.TabStop = false;
            this.groupBoxQuyen.Text = "Quyền";
            // 
            // checkedListBoxQuyen
            // 
            this.checkedListBoxQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxQuyen.FormattingEnabled = true;
            this.checkedListBoxQuyen.Items.AddRange(new object[] {
            "Select",
            "Insert"});
            this.checkedListBoxQuyen.Location = new System.Drawing.Point(5, 28);
            this.checkedListBoxQuyen.Margin = new System.Windows.Forms.Padding(5);
            this.checkedListBoxQuyen.Name = "checkedListBoxQuyen";
            this.checkedListBoxQuyen.Size = new System.Drawing.Size(323, 144);
            this.checkedListBoxQuyen.TabIndex = 2;
            // 
            // groupBoxNhomQuyen
            // 
            this.groupBoxNhomQuyen.Controls.Add(this.checkedListBoxNhomQuyen);
            this.groupBoxNhomQuyen.Location = new System.Drawing.Point(468, 266);
            this.groupBoxNhomQuyen.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxNhomQuyen.Name = "groupBoxNhomQuyen";
            this.groupBoxNhomQuyen.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxNhomQuyen.Size = new System.Drawing.Size(333, 177);
            this.groupBoxNhomQuyen.TabIndex = 7;
            this.groupBoxNhomQuyen.TabStop = false;
            this.groupBoxNhomQuyen.Text = "Nhóm quyền";
            // 
            // checkedListBoxNhomQuyen
            // 
            this.checkedListBoxNhomQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxNhomQuyen.FormattingEnabled = true;
            this.checkedListBoxNhomQuyen.Items.AddRange(new object[] {
            "Quyền select, insert, update, delete"});
            this.checkedListBoxNhomQuyen.Location = new System.Drawing.Point(5, 28);
            this.checkedListBoxNhomQuyen.Margin = new System.Windows.Forms.Padding(5);
            this.checkedListBoxNhomQuyen.Name = "checkedListBoxNhomQuyen";
            this.checkedListBoxNhomQuyen.Size = new System.Drawing.Size(323, 144);
            this.checkedListBoxNhomQuyen.TabIndex = 3;
            // 
            // txt_TenUser
            // 
            this.txt_TenUser.Location = new System.Drawing.Point(20, 196);
            this.txt_TenUser.Margin = new System.Windows.Forms.Padding(5);
            this.txt_TenUser.Name = "txt_TenUser";
            this.txt_TenUser.Size = new System.Drawing.Size(301, 30);
            this.txt_TenUser.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.AutoSize = true;
            this.btn_Save.Location = new System.Drawing.Point(325, 466);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(153, 41);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "Lưu thay đổi";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // FormPhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 522);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_TenUser);
            this.Controls.Add(this.groupBoxNhomQuyen);
            this.Controls.Add(this.groupBoxQuyen);
            this.Controls.Add(this.grboxUser);
            this.Controls.Add(this.btn_XoaNguoiDung);
            this.Controls.Add(this.btn_TaoNguoiDung);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormPhanQuyen";
            this.Text = "FormPhanQuyen";
            this.grboxUser.ResumeLayout(false);
            this.groupBoxQuyen.ResumeLayout(false);
            this.groupBoxNhomQuyen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_TaoNguoiDung;
        private System.Windows.Forms.Button btn_XoaNguoiDung;
        private System.Windows.Forms.GroupBox grboxUser;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.GroupBox groupBoxQuyen;
        private System.Windows.Forms.CheckedListBox checkedListBoxQuyen;
        private System.Windows.Forms.GroupBox groupBoxNhomQuyen;
        private System.Windows.Forms.CheckedListBox checkedListBoxNhomQuyen;
        private System.Windows.Forms.TextBox txt_TenUser;
        private System.Windows.Forms.Button btn_Save;
    }
}