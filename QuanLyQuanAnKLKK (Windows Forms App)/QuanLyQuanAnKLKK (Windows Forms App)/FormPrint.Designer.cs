namespace QuanLyQuanAnKLKK__Windows_Forms_App_
{
    partial class FormPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrint));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyQuanAnKLKKDataSet = new QuanLyQuanAnKLKK__Windows_Forms_App_.QuanLyQuanAnKLKKDataSet();
            this.USP_ReportTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_ReportTable2TableAdapter = new QuanLyQuanAnKLKK__Windows_Forms_App_.QuanLyQuanAnKLKKDataSetTableAdapters.USP_ReportTable2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanAnKLKKDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_ReportTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "databill";
            reportDataSource1.Value = this.USP_ReportTable2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyQuanAnKLKK__Windows_Forms_App_.rptBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(615, 612);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyQuanAnKLKKDataSet
            // 
            this.QuanLyQuanAnKLKKDataSet.DataSetName = "QuanLyQuanAnKLKKDataSet";
            this.QuanLyQuanAnKLKKDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_ReportTable2BindingSource
            // 
            this.USP_ReportTable2BindingSource.DataMember = "USP_ReportTable2";
            this.USP_ReportTable2BindingSource.DataSource = this.QuanLyQuanAnKLKKDataSet;
            // 
            // USP_ReportTable2TableAdapter
            // 
            this.USP_ReportTable2TableAdapter.ClearBeforeFill = true;
            // 
            // FormPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 612);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPrint";
            this.Load += new System.EventHandler(this.FormPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanAnKLKKDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_ReportTable2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_ReportTable2BindingSource;
        private QuanLyQuanAnKLKKDataSet QuanLyQuanAnKLKKDataSet;
        private QuanLyQuanAnKLKKDataSetTableAdapters.USP_ReportTable2TableAdapter USP_ReportTable2TableAdapter;
    }
}