﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckIn,DateTime? dateCheckOut,int status,int discount = 0)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["IDBill"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = (int)row["TinhTrang"];
            this.Discount = (int)row["discount"];
        }

        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private DateTime? dateCheckOut;

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private DateTime? dateCheckIn;

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }
    }
}
