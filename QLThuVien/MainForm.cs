using DevExpress.Xpo.DB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class MainForm: Form
    {
        private const string TenBangSach = "SACH";
        private const string TenBangDocGia = "DOCGIA";
        private const string TenBangNhanVien = "NHANVIEN";
        private const string TenBangMuonTra = "MUONTRA";
        
        DangNhap dangNhap;
        public string GetStrConn { get { return dangNhap.GetUserConnectionString; } }

        //Phuong thuc khoi tao
       
        public MainForm(DangNhap frmDangNhap)
        {
            dangNhap=frmDangNhap;
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        //setup
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "UserName: " + dangNhap.GetUserName;
            if(dangNhap.GetUserName!="dbo")
            {
                btnPhanQuyen.Enabled = false;
            }
            else
            {
                btnPhanQuyen.Enabled = true;
            }

            ConfigureComboBoxHienThi();
        }

        private void ConfigureComboBoxHienThi()
        {
            CauHinhDanhSach(sachListView, TenBangSach);
            TaiDuLieuLenDanhSachSach();

            CauHinhDanhSach(docGiaListView, TenBangDocGia);
            TaiDuLieuLenDanhSachDocGia();

            CauHinhDanhSach(muonTraListView, TenBangMuonTra);
            TaiDuLieuLenDanhSachMuonTra();

            CauHinhDanhSach(nhanVienListView, TenBangNhanVien);
            TaiDuLieuLenDanhSachNhanVien();


            //btnImportSach.Visible = btnUpdateSach.Visible = btnAddSach.Visible = btnDeleteSach.Visible = btnPhanQuyen.Visible = false;
            //tabThuVien.TabPages.Remove(docGiaTab);
            //tabThuVien.TabPages.Remove(nhanVienTab);
            //tabThuVien.TabPages.Remove(muonTraTab);

            //if (dangNhap.GetRoleName != "Users")
            //{
            //    CauHinhDanhSach(docGiaListView, TenBangDocGia);
            //    CauHinhDanhSach(muonTraListView, TenBangMuonTra);

            //    TaiDuLieuLenDanhSachDocGia();
            //    TaiDuLieuLenDanhSachMuonTra();

            //    btnImportSach.Visible = btnUpdateSach.Visible = btnAddSach.Visible = btnDeleteSach.Visible = true;
            //    btnYeuCau.Visible = false;

            //    tabThuVien.TabPages.Add(docGiaTab);
            //    tabThuVien.TabPages.Add(muonTraTab);


            //    if (dangNhap.GetRoleName == "db_owner")
            //    {
            //        CauHinhDanhSach(nhanVienListView, TenBangNhanVien);
            //        TaiDuLieuLenDanhSachNhanVien();
            //        btnPhanQuyen.Visible = true;

            //        tabThuVien.TabPages.Add(nhanVienTab);
            //    }
            //}
        }

        private void CauHinhDanhSach(ListView listView, string tableName)
        {
            listView.Columns.Clear();

            switch (tableName)
            {
                case TenBangSach:
                    listView.Columns.Add("MASACH", 100);
                    listView.Columns.Add("TENSACH", 200);
                    listView.Columns.Add("TACGIA", 150);
                    listView.Columns.Add("THELOAI", 100);
                    listView.Columns.Add("NAMXUATBAN", 100);
                    listView.Columns.Add("NHAXUATBAN", 150);
                    break;

                case TenBangDocGia:
                    listView.Columns.Add("MADG", 100);
                    listView.Columns.Add("TENDG", 150);
                    listView.Columns.Add("DIACHI", 200);
                    listView.Columns.Add("DIENTHOAI", 150);
                    break;

                case "showMuonTra":
                case TenBangMuonTra:
                    listView.Columns.Add("MAMUONTRA", 100);
                    listView.Columns.Add("MASACH", 100);
                    listView.Columns.Add("MADG", 100);
                    listView.Columns.Add("MANV", 100);
                    listView.Columns.Add("NGAYMUON", 150);
                    listView.Columns.Add("NGAYTRA", 150);
                    break;

                case TenBangNhanVien:
                    listView.Columns.Add("MANV", 100);
                    listView.Columns.Add("TENNV", 150);
                    listView.Columns.Add("CHUCVU", 150);
                    listView.Columns.Add("DIENTHOAINV", 150);
                    listView.Columns.Add("NGAYVAOLAM", 150);
                    break;
                    //-----------------------------------
                case "showMaxNV":
                    listView.Columns.Add("MANV", 100);
                    listView.Columns.Add("TENNV", 150);
                    listView.Columns.Add("CHUCVU", 150);
                    listView.Columns.Add("DIENTHOAINV", 150);
                    listView.Columns.Add("NGAYVAOLAM", 150);
                    listView.Columns.Add("TONTAI", 100);
                    listView.Columns.Add("SoLanChoMuon", 100);
                    break;

                case "showMaxDG":
                    listView.Columns.Add("MADG", 100);
                    listView.Columns.Add("TENDG", 150);
                    listView.Columns.Add("DIACHI", 200);
                    listView.Columns.Add("DIENTHOAI", 150);
                    listView.Columns.Add("TONTAI", 100);
                    listView.Columns.Add("SoLanMuon", 100);

                    break;

                case "showMaxSach":
                    listView.Columns.Add("MASACH", 100);
                    listView.Columns.Add("TENSACH", 200);
                    listView.Columns.Add("TACGIA", 150);
                    listView.Columns.Add("THELOAI", 100);
                    listView.Columns.Add("NAMXUATBAN", 100);
                    listView.Columns.Add("NHAXUATBAN", 150);
                    listView.Columns.Add("TONTAI", 100);
                    listView.Columns.Add("SoLanMuon", 100);
                    break;

            }
        }
        private void TaiDuLieuLenDanhSach(ListView listView, string tableName)
        {
            try
            {
                string query=null;

                switch (tableName)
                {
                    case TenBangSach:
                    case TenBangDocGia:
                    case TenBangNhanVien:
                        query = $"SELECT * FROM vw_{tableName}ConTonTai";
                        break;

                    case "showMuonTra":
                    case TenBangMuonTra:
                        query = $"SELECT * FROM {tableName}";
                        break;

                    case "showMaxNV":
                        query = "select* from vw_NhanVienChoMuonNhieuNhat";
                        break;

                    case "showMaxDG":
                        query = "select* from vw_DocGiaMuonNhieuNhat";
                        break;

                    case "showMaxSach":
                        query = "select* from vw_SachDuocMuonNhieuNhat";
                        break;

                    default:
                        MessageBox.Show("Lỗi table name không hợp lệ", "Thông báo");
                        break;
                }

                using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    try
                    {
                        adapter.Fill(dataTable);
                    }
                    catch
                    {
                        return;
                    }

                    listView.Items.Clear();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row[0].ToString());

                        for (int i = 1; i < row.ItemArray.Length; i++)
                        {
                            if (dataTable.Columns[i].DataType == typeof(DateTime))
                            {
                                if (row[i] != DBNull.Value)
                                {
                                    DateTime dateValue = (DateTime)row[i];
                                    item.SubItems.Add(dateValue.ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    item.SubItems.Add(string.Empty);
                                }
                            }
                            else
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                        }

                        listView.Items.Add(item);  // Move this line outside the for loop
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có vấn đề
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo");
            }
        }
        //------------------------------------------------
        private void btnReloadSach_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                switch (clickedButton.Name)
                {
                    case "btnReloadSach":
                        TaiDuLieuLenDanhSachSach();
                        break;
                    case "btnReloadNhanVien":
                        TaiDuLieuLenDanhSachNhanVien();
                        break;
                    case "btnReloadDocGia":
                        TaiDuLieuLenDanhSachDocGia();
                        break;
                    case "btnReloadMuonTra":
                        TaiDuLieuLenDanhSachMuonTra();
                        break;

                    default:
                        MessageBox.Show("Bạn đã nhấn vào nút khác.");
                        break;
                }
            }
        }

        private void comboBoxHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBoxHienThi.SelectedValue.ToString();

            switch (selectedValue)
            {
                case "showMuonTra":
                    CauHinhDanhSach(muonTraListView, "showMuonTra");
                    TaiDuLieuLenDanhSach(muonTraListView, "showMuonTra");
                    break;

                case "showMaxNV":
                    CauHinhDanhSach(muonTraListView, "showMaxNV");
                    TaiDuLieuLenDanhSach(muonTraListView, "showMaxNV");
                    break;

                case "showMaxDG":
                    CauHinhDanhSach(muonTraListView, "showMaxDG");
                    TaiDuLieuLenDanhSach(muonTraListView, "showMaxDG");
                    break;

                case "showMaxSach":
                    CauHinhDanhSach(muonTraListView, "showMaxSach");
                    TaiDuLieuLenDanhSach(muonTraListView, "showMaxSach");
                    break;
            }
        }
        //------------------------------------------------
        public void TaiDuLieuLenDanhSachDocGia()
        {
            TaiDuLieuLenDanhSach(docGiaListView, TenBangDocGia);
        }
        public void TaiDuLieuLenDanhSachSach()
        {
            TaiDuLieuLenDanhSach(sachListView, TenBangSach);
        }
        public void TaiDuLieuLenDanhSachNhanVien()
        {
            TaiDuLieuLenDanhSach(nhanVienListView, TenBangNhanVien);
        }
        public void TaiDuLieuLenDanhSachMuonTra()
        {
            TaiDuLieuLenDanhSach(muonTraListView, TenBangMuonTra);

            // Tạo danh sách KeyValuePair
            var items = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("showMuonTra", "Hiển thị mượn trả"),
                new KeyValuePair<string, string>("showMaxNV", "Hiển thị nhân viên cho mượn sách nhiều nhất"),
                new KeyValuePair<string, string>("showMaxDG", "Hiển thị độc giả mượn sách nhiều nhất"),
                new KeyValuePair<string, string>("showMaxSach", "Hiển thị sách được mượn nhiều nhất")
            };

            // Gán danh sách cho ComboBox
            comboBoxHienThi.DataSource = items;
            comboBoxHienThi.ValueMember = "Key"; // Gán Key là ValueMember
            comboBoxHienThi.DisplayMember = "Value"; // Gán Value là DisplayMember
            comboBoxHienThi.SelectedIndex = 0;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Export
        private void btnExport_Click(object sender, EventArgs e)
        {
            string viewName = null;
            // Kiểm tra xem sender có phải là Button không
            if (sender is Button clickedButton)
            {
                // Gọi phương thức GetQueryBasedOnButtonName và truyền vào Name của button
                viewName = GetQueryBasedOnButtonName(clickedButton.Name);
            }

            if (viewName!=null)
            {
                // Khởi tạo SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Thiết lập bộ lọc cho các định dạng tệp mà BCP hỗ trợ
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
                    saveFileDialog.Title = "Chọn vị trí lưu tệp xuất";

                    // Hiển thị dialog và kiểm tra nếu người dùng đã chọn tệp
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy đường dẫn tệp mà người dùng đã chọn
                        string filePath = saveFileDialog.FileName;

                        // Kiểm tra phần mở rộng tệp và tự động thêm nếu cần
                        if (!filePath.EndsWith(".csv") && !filePath.EndsWith(".txt"))
                        {
                            if (saveFileDialog.FilterIndex == 1) // CSV được chọn
                            {
                                filePath += ".csv";
                            }
                            else if (saveFileDialog.FilterIndex == 2) // TXT được chọn
                            {
                                filePath += ".txt";
                            }
                        }

                        using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                        {
                            try
                            {
                                // Mở kết nối
                                conn.Open();

                                // Tạo SqlCommand để gọi stored procedure
                                using (SqlCommand cmd = new SqlCommand("sp_ExportDataWithBCP", conn))
                                {
                                    // Chỉ định rằng SqlCommand là stored procedure
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    // Truyền tham số tên bảng và đường dẫn file
                                    cmd.Parameters.AddWithValue("@tableName", viewName);
                                    cmd.Parameters.AddWithValue("@filePath", filePath);

                                    // Thực thi stored procedure
                                    cmd.ExecuteNonQuery();

                                    // Thông báo thành công
                                    MessageBox.Show("Dữ liệu đã được xuất ra file " + filePath, "Thông báo");
                                }
                            }
                            catch (Exception ex)
                            {
                                // Hiển thị lỗi nếu có vấn đề
                                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy view nào để xuất dữ liệu.","Thông báo");
            }
        }

        private string GetQueryBasedOnButtonName(string buttonName)
        {
            string viewName = null;

            switch (buttonName)
            {
                case "btnExportSach":
                    viewName = "vw_SachConTonTaiVaCot";
                    break;
                case "btnExportNhanVien":
                    viewName = "vw_NhanVienConTonTaiVaCot";
                    break;
                case "btnExportDocGia":
                    viewName = "vw_DocGiaConTonTaiVaCot";
                    break;
                case "btnExportMuonTra":
                    viewName = "vw_MuonTraVaCot";
                    break;

                case "btnImportSach":
                    viewName = "vw_import_SACH";
                    break;
                case "btnImportDocGia":
                    viewName = "vw_import_DOCGIA";
                    break;
                case "btnImportNhanVien":
                    viewName = "vw_import_NHANVIEN";
                    break;
                case "btnImportMuonTra":
                    viewName = "vw_import_MUONTRA";
                    break;
                    
                default:
                    MessageBox.Show("Bạn đã nhấn vào nút khác.");
                    break;
            }

            return viewName;
        }
        //-----------------------------------------------------------------------------------------------------------------

        //Import
        private void btnImport_Click(object sender, EventArgs e)
        {
            string viewName = null;
            // Kiểm tra xem sender có phải là Button không
            if (sender is Button clickedButton)
            {
                // Gọi phương thức GetQueryBasedOnButtonName và truyền vào Name của button
                viewName = GetQueryBasedOnButtonName(clickedButton.Name);
            }

            if (viewName != null)
            {
                // Khởi tạo OpenFileDialog
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Thiết lập bộ lọc cho các định dạng tệp mà BCP hỗ trợ
                    openFileDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
                    openFileDialog.Title = "Chọn tệp để nhập dữ liệu";

                    // Hiển thị dialog và kiểm tra nếu người dùng đã chọn tệp
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lấy đường dẫn tệp mà người dùng đã chọn
                        string filePath = openFileDialog.FileName;

                        // Kiểm tra phần mở rộng tệp và tự động thêm nếu cần
                        if (!filePath.EndsWith(".csv") && !filePath.EndsWith(".txt"))
                        {
                            if (openFileDialog.FilterIndex == 1) // CSV được chọn
                            {
                                filePath += ".csv";
                            }
                            else if (openFileDialog.FilterIndex == 2) // TXT được chọn
                            {
                                filePath += ".txt";
                            }
                        }

                        using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                        {
                            try
                            {
                                // Mở kết nối
                                conn.Open();

                                // Tạo SqlCommand để gọi stored procedure
                                using (SqlCommand cmd = new SqlCommand("sp_ImportDataWithBCP", conn))
                                {
                                    // Chỉ định rằng SqlCommand là stored procedure
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    // Truyền tham số tên bảng và đường dẫn file
                                    cmd.Parameters.AddWithValue("@tableName", viewName);
                                    cmd.Parameters.AddWithValue("@filePath", filePath);

                                    // Thực thi stored procedure
                                    cmd.ExecuteNonQuery();

                                    // Thông báo thành công
                                    MessageBox.Show("Dữ liệu đã được nhập từ file " + filePath, "Thông báo");
                                }
                            }
                            catch (Exception ex)
                            {
                                // Hiển thị lỗi nếu có vấn đề
                                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy view nào để nhập dữ liệu.", "Thông báo");
            }
        }

        //-----------------------------------------------------------------------------------------------------------------

        //Close 

        private void btnDX_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dangNhap.Show();
                this.Close();
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SMMDH16\\SQLEXPRESS;Initial Catalog=ql_tv1;User ID=sa;Password=sa"))
             {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand để gọi stored procedure
                    using (SqlCommand cmd = new SqlCommand("SP_DangXuat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", this.dangNhap.GetUserName);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo");
                }
            }

            if (dangNhap.Visible==false)
            {
                dangNhap.Close();
            }
        }

        //-----------------------------------------------------------------------------------------------------------------

        //Sach

        private void btnAddSach_Click(object sender, EventArgs e)
        {
            LuuSachForm luuSachForm = new LuuSachForm(this);
            luuSachForm.ShowDialog();
        }

        private void btnUpdateSach_Click(object sender, EventArgs e)
        {
            LuuSachForm luuSachForm = new LuuSachForm(this);
            if (sachListView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = sachListView.SelectedItems[0];

                int maSach = int.Parse(selectedItem.Text);
                string tenSach = selectedItem.SubItems[1].Text;
                string tacGia = selectedItem.SubItems[2].Text;
                string theLoai = selectedItem.SubItems[3].Text;
                int namXuatBan = int.Parse(selectedItem.SubItems[4].Text);
                string nhaXuatBan = selectedItem.SubItems[5].Text;

                luuSachForm.CapNhatSach(maSach, tenSach, tacGia, theLoai, nhaXuatBan, namXuatBan);
                luuSachForm.ShowDialog();
            }
            else if (sachListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn 1 dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSach_Click(object sender, EventArgs e)
        {
            if (sachListView.SelectedItems.Count > 0)
            {
                // Tạo danh sách mã sách cần xóa từ các mục đã chọn trong ListView
                string masachList = string.Join(",", sachListView.SelectedItems.Cast<ListViewItem>().Select(item => item.Text).ToArray());

                using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                {
                    conn.Open();

                    try
                    {
                        // Gọi thủ tục SP_DeleteOrUpdateBooks để xử lý việc xóa hoặc cập nhật trạng thái
                        using (SqlCommand cmd = new SqlCommand("SP_DeleteOrUpdateBooks", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MASACH_LIST", masachList);

                            cmd.ExecuteNonQuery();
                        }

                        TaiDuLieuLenDanhSachSach(); // Tải lại danh sách sau khi xóa
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //DocGia

        private void btnAddDocGia_Click(object sender, EventArgs e)
        {
            LuuDocGiaForm luuDocGiaForm = new LuuDocGiaForm(this);
            luuDocGiaForm.ShowDialog();
        }

        private void btnUpdateDocGia_Click(object sender, EventArgs e)
        {
            LuuDocGiaForm luuDocGiaForm = new LuuDocGiaForm(this);
            if (docGiaListView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = docGiaListView.SelectedItems[0];

                int maDocGia = int.Parse(selectedItem.Text);
                string tenDocGia = selectedItem.SubItems[1].Text;
                string diaChi = selectedItem.SubItems[2].Text;
                string dienThoai = selectedItem.SubItems[3].Text;

                luuDocGiaForm.CapNhatDocGia(maDocGia, tenDocGia, diaChi, dienThoai);
                luuDocGiaForm.ShowDialog();
            }
            else if (docGiaListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn 1 dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteDocGia_Click(object sender, EventArgs e)
        {
            if (docGiaListView.SelectedItems.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction()) // Bắt đầu transaction
                    {
                        try
                        {
                            foreach (ListViewItem selectedItem in docGiaListView.SelectedItems)
                            {
                                int maDocGia = int.Parse(selectedItem.Text);

                                using (SqlCommand cmd = new SqlCommand("SP_CapNhatTonTaiDocGia", conn, transaction))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@MADG", maDocGia);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit(); // Commit transaction nếu thành công
                            TaiDuLieuLenDanhSachDocGia(); // Tải lại danh sách sau khi xóa
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback transaction nếu có lỗi
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                        }
                    }
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //NhanVien

        private void btnAddNhanVien_Click(object sender, EventArgs e)
        {
            LuuNhanVienForm luuNhanVienForm = new LuuNhanVienForm(this);
            luuNhanVienForm.ShowDialog();
        }

        private void btnUpdateNhanVien_Click(object sender, EventArgs e)
        {
            LuuNhanVienForm luuNhanVienForm = new LuuNhanVienForm(this);
            if (nhanVienListView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = nhanVienListView.SelectedItems[0];

                int maNhanVien = int.Parse(selectedItem.Text);
                string tenNhanVien = selectedItem.SubItems[1].Text;
                string chucVu = selectedItem.SubItems[2].Text;
                string dienThoai = selectedItem.SubItems[3].Text;
                string ngayVaoLam = selectedItem.SubItems[4].Text;

                luuNhanVienForm.CapNhatNhanVien(maNhanVien, tenNhanVien, chucVu, dienThoai, ngayVaoLam);
                luuNhanVienForm.ShowDialog();
            }
            else if (nhanVienListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn 1 dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteNhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVienListView.SelectedItems.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction()) // Bắt đầu transaction
                    {
                        try
                        {
                            foreach (ListViewItem selectedItem in nhanVienListView.SelectedItems)
                            {
                                int maNhanVien = int.Parse(selectedItem.Text);

                                using (SqlCommand cmd = new SqlCommand("SP_CapNhatTonTaiNhanVien", conn, transaction))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@MANV", maNhanVien);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit(); // Commit transaction nếu thành công
                            TaiDuLieuLenDanhSachNhanVien(); // Tải lại danh sách sau khi xóa
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback transaction nếu có lỗi
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //-----------------------------------------------------------------------------------------------------------------

        //MuonTra

        private void btnAddMuonTra_Click(object sender, EventArgs e)
        {
            LuuMuonTraForm luuMuonTraForm = new LuuMuonTraForm(this);
            luuMuonTraForm.ShowDialog();
        }

        private void btnUpdateMuonTra_Click(object sender, EventArgs e)
        {
            LuuMuonTraForm luuMuonTraForm = new LuuMuonTraForm(this);
            if (muonTraListView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = muonTraListView.SelectedItems[0];

                int maMuonTra = int.Parse(selectedItem.Text);
                int maSach = int.Parse(selectedItem.SubItems[1].Text);
                int maDocGia = int.Parse(selectedItem.SubItems[2].Text);
                int maNhanVien = int.Parse(selectedItem.SubItems[3].Text);
                string ngayTra = selectedItem.SubItems[5].Text;
                string ngayMuon = selectedItem.SubItems[4].Text;

                luuMuonTraForm.CapNhatMuonTra(maMuonTra, maSach, maDocGia, maNhanVien, ngayMuon, ngayTra);
                luuMuonTraForm.ShowDialog();
            }
            else if (muonTraListView.SelectedItems.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn 1 dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteMuonTra_Click(object sender, EventArgs e)
        {
            if (muonTraListView.SelectedItems.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(dangNhap.GetUserConnectionString))
                {
                    conn.Open();
                    using (SqlTransaction transaction = conn.BeginTransaction()) // Bắt đầu transaction
                    {
                        try
                        {
                            foreach (ListViewItem selectedItem in muonTraListView.SelectedItems)
                            {
                                int maMuonTra = int.Parse(selectedItem.Text);

                                using (SqlCommand cmd = new SqlCommand("SP_XoaMuonTra", conn, transaction))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@MAMUONTRA", maMuonTra);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit(); // Commit transaction nếu thành công
                            TaiDuLieuLenDanhSachMuonTra(); // Tải lại danh sách sau khi xóa
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback(); // Rollback transaction nếu có lỗi
                            MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện chức năng.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            new FormPhanQuyen(GetStrConn).ShowDialog();
        }
    }
}
