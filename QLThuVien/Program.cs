using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYTHUVIEN
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }


        public static bool CheckStringArrayTrue(string[] array)
        {
            if (array == null || array.Length == 0)
            {
                return false; // Mảng null hoặc không có phần tử
            }

            foreach (string str in array)
            {
                if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    return false; // Có phần tử rỗng, null, hoặc không có ký tự
                }
            }

            return true; // Tất cả phần tử hợp lệ
        }

        public static bool CheckStringTrue(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return false; 
            }

            return true; 
        }
    }
}
