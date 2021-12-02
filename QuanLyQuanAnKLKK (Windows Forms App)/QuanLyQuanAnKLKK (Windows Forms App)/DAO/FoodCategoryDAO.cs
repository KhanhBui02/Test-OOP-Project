using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    public class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;

        public static FoodCategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodCategoryDAO();
                return FoodCategoryDAO.instance;
            }
            set { FoodCategoryDAO.instance = value; }
        }
        private FoodCategoryDAO()
        {

        }

        public List<FoodCategory> GetListCategory()
        {
            List<FoodCategory> list = new List<FoodCategory>();

            string query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodCategory foodCategory = new FoodCategory(item);
                list.Add(foodCategory);
            }

            return list;
        }

        public FoodCategory GetCategoryByID(int id)
        {
            FoodCategory foodCategory = null;


            string query = "select * from FoodCategory where IDCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                foodCategory = new FoodCategory(item);
                return foodCategory;
            }

            return foodCategory;
        }


        internal bool InsertCategory(string nameCategory)
        {
            string query = String.Format("insert FoodCategory (NameCategory) values (N'{0}')", nameCategory);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        internal bool UpdateCategory(string nameCategory, int idCategory)
        {
            string query = String.Format("update FoodCategory set NameCategory = N'{0}' where IDCategory = {1}", nameCategory, idCategory);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        internal bool DeleteCategory(int idCategory)
        {
            BillInfoDAO.Instance.DeleteBillInfoByCategoryID(idCategory); //xóa những Billinfo có IdFood Bị xóa

            string query = String.Format("Delete FoodCategory where IDCategory = {0}", idCategory);
            int result = (int)DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}