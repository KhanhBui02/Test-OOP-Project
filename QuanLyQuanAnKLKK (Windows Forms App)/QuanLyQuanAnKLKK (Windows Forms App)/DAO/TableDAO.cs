using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { }

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        public List<Table> LoadTableList()
        {
            List<Table> tablelist = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);

                tablelist.Add(table);
            }
            return tablelist;
        }
        public bool InsertTable(string name)
        {
            string query = String.Format("insert TableFood (TENBAN) values (N'{0}')", name);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTable(string name,int idTable)
        {
            string query = String.Format("update TableFood set TENBAN = N'{0}' where IDTable = {1}", name, idTable);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
            BillInfoDAO.Instance.DeleteBillInfoByTableID(idTable); //xóa những Billinfo có IdTable Bị xóa

            string query = String.Format("Delete TableFood where IDTable = {0}", idTable);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void SwapTable(int id1,int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwapTable @idTable1 , @idTable2", new object[]{id1, id2});
        }
    }
}
