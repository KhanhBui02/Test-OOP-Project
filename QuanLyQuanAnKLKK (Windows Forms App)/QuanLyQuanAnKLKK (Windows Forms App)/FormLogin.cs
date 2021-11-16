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
            FormManager  f =   new FormManager();           
            this.Hide();                                    // khi show form quản lý bàn ăn và thanh toán sẽ tắt form đăng nhập
            f.ShowDialog();                                
            this.Show();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("bạn có thật sự muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)   //ấn nút tắt chương trình sẽ hiện thông báo "có thật sự muốn tắt"
            {
                e.Cancel = true;
            }
              
        }

    }
}
