using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
namespace QUANLYTHUVIEN
{
    public partial class LuuSachForm : Form
    {
        private bool themMoiSach = true;
        private int maSach = 0;
        private MainForm mainForm;
        public LuuSachForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void CapNhatSach(int maSach,string tenSach, string tacGia, string theLoai, string nhaXuatBan, int namXuatBan)
        {
            this.maSach = maSach;
            txtTenSach.Text = tenSach;
            txtTacGia.Text = tacGia;
            txtTheLoai.Text = theLoai;
            txtNhaXuatBan.Text = nhaXuatBan;
            txtNamXuatBan.Text = namXuatBan.ToString();
            btnLuuSach.Text = "UPDATE";
            themMoiSach = false;
        }

        private void btnLuuSach_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(mainForm.GetStrConn))
                {
                    conn.Open();
                    int ketqua = 0;
                    if (themMoiSach)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ThemSach", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TENSACH", txtTenSach.Text);
                            cmd.Parameters.AddWithValue("@TACGIA", txtTacGia.Text);
                            cmd.Parameters.AddWithValue("@THELOAI", txtTheLoai.Text);
                            cmd.Parameters.AddWithValue("@NAMXUATBAN", int.Parse(txtNamXuatBan.Text));
                            cmd.Parameters.AddWithValue("@NHAXUATBAN", txtNhaXuatBan.Text);

                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CapNhatSach", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MASACH", maSach);
                            cmd.Parameters.AddWithValue("@TENSACH", txtTenSach.Text);
                            cmd.Parameters.AddWithValue("@TACGIA", txtTacGia.Text);
                            cmd.Parameters.AddWithValue("@THELOAI", txtTheLoai.Text);
                            cmd.Parameters.AddWithValue("@NAMXUATBAN", int.Parse(txtNamXuatBan.Text));
                            cmd.Parameters.AddWithValue("@NHAXUATBAN", txtNhaXuatBan.Text);

                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }

                    if (ketqua > 0)
                    {
                        mainForm.TaiDuLieuLenDanhSachSach();
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
