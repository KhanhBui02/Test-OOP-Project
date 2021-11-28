using System;
using System.Collections.Generic;
using System.Data;
using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }
        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT F.NameFood,BI.CountFood,F.Price,F.Price*BI.CountFood AS totalPrice FROM BillInfo AS BI,Bill AS B,Food AS F WHERE BI.IDBill = B.IDBill AND BI.idFood = F.IDFood AND B.IDTable = " + id + "AND B.tinhtrang = 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
