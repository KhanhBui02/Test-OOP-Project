using QuanLyQuanAnKLKK__Windows_Forms_App_.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DAO
{
    class FoodCategoryDAO
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

            String query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodCategory foodCategory = new FoodCategory(item);
                list.Add(foodCategory);
            }

            return list;
        }

    }
}
