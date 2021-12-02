using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DTO
{
    class FoodCategory
    {
        private int idCategory;
        private String nameCategory;

        public FoodCategory(int idCategory, String nameCategory)
        {
            this.idCategory = idCategory;
            this.nameCategory = nameCategory;
        }

        public FoodCategory(DataRow row)
        {
            this.idCategory = (int)row["IDCategory"];
            this.nameCategory = row["NameCategory"].ToString();
        }

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public String NameCategory
        {
            get { return nameCategory; }
            set { nameCategory = value; }
        }
    }
}
