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
    public partial class FormManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount 
        { 
            get {return loginAccount;}
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public FormManager(Account acc)
        {
            InitializeComponent();
            LoadTable();
            this.LoginAccount = acc;
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

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
        }
        void LoadTable()
        {
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua; break;
                    default:
                        btn.BackColor = Color.Red; break;
                }
                flpTable.Controls.Add(btn);
            }

        }
    }
}
