using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get 
            {
                if (instance == null) instance = new BillInfoDAO();
                return BillInfoDAO.instance;
            }
            private set { BillInfoDAO.instance = value; }
        }

        public BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BillInfo where IDBill = " + id);

            foreach(DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int IDBill,int idFood,int CountFood)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfor @IDBill , @idFood , @CountFood ", new object[] {IDBill,idFood,CountFood });
        }


        internal void InsertBillInfo(Func<int> func, int p1, int p2)
        {
            throw new NotImplementedException();
        }

        internal void DeleteBillInfoByFoodID(int idFood)
        {
            DataProvider.Instance.ExecuteQuery("Delete BillInfo where idFood = " + idFood);
        }
        internal void DeleteBillInfoByCategoryID(int idCategory)
        {
            DataProvider.Instance.ExecuteQuery("Delete BillInfo where idFood = " + idCategory);
        }
        internal void DeleteBillInfoByTableID(int idTable)
        {
            
            DataProvider.Instance.ExecuteQuery("delete billinfo from Bill as B, " +
            " TableFood as TF, BillInfo as BI where B.idBill = BI.idBill and " +
            " B.IDTable = TF.idTable and TF.idTable = " + idTable);

            DataProvider.Instance.ExecuteQuery("delete Bill where IDTable = " + idTable);
        }
    }
}
