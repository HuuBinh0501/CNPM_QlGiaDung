using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace qlKinhDoanhDoDienGiaDung
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=WINDOWS-F6D8G21;Initial Catalog=SinhVien;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txtUsername.Text;
                string mk = txtPassword.Text;
                string sql = "select *from NguoiDung where TaiKhoan='" +tk+ "'and Matkhau='" +mk+ "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read()==true) 
                {
                    Giaodienhethong hethong = new Giaodienhethong();
                    hethong.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!", "Thông báo");
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
