using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    public partial class MainForm
    {
        private BackgroundWorker backgroundWorker;

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = false
            };

            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker.CancellationPending)
            {
                // Perform status check logic here.
                bool trangThaiDangNhap = KiemTraTrangThaiDangNhap();
                if (!trangThaiDangNhap) // Đã đăng xuất (trangThaiDangNhap = false)
                {
                    e.Result = true; // Indicate that logout is needed
                    break;
                }

                System.Threading.Thread.Sleep(5000);
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && (bool)e.Result == true)
            {
                dangNhap.Show();
                this.Close();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker != null && backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            base.OnFormClosing(e);
        }

        

        private bool KiemTraTrangThaiDangNhap()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-SMMDH16\\SQLEXPRESS;Initial Catalog=ql_tv1;User ID=sa;Password=sa"))
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlCommand để gọi stored procedure
                    using (SqlCommand cmd = new SqlCommand("SELECT dbo.F_KiemTraTrangThai(@Username)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", this.dangNhap.GetUserName);

                        // Thực thi stored procedure
                        var trangThai = Convert.ToBoolean(cmd.ExecuteScalar());
                        return trangThai;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo");
                }
            }

            return false;
        }
    }
}
