using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAnKLKK__Windows_Forms_App_
{
    public partial class FormPrint : Form
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public FormPrint(int IdBill)
        {
            InitializeComponent();
            Id = IdBill;
        }
        public FormPrint()
        {
            InitializeComponent();
        }

        private void FormPrint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanAnKLKKDataSet.USP_ReportTable2' table. You can move, or remove it, as needed.
            this.USP_ReportTable2TableAdapter.Fill(this.QuanLyQuanAnKLKKDataSet.USP_ReportTable2,Id);

            this.reportViewer1.RefreshReport();
        }
    }
}
