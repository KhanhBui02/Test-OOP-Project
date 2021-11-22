using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            string query = "USP_Login @userName , @password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });
            return result.Rows.Count > 0;
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
    }
}
