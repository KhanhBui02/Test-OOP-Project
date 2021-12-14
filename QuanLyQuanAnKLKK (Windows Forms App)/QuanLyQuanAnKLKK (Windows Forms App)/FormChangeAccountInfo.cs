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
    public partial class FormChangeAccountInfo : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public FormChangeAccountInfo(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        void UpdateAccountInfo()
        {
            string displayName = txtDisplayname.Text;
            string matKhau = AccountDAO.Instance.EncodePassword(txtPassword.Text);
            string matKhauMoi = txtNewPassword.Text;
            string nhapLaiMatKhau = txtReEnterNewPassword.Text;
            string userName = txtLogin.Text;

            if(!matKhauMoi.Equals(nhapLaiMatKhau))
            {
                MessageBox.Show("Nhập lại mật khẩu chưa đúng!");
            }
            else
            {
                if(matKhauMoi!="")
                    matKhauMoi = AccountDAO.Instance.EncodePassword(matKhauMoi);
                if (AccountDAO.Instance.UpdateAccount(userName,displayName,matKhau,matKhauMoi))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu!");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        void ChangeAccount(Account acc)
        {
            txtLogin.Text = LoginAccount.UserName;
            txtDisplayname.Text = LoginAccount.DisplayName;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void FormChangeAccountInfo_Load(object sender, EventArgs e)
        {

        }
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
