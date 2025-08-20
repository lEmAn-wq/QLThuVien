using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
namespace QUANLYTHUVIEN
{
    public partial class LuuNhanVienForm : Form
    {
        private bool themMoiNhanVien = true;
        private int maNhanVien = 0;
        private MainForm mainForm;
        public LuuNhanVienForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void CapNhatNhanVien(int maNhanVien, string tenNhanVien, string chucVu, string dienThoai, string ngayVaoLam)
        {
            this.maNhanVien = maNhanVien;
            txtTenNhanVien.Text = tenNhanVien;
            txtChucVu.Text = chucVu;
            txtDienThoai.Text = dienThoai;
            txtNgayVaoLam.Text = ngayVaoLam;
            btnLuuNhanVien.Text = "UPDATE";
            themMoiNhanVien = false;
        }

        private void btnLuuNhanVien_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(mainForm.GetStrConn))
                {
                    conn.Open();
                    int ketqua = 0;
                    if (themMoiNhanVien)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ThemNhanVien", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TENNV", txtTenNhanVien.Text);
                            cmd.Parameters.AddWithValue("@CHUCVU", txtChucVu.Text);
                            cmd.Parameters.AddWithValue("@DIENTHOAI", txtDienThoai.Text);
                            cmd.Parameters.AddWithValue("@NGAYVAOLAM", txtNgayVaoLam.Text);

                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CapNhatNhanVien", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MANV", maNhanVien);
                            cmd.Parameters.AddWithValue("@TENNV", txtTenNhanVien.Text);
                            cmd.Parameters.AddWithValue("@CHUCVU", txtChucVu.Text);
                            cmd.Parameters.AddWithValue("@DIENTHOAI", txtDienThoai.Text);
                            cmd.Parameters.AddWithValue("@NGAYVAOLAM", txtNgayVaoLam.Text);
                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }

                    if (ketqua > 0)
                    {
                        mainForm.TaiDuLieuLenDanhSachNhanVien();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Chỉnh sửa thất bại.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Nếu không kết nối được, hiển thị thông báo lỗi
                MessageBox.Show("Đăng nhập thất bại: " + ex.Message, "Thông báo lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
