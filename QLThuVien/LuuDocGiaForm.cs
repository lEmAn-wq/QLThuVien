using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
namespace QUANLYTHUVIEN
{
    public partial class LuuDocGiaForm : Form
    {
        private bool themMoiDocGia = true;
        private int maDocGia = 0;
        private MainForm mainForm;
        public LuuDocGiaForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void CapNhatDocGia(int maDocGia, string tenDocGia, string diaChi, string dienThoai)
        {
            this.maDocGia = maDocGia;
            txtTenDocGia.Text = tenDocGia;
            txtDiaChi.Text = diaChi;
            txtDienThoai.Text = dienThoai;
            btnLuuDocGia.Text = "UPDATE";
            themMoiDocGia = false;
        }

        private void btnLuuDocGia_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(mainForm.GetStrConn))
                {
                    conn.Open();
                    int ketqua = 0;
                    if (themMoiDocGia)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ThemDocGia", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TENDG", txtTenDocGia.Text);
                            cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@DIENTHOAI", txtDienThoai.Text);

                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CapNhatDocGia", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MADG", maDocGia);
                            cmd.Parameters.AddWithValue("@TENDG", txtTenDocGia.Text);
                            cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                            cmd.Parameters.AddWithValue("@DIENTHOAI", txtDienThoai.Text);

                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }

                    if (ketqua > 0)
                    {
                        mainForm.TaiDuLieuLenDanhSachDocGia();
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
