using QuanLyQuanAnKLKK__Windows_Forms_App_.DAO;
using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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
            LoadCategory();
            LoadComboBoxTable(cbSwapTable);
            this.LoginAccount = acc;
            CheckLoadTable();
        }

        void CheckLoadTable()
        {
            if (FormAdmin.check == 1)
            {
                LoadTable();
                FormAdmin.check = 0;
            }
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();                   //ấn đăng xuất sẽ thoát ra màn hình đăng nhập
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangeAccountInfo f = new FormChangeAccountInfo(LoginAccount);
            f.UpdateAccount += f_UpdateAccountEvent;
            f.ShowDialog();                      //hiện form thay đổi thông tin tài khoản

        }
        void f_UpdateAccountEvent(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            
            FormAdmin f = new FormAdmin();
            this.Hide();                                    // khi show form quản lý bàn ăn và thanh toán sẽ tắt form đăng nhập
            
            
            f.loginAccount = LoginAccount;
            f.InsertFood += f_Insertfood;
            f.UpdateFood += f_Updatefood;
            f.DeleteFood += f_Deletefood;

            f.ShowDialog();//hiện form Admin
            LoadTable();
            this.Show();

            
        }
        //hàm xử lí event khi xóa ở FormAdmin
        private void f_Deletefood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as FoodCategory).IdCategory);
            if (lsvBill.Tag != null){
                ShowBill((lsvBill.Tag as Table).ID);
            }
            LoadTable();
        }
        //hàm xử lí event khi sửa ở FormAdmin
        private void f_Updatefood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as FoodCategory).IdCategory);
            if (lsvBill.Tag != null) {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }
        //hàm xử lí event khi thêm ở FormAdmin
        private void f_Insertfood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategory.SelectedItem as FoodCategory).IdCategory);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        //tải FoodCategory
        void LoadCategory()
        {
            List<FoodCategory> listCategory = FoodCategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "NameCategory";
        }

        //tải Food theo Category 
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> listfood = FoodDAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listfood;
            cbFood.DisplayMember = "NameFood";
        }
        //tải thông tin bàn
        void LoadTable()
        {
            
            flpTable.Controls.Clear();//clear danh sách bàn cũ mỗi khi load lại
            List<Table> tablelist = TableDAO.Instance.LoadTableList();
            foreach (Table item in tablelist)
            {
                //định nghĩa thông tin bàn thành button 
                Button btn = new Button() 
                { 
                    Width = TableDAO.TableWidth, //chiều cao , chiều rộng button
                    Height = TableDAO.TableHeight 
                };
                btn.Text = item.Name/*tên bàn*/ + Environment.NewLine /*xuống dòng*/ + item.Status/*tình trạng*/;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                  {
                    case "Trống":
                        btn.BackColor = Color.DarkSeaGreen; break;
                    default:
                        btn.BackColor = Color.Lime; break;
                }
                flpTable.Controls.Add(btn);
            }

        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();//clear list view bill mỗi khi load lại
            List<QuanLyQuanAnKLKK__Windows_Forms_App_.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);

            float totalPrice = 0;//tổng tiền
            foreach (QuanLyQuanAnKLKK__Windows_Forms_App_.DTO.Menu item in listBillInfo) 
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                lsvBill.Items.Add(lsvItem); //thêm item vào các subitem ở trên vào list view bill
                totalPrice += item.TotalPrice;//tính tổng tiền
            }
            CultureInfo culture = new CultureInfo("vi-VN");//đổi sang định dạng tiền VNĐ
            txbTotalPrice.Text = totalPrice.ToString("c",culture);
        }

        //button click vào bàn
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID; //lấy ID bàn từ button
            lsvBill.Tag = (sender as Button).Tag; //gắn tag cho list view bill từ button
            ShowBill(tableID);//hiện bill theo ID bàn
        }


        //Combobox FoodCategory + Food
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0; 
            ComboBox cb = sender as ComboBox; 

            if (cb.SelectedItem == null)
                return;

            FoodCategory selected = cb.SelectedItem as FoodCategory;

            id = selected.IdCategory;

            LoadFoodListByCategoryID(id); //tải food sau khi chọn Category
        }

        private void btAddFood_Click(object sender, EventArgs e)
        {
            lsvBill.Items.Clear(); // clear list view khi thêm món

            Table table = lsvBill.Tag as Table; //lấy id bàn

            if (table == null) {
                MessageBox.Show("Vui lòng chọn bàn");
                return;
            }

            int IDBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID); //lấy id của bill chưa check out
            int IDFood = (cbFood.SelectedItem as Food).IdFood; //IDFood nhập vào là IDFood từ Combobox
            int CountFood = (int)nmFoodCount.Value; //lấy số lượng từ bảng đếm

            if(IDBill == -1) //nếu bàn đã check out => nhập bill và billinfo
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(),IDFood,CountFood);
            }
            else //chỉ cần update billinfo
            {
                BillInfoDAO.Instance.InsertBillInfo(IDBill, IDFood, CountFood);
            }

            LoadTable(); // sau khi thêm món tải lại bàn
        }

        //button thanh toán
        private void btThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;  //gắn tag cho list view bill
            int IDBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID); //lấy id của bill chưa check out
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0].Replace(".", ""));    //lấy tổng tiền
            double finalPrice = totalPrice - (totalPrice / 100) * discount;     //tính tổng tiền sau khi giảm giá
            //dialog 
            if (MessageBox.Show(String.Format("Bạn có chắc thanh toán hóa đơn cho {0}\nTổng tiền: {1} Đồng\nGiảm giá: {2}%\nTổng tiền sau khi giảm giá: {3} Đồng", table.Name,totalPrice,discount,finalPrice) ,"Thông báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                BillDAO.Instance.CheckOut(IDBill,discount,(float)finalPrice);
                LoadReport(table.ID);
                ShowBill(table.ID); //show list bill đã xóa
                LoadTable(); //load lại bàn
            }
        }
        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";

        }

        void LoadReport(int id)
        {
            FormPrint f = new FormPrint(id);
            f.ShowDialog();
        }

        private void btSwapTable_Click(object sender, EventArgs e)      // nút chuyển bàn
        {
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwapTable.SelectedItem as Table).ID;
            if (MessageBox.Show(String.Format("Bạn có chắc muốn chuyển bàn {0} qua bàn {1}", (lsvBill.Tag as Table).Name, (cbSwapTable.SelectedItem as Table).Name), "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwapTable(id1, id2);      //chuyển bàn
                LoadTable();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btAddFood_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btThanhToan_Click(this, new EventArgs());
        }

        private void FormManager_Load(object sender, EventArgs e)
        {

        }
    }
}
