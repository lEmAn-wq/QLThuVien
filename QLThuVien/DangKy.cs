using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class DangKy : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-SMMDH16\SQLEXPRESS;Initial Catalog=ql_tv;User ID=sa;Password=sa";
        //private readonly string connectionString = @"Data Source=A208PC16\CSSQL08;Initial Catalog=ql_tv;User ID=sa;Password=sa";

        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string[] arrayInfo = { txtTenTK.Text, txtMK.Text, txtNhapLaiMK.Text, txtUserName.Text };

            if (!Program.CheckStringArrayTrue(arrayInfo))
            {
                MessageBox.Show("Có phần tử rỗng. Vui lòng nhập đầy đủ thông tin!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (arrayInfo[2] != arrayInfo[1])
            {
                MessageBox.Show("Mật khẩu nhập lại sai. Vui lòng nhập lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_CreateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@LoginName", arrayInfo[0]);
                        cmd.Parameters.AddWithValue("@Password", arrayInfo[1]);
                        cmd.Parameters.AddWithValue("@UserName", arrayInfo[3]);

                        // Thêm tham số trả về
                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add(returnValue);

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();

                        // Lấy giá trị trả về
                        int result = (int)returnValue.Value;

                        // Kiểm tra kết quả trả về
                        if (result > 0)
                        {
                            MessageBox.Show("Tài khoản đã được tạo và phân quyền thành công!", "Thông báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Login hoặc User đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
