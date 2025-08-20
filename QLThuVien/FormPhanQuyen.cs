using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace QUANLYTHUVIEN
{
    public partial class FormPhanQuyen : Form
    {
        string connectionString;
        public FormPhanQuyen(string conn)
        {
            InitializeComponent();
            connectionString = conn;
            LoadUsers();
        }

        private void LoadUsers()
        {
            string query = "SELECT name FROM dbo.fn_GetActiveUsers();";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        // Đưa dữ liệu vào ComboBox
                        comboBoxUser.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxUser.Items.Add(reader["name"].ToString());
                        }

                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btn_XoaNguoiDung_Click(object sender, EventArgs e)
        {
            // Lấy tên người dùng từ ComboBox
            string userName = comboBoxUser.SelectedItem.ToString();

            // Kết nối đến SQL Server
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Tạo lệnh SQL để gọi thủ tục
                    using (SqlCommand cmd = new SqlCommand("sp_RemoveUserFromDatabase", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        // Thêm tham số vào thủ tục
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Người dùng đã được xóa thành công.");
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
        private void btn_TaoNguoiDung_Click(object sender, EventArgs e)
        {
            string userName = txt_TenUser.Text;  // Lấy tên người dùng từ TextBox

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo đối tượng SqlCommand để gọi thủ tục
                    using (SqlCommand cmd = new SqlCommand("sp_TaoUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số vào thủ tục
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        // Thực thi thủ tục
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Người dùng đã được tạo thành công.");
                        LoadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


       

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo SqlConnection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    bool isQuyenSelectChecked = checkedListBoxQuyen.GetItemChecked(0);
                    bool isQuyenInsertChecked = checkedListBoxQuyen.GetItemChecked(1);
                    bool isQuyenAllChecked = checkedListBoxNhomQuyen.GetItemChecked(0);

                    // Mở kết nối
                    conn.Open();

                    // Khởi tạo SqlCommand để gọi stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_AddOrUpdateUserPermissions", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số vào stored procedure
                        cmd.Parameters.AddWithValue("@UserName", comboBoxUser.SelectedItem.ToString());  
                        cmd.Parameters.AddWithValue("@QuyenSelect", isQuyenSelectChecked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@QuyenInsert", isQuyenInsertChecked ? 1 : 0); 
                        cmd.Parameters.AddWithValue("@QuyenAll", isQuyenAllChecked ? 1 : 0);  

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();

                        // Hiển thị thông báo sau khi thực hiện
                        MessageBox.Show("Quyền của người dùng đã được cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có user nào được chọn trong ComboBox không
                if (comboBoxUser.SelectedItem != null)
                {
                    string selectedUser = comboBoxUser.SelectedItem.ToString();  // Lấy tên người dùng đã chọn

                    // Khởi tạo SqlConnection
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Truy vấn quyền của người dùng từ bảng QuyenNguoiDung
                        string query = "SELECT QuyenSelect, QuyenInsert, QuyenAll FROM QuyenNguoiDung WHERE UserName = @UserName";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserName", selectedUser);

                            // Đọc kết quả truy vấn
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    bool quyenSelect = reader.GetBoolean(0);  // QuyenSelect
                                    bool quyenInsert = reader.GetBoolean(1);  // QuyenInsert
                                    bool quyenAll = reader.GetBoolean(2);     // QuyenAll

                                    // Cập nhật CheckedListBox
                                    checkedListBoxQuyen.SetItemChecked(0, quyenSelect);  
                                    checkedListBoxQuyen.SetItemChecked(1, quyenInsert);  
                                    checkedListBoxNhomQuyen.SetItemChecked(0, quyenAll); 
                                }
                                else
                                {
                                    // Nếu không tìm thấy quyền, bỏ chọn tất cả
                                    checkedListBoxQuyen.SetItemChecked(0, false);
                                    checkedListBoxQuyen.SetItemChecked(1, false);
                                    checkedListBoxNhomQuyen.SetItemChecked(0, false);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

    }
}
