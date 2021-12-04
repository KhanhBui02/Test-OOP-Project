using QuanLyQuanAnKLKK__Windows_Forms_App_.DAO;
using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btOut_Click(object sender, EventArgs e)
        {
            Application.Exit();        //ấn nút tắt chương trình sẽ hiện bản thông báo "có thật sự muốn tắt"
        }

        private void btLogin_Click(object sender, EventArgs e)  // khi ấn vào nút đăng nhập sẽ đi tới form quản lý bàn ăn và thanh toán
        {
            string userName = txtLogin.Text;
            string password = txtPassWord.Text;
            if (Login(userName, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                FormManager f = new FormManager(loginAccount);
                this.Hide();                                    // khi show form quản lý bàn ăn và thanh toán sẽ tắt form đăng nhập
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)   //ấn nút tắt chương trình sẽ hiện thông báo "có thật sự muốn tắt"
            {
                e.Cancel = true;
            }

        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void picLogo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void labelLogin_Click(object sender, EventArgs e)
        {

        }

        private void labelPassWord_Click(object sender, EventArgs e)
        {

        }
    }
}
