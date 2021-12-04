using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;   

        public static BillDAO Instance
        {
            get {
                if(instance == null) instance = new BillDAO(); 
                return BillDAO.instance;
                }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }
        /// <summary>
        /// Thành công: bill ID
        /// Thất bại -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill where IDTable = " + id + " and TinhTrang = 0"); //lấy thông tin bill bàn chưa check out

            if (data.Rows.Count > 0) // nếu bill tồn tại thì đổ ra mảng data row
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        // update lại tình trạng bill
        public void CheckOut(int id,int discount,float totalPrice)
        {
            string query = "UPDATE Bill SET DateCheckOut = GETDATE(), TinhTrang = 1, "+"discount = "+ discount +",totalPrice = "+ totalPrice +"WHERE IDBill = " + id;  
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @IDTable", new object[]{id}); //thêm bill theo ID của bàn (@IDTable)
        }

        public DataTable GetListBillByDate(DateTime checkIn,DateTime checkOut)
        {

            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @checkin , @checkout",new object[]{checkIn,checkOut});
        }

        //lấy ID của bill cuối cùng
        public int GetMaxIDBill() // bill thêm mới vào luôn luôn là bill cuối cùng trong dữ liệu
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(IDBill) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }
        public DataTable GetListBillByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDateAndPage @checkin , @checkout , @page", new object[] { checkIn, checkOut, pageNum });
        }
        public int GetNumBillByDate(DateTime checkIn, DateTime checkOut)
        {

            return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetNumBillByDate @checkin , @checkout", new object[] { checkIn, checkOut });
        }
    }
}
