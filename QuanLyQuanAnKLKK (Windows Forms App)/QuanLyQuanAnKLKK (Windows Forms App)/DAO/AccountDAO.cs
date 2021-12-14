using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string password)
        {
            string hasPass = EncodePassword(password);

            string query = "USP_Login @userName , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass });
            return result.Rows.Count > 0;
        }

        public string EncodePassword(string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            return hasPass;
        }

        public bool UpdateAccount(string userName, string displayName, string matKhau, string matKhauMoi)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @matKhau , @matKhauMoi ", new object[] { userName, displayName, matKhau, matKhauMoi });

            return result > 0;
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select UserName, DisplayName, Loai from dbo.Account");
        }


        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * " +
                "from account where userName = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string name, string displayName, int loai)
        {
            string query = string.Format("insert dbo.Account (UserName, DisplayName, Loai, MatKhau) values (N'{0}', N'{1}',{2},N'{3}')", name, displayName, loai, "20720532132149213101239102231223249249135100218");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount(string name, string displayName, int loai)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{1}', Loai = {2} where UserName = N'{0}'", name, displayName, loai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set MatKhau = N'20720532132149213101239102231223249249135100218' where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
