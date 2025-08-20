using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class DangNhap : Form
    {
        string userConnectionString, userName, roleName;

        public string GetUserConnectionString { get { return userConnectionString; } }
        public string GetUserName { get { return userName; } }
        public string GetRoleName { get { return roleName; } }

        public DangNhap()
        {
            InitializeComponent();
        }

        private void linkLabelDK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Khởi tạo form đăng ký mới
            DangKy dky = new DangKy();

            //// Hiển thị form đăng ký
            //dky.Show();  // Sử dụng Show nếu muốn form đăng ký mở ra song song với form chính.

            // Hoặc sử dụng ShowDialog nếu muốn form đăng ký là form modal (chỉ thao tác với form đăng ký)
            dky.ShowDialog();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            string loginName = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;

            // Chuỗi kết nối sử dụng tài khoản mà người dùng nhập vào
            userConnectionString = $"Data Source=DESKTOP-SMMDH16\\SQLEXPRESS;Initial Catalog=ql_tv;User ID={loginName};Password={password}";
            //string userConnectionString = $"Data Source=A208PC16\\CSSQL08;Initial Catalog=ql_tv;User ID={loginName};Password={password}";

            try
            {
                bool tonTaiTaiKhoan = false;
                // Kiểm tra xem có kết nối được với SQL Server bằng tài khoản đăng nhập không
                //using (SqlConnection conn = new SqlConnection(userConnectionString))
                //{
                //    conn.Open(); // Mở kết nối
                //}

                // Nếu kết nối thành công, tiếp tục kiểm tra thông tin user và role
                //using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SMMDH16\\SQLEXPRESS;Initial Catalog=ql_tv;User ID=sa;Password=sa"))
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SMMDH16\\SQLEXPRESS;Initial Catalog=ql_tv;User ID=sa;Password=sa"))
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.F_GetUserAndRoleByLogin(@LoginName)", conn))
                    {
                        command.Parameters.AddWithValue("@LoginName", loginName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())  // Kiểm tra nếu có dữ liệu
                            {
                                 userName = reader["UserName"].ToString();
                                roleName = reader["RoleName"].ToString();

                                tonTaiTaiKhoan = true;
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản người dùng không có quyền truy cập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    if (tonTaiTaiKhoan)
                    {
                        bool ketnoi=false;
                        // dang nhap bang chuoi ket noi user va Cap nhat trang thai dang nhap
                        using (SqlCommand cmd = new SqlCommand("SP_DangNhap", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", userName);

                            // Kiểm tra số lượng dòng bị ảnh hưởng
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                // Kết nối tới cơ sở dữ liệu mới
                                using (SqlConnection userConn = new SqlConnection(userConnectionString))
                                {
                                    userConn.Open(); // Mở kết nối
                                                     // Kiểm tra kết nối thành công
                                    if (userConn.State == ConnectionState.Open)
                                    {
                                       ketnoi = true;
                                    }
                                }
                            } 
                        }
                        if (ketnoi)
                        {
                            // Ẩn form đăng nhập và hiển thị form chính
                            this.Hide();
                            new MainForm(this).Show();
                        }
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
