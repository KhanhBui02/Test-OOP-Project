using QuanLyQuanAnKLKK__Windows_Forms_App_.DAO;
using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
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

namespace QuanLyQuanAnKLKK__Windows_Forms_App_
{
    public partial class FormAdmin : Form
    {
        BindingSource accountList = new BindingSource();

        public Account loginAccount;
        public FormAdmin()
        {
            InitializeComponent();
            Loadd();
        }
        #region method
        void Loadd()        //vì xuất hiện lỗi nên ko dùng Load
        {
            dtgvAccount.DataSource = accountList;
            LoadAccountList();
            AddAccountBinding();
        }
        void LoadAccountList()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadListFood(){
            dtgvFood.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nudAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Loai", true, DataSourceUpdateMode.Never));
        }
        void AddAccount(string userName, string displayName, int loai)
        {
            if(AccountDAO.Instance.InsertAccount(userName,displayName,loai))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!");
            }

            LoadAccountList();
        }
        void EditAccount(string userName, string displayName, int loai)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, loai))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật khoản thất bại!");
            }

            LoadAccountList();
        }
        void DeleteAccount(string userName)
        {
            if(loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Sao lại tự vả thế kia? Dùng tài khoản khác mà xóa đi! Sad");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Xóa khoản thất bại!");
            }

            LoadAccountList();
        }
        void ResetPassword(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Reset mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Reset mật khẩu thất bại!");
            }
        }
        #endregion

        #region event
        private void btViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        private void btViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }
        private void btEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int loai = (int)nudAccountType.Value;

            EditAccount(userName, displayName, loai);
        }
        private void btDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;      

            DeleteAccount(userName);
        }
        private void btAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int loai = (int)nudAccountType.Value;

            AddAccount(userName, displayName, loai);
        }
        private void btSetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPassword(userName);
        }
        #endregion

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
