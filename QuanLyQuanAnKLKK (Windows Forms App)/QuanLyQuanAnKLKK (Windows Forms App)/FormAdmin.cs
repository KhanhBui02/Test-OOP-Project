using QuanLyQuanAnKLKK__Windows_Forms_App_.DAO;
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
        public FormAdmin()
        {
            InitializeComponent();
            LoadAccountList();
        }
        void LoadAccountList()
        {
            string query = "exec USP_GetListAccountByUserName @userName";  
  
            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "thanhloi" });        //có thể sử dụng câu lệnh khác ko cần parameter ví dụ query="select * from Account"
        }
    }
}
