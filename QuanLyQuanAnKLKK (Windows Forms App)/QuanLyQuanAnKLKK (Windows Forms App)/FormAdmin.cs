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
<<<<<<< HEAD
            InitializeComponent();        
=======
            InitializeComponent();
            LoadAccountList();
        }
        #region method
        void LoadAccountList()
        {
            string query = "exec USP_GetListAccountByUserName @userName";  
  
            dtgvAccount.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { "thanhloi" });        //có thể sử dụng câu lệnh khác ko cần parameter ví dụ query="select * from Account"
>>>>>>> 2566a7a9140241751dfe6d7638e6ba7f2d4da779
        }
        void LoadListFood(){
            dtgvFood.DataSource = FoodDAO.Instance.GetListFood();
        }
        #endregion

        #region event
        private void btViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        #endregion
    }
}
