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
        public static int check = 0;

        BindingSource accountList = new BindingSource();
        BindingSource foodlist = new BindingSource();
        BindingSource foodcategory = new BindingSource();
        BindingSource table = new BindingSource();

        public Account loginAccount;
        public FormAdmin()
        {
            InitializeComponent();
            LoadAccountList();
            LoadCategoryIntoComboBox(cbxFoodCategory);
            LoadListBillByDate(dtpcheckIn.Value, dtpcheckOut.Value);
            Loadd();
            LoadDateTimePickerBill();
        }
        #region method
        void Loadd()        //vì xuất hiện lỗi nên ko dùng Load
        {
            dtgvAccount.DataSource = accountList;
            dtgvFood.DataSource = foodlist;
            dtgvCategory.DataSource = foodcategory;
            dtgvTable.DataSource = table;

            LoadAccountList();
            AddAccountBinding();
            LoadListFood();//show list thức ăn khi formAdmin hiện ra //of kien
            LoadCategoryIntoCombBox(cbxFoodCategory);//load CatogoryFood vào danh mục thức ăn // of kien
            AddFoodBinding();//Binding // of kien
            LoadListCategory();
            AddCategoryBinding();
            LoadListTable();
            AddTableBinding();
        }
        //load CatogoryFood vào danh mục thức ăn // of kien
        void LoadCategoryIntoCombBox(ComboBox cb)
        {
            cb.DataSource = FoodCategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "nameCategory";
        }
        //load listfood // of kien
        void LoadListFood()
        {
            foodlist.DataSource = FoodDAO.Instance.GetListFood();
        }
        //Bindings food // of kien
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "NameFood", true, DataSourceUpdateMode.Never));
            txtIDFood.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "IdFood", true, DataSourceUpdateMode.Never));
            nmPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
            cbxFoodCategory.DataBindings.Add(new Binding("SelectedValue", dtgvFood.DataSource, "IdCategory", true, DataSourceUpdateMode.Never));
        }

        void LoadAccountList()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nudAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Loai", true, DataSourceUpdateMode.Never));
        }
        void AddAccount(string userName, string displayName, int loai)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, loai))
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
            if (loginAccount.UserName.Equals(userName))
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
        void LoadListCategory()
        {
            foodcategory.DataSource = FoodCategoryDAO.Instance.GetListCategory();
        }
        void AddCategoryBinding()
        {
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "IdCategory", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "NameCategory", true, DataSourceUpdateMode.Never));
        }
        void LoadListTable()
        {
            table.DataSource = TableDAO.Instance.LoadTableList();
        }
        void AddTableBinding()
        {
            txtIDTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        List<Food> SearchFoodByName(string name)
        {

            List<Food> listfood = FoodDAO.Instance.SearchFoodByName(name);

            return listfood;
        }
        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = FoodCategoryDAO.Instance.GetListCategory();
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDate(checkIn, checkOut);
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpcheckIn.Value = new DateTime(today.Year, today.Month, 1);
            dtpcheckOut.Value = dtpcheckIn.Value.AddMonths(1).AddDays(-1);
        }
        #endregion

        #region event

        private void btViewFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }//event xem // of kien
        private void txtIDFood_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["IdCategory"].Value;

                    FoodCategory foodCategory = FoodCategoryDAO.Instance.GetCategoryByID(id);

                    cbxFoodCategory.SelectedItem = foodCategory;

                    int index = -1;
                    int i = 0;
                    foreach (FoodCategory item in cbxFoodCategory.Items)
                    {
                        if (item.IdCategory == foodCategory.IdCategory)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbxFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }//event danh mục thay đổi theo idFood // of kien
        private void btAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int idCategory = (cbxFoodCategory.SelectedItem as FoodCategory).IdCategory;
            float price = (float)nmPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, idCategory, price))
            {
                MessageBox.Show("Thêm thành công!!");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("lỗi !!!");
            }
        }//event add Food // of kien
        private void btEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int idCategory = (cbxFoodCategory.SelectedItem as FoodCategory).IdCategory;
            float price = (float)nmPrice.Value;
            int idFood = Convert.ToInt32(txtIDFood.Text);

            if (FoodDAO.Instance.UpdateFood(name, idCategory, price, idFood))
            {
                MessageBox.Show("Sửa thành công!!");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Lỗi");
            }
        }//update (edit) Food // of kien
        private void btDeleteFood_Click(object sender, EventArgs e)//del Food // of kien
        {
            int idFood = Convert.ToInt32(txtIDFood.Text);

            if (FoodDAO.Instance.DeleteFood(idFood))
            {
                MessageBox.Show("Xóa thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("lỗi");
            }
        }
        private void btSearchFood_Click(object sender, EventArgs e)
        {
            foodlist.DataSource = SearchFoodByName(txtSearchFoodName.Text);
        }//search food

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

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }


        private void btViewCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
        private void btAddCategory_Click(object sender, EventArgs e)
        {
            string nameCategory = txtCategoryName.Text;

            if (FoodCategoryDAO.Instance.InsertCategory(nameCategory))
            {
                MessageBox.Show("Thêm thành công!!");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("lỗi !!!");
            }
        }
        private void btEditCategory_Click(object sender, EventArgs e)
        {
            string nameCategory = txtCategoryName.Text;
            int idCategory = Convert.ToInt32(txtIDFood.Text);

            if (FoodCategoryDAO.Instance.UpdateCategory(nameCategory, idCategory))
            {
                MessageBox.Show("Sửa thành công!!");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Lỗi");
            }

        }
        private void btDeleteCategory_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(txtCategoryID.Text);

            if (FoodCategoryDAO.Instance.DeleteCategory(idCategory))
            {
                MessageBox.Show("Xóa thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("lỗi");
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;

            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm thành công!!");
                LoadListTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("lỗi !!!");
            }
        }
        private void btView_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }
        private void btEddit_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
            int idTable = Convert.ToInt32(txtIDTable.Text);

            if (TableDAO.Instance.UpdateTable(name, idTable))
            {
                MessageBox.Show("Thêm thành công!!");
                LoadListTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("lỗi !!!");
            }
        }
        private void btDel_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txtIDTable.Text);

            if (TableDAO.Instance.DeleteTable(idTable))
            {
                MessageBox.Show("Xóa thành công");
                LoadListTable();

                check = 1;
            }
            else
            {
                MessageBox.Show("lỗi");
            }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        #endregion

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btWatchBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpcheckIn.Value, dtpcheckOut.Value);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillByDate(dtpcheckIn.Value, dtpcheckOut.Value);
            int lastpage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastpage++;
            txbPageBill.Text = lastpage.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            if (page > 1)
                page--;
            txbPageBill.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillByDate(dtpcheckIn.Value, dtpcheckOut.Value);
            if (page < sumRecord)
                page++;
            txbPageBill.Text = page.ToString();
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDateAndPage(dtpcheckIn.Value, dtpcheckOut.Value, Convert.ToInt32(txbPageBill.Text));


        }
    }
}
