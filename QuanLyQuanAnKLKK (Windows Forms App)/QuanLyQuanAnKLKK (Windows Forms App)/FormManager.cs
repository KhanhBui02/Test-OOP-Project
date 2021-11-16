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
    public partial class FormManager : Form
    {
        public FormManager()
        {
            InitializeComponent();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();                   //ấn đăng xuất sẽ thoát ra màn hình đăng nhập
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangeAccountInfo f = new FormChangeAccountInfo();
            f.ShowDialog();                                                 //hiện form thay đổi thông tin tài khoản

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdmin f = new FormAdmin();
            this.Hide();
            f.ShowDialog();                         //hiện form Admin
            this.Show();
        }
    }
}
