using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DTO
{
    public class FoodCategory
    {
      
        public FoodCategory(int idCategory, string nameCategory)
        {
            this.idCategory = idCategory;
            this.nameCategory = nameCategory;
        }

        public FoodCategory(DataRow row)
        {
            this.idCategory = (int)row["IDCategory"];
            this.nameCategory = row["NameCategory"].ToString();
        }

        private int idCategory;
        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        private string nameCategory;
        public string NameCategory
        {
            get { return nameCategory; }
            set { nameCategory = value; }
        }
    }
}
