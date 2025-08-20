using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using DevExpress.Utils.Serializing;
namespace QUANLYTHUVIEN
{
    public partial class LuuMuonTraForm : Form
    {
        private bool themMoiMuonTra = true;

        private int maMuonTra = 0;
        private MainForm mainForm;

        public LuuMuonTraForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            txtNgayTra.Visible = false;
        }

        public void CapNhatMuonTra(int maMuonTra, int maSach, int maDG, int maNV, string ngayMuon, string ngayTra)
        {
            txtNgayTra.Visible = true;

            this.maMuonTra = maMuonTra;
            txtMaSach.Text = maSach.ToString();
            txtMaDocGia.Text = maDG.ToString();
            txtMaNhanVien.Text = maNV.ToString();
            txtNgayMuon.Text = ngayMuon;
            txtNgayTra.Text = ngayTra;
            btnLuuMuonTra.Text = "UPDATE";
            themMoiMuonTra = false;
        }

        private void btnLuuMuonTra_Click(object sender, System.EventArgs e)
        {
            DateTime? ngayTra = null; // Sử dụng Nullable<DateTime>

            // Kiểm tra nếu txtNgayTra có giá trị
            if (!string.IsNullOrEmpty(txtNgayTra.Text))
            {
                // Chỉ phân tích nếu có giá trị
                if (DateTime.TryParse(txtNgayTra.Text, out DateTime parsedDate))
                {
                    ngayTra = parsedDate; // Gán giá trị cho ngayTra
                }
                else
                {
                    MessageBox.Show("Ngày trả không hợp lệ.");
                    return;
                }
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(mainForm.GetStrConn))
                {
                    conn.Open();
                    int ketqua = 0;
                    if (themMoiMuonTra)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_ThemMuonTra", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MASACH", txtMaSach.Text);
                            cmd.Parameters.AddWithValue("@MADG", txtMaDocGia.Text);
                            cmd.Parameters.AddWithValue("@MANV", txtMaNhanVien.Text);
                            cmd.Parameters.AddWithValue("@NGAYMUON", DateTime.Parse(txtNgayMuon.Text));

                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_CapNhatMuonTra", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@MAMUONTRA", maMuonTra);
                            cmd.Parameters.AddWithValue("@MASACH", txtMaSach.Text);
                            cmd.Parameters.AddWithValue("@MADG", txtMaDocGia.Text);
                            cmd.Parameters.AddWithValue("@MANV", txtMaNhanVien.Text);
                            cmd.Parameters.AddWithValue("@NGAYMUON", DateTime.Parse(txtNgayMuon.Text));
                            cmd.Parameters.AddWithValue("@NGAYTRA", (object)ngayTra ?? DBNull.Value); // Nếu ngayTra là null, truyền DBNull.Value


                            ketqua = cmd.ExecuteNonQuery();

                        }
                    }

                    if (ketqua > 0)
                    {
                        mainForm.TaiDuLieuLenDanhSachMuonTra();
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
