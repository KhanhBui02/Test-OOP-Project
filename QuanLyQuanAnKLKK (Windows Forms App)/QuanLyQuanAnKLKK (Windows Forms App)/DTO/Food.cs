using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DTO
{
    class Food
    {
        private int idFood;
        private String nameFood;
        private int idCategory;
        private float price;

        public Food(int idFood, String nameFood, int idCategory, float price)
        {
            this.idFood = idFood;
            this.nameFood = nameFood;
            this.idCategory = idCategory;
            this.price = price;
        }

        public Food(DataRow row)
        {
            this.idFood = (int)row["IDFood"];
            this.nameFood = row["NameFood"].ToString();
            this.idCategory = (int)row["IDCategory"];
            this.price = (float)Convert.ToDouble(row["Price"].ToString());
        }

        public int IdFood
        {
            get { return idFood; }
            set { idFood = value; }
        }

        public String NameFood
        {
            get { return nameFood; }
            set { nameFood = value; }
        }

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
