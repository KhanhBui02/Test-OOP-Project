namespace QuanLyQuanAnKLKK__Windows_Forms_App_
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btLogin = new System.Windows.Forms.Button();
            this.btOut = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.labelPassWord = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btLogin);
            this.panel1.Controls.Add(this.btOut);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.panel1.Location = new System.Drawing.Point(-5, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 170);
            this.panel1.TabIndex = 0;
            this.panel1.UseWaitCursor = true;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btLogin
            // 
            this.btLogin.BackColor = System.Drawing.Color.Crimson;
            this.btLogin.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btLogin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btLogin.Location = new System.Drawing.Point(90, 124);
            this.btLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(100, 32);
            this.btLogin.TabIndex = 3;
            this.btLogin.Text = "Đăng Nhập";
            this.btLogin.UseVisualStyleBackColor = false;
            this.btLogin.UseWaitCursor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // btOut
            // 
            this.btOut.BackColor = System.Drawing.Color.Crimson;
            this.btOut.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btOut.Location = new System.Drawing.Point(217, 124);
            this.btOut.Margin = new System.Windows.Forms.Padding(4);
            this.btOut.Name = "btOut";
            this.btOut.Size = new System.Drawing.Size(100, 32);
            this.btOut.TabIndex = 4;
            this.btOut.Text = "Thoát";
            this.btOut.UseVisualStyleBackColor = false;
            this.btOut.UseWaitCursor = true;
            this.btOut.Click += new System.EventHandler(this.btOut_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPassWord);
            this.panel3.Controls.Add(this.labelPassWord);
            this.panel3.Location = new System.Drawing.Point(9, 62);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 51);
            this.panel3.TabIndex = 2;
            this.panel3.UseWaitCursor = true;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(134, 10);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(203, 26);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.UseSystemPasswordChar = true;
            this.txtPassWord.UseWaitCursor = true;
            this.txtPassWord.TextChanged += new System.EventHandler(this.txtPassWord_TextChanged);
            // 
            // labelPassWord
            // 
            this.labelPassWord.AutoSize = true;
            this.labelPassWord.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelPassWord.Location = new System.Drawing.Point(21, 10);
            this.labelPassWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassWord.Name = "labelPassWord";
            this.labelPassWord.Size = new System.Drawing.Size(94, 22);
            this.labelPassWord.TabIndex = 0;
            this.labelPassWord.Text = "Password";
            this.labelPassWord.UseWaitCursor = true;
            this.labelPassWord.Click += new System.EventHandler(this.labelPassWord_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtLogin);
            this.panel2.Controls.Add(this.labelLogin);
            this.panel2.Location = new System.Drawing.Point(9, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 56);
            this.panel2.TabIndex = 1;
            this.panel2.UseWaitCursor = true;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(134, 24);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(202, 26);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.UseWaitCursor = true;
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelLogin.Location = new System.Drawing.Point(21, 24);
            this.labelLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(105, 22);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "User Name";
            this.labelLogin.UseWaitCursor = true;
            this.labelLogin.Click += new System.EventHandler(this.labelLogin_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.picLogo);
            this.panel4.Location = new System.Drawing.Point(0, -4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 96);
            this.panel4.TabIndex = 1;
            this.panel4.UseWaitCursor = true;
            // 
            // picLogo
            // 
            this.picLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picLogo.ErrorImage")));
            this.picLogo.ImageLocation = "C:\\Project\\OOP-Project\\QuanLyQuanAnKLKK (Windows Forms App)\\QuanLyQuanAnKLKK (Win" +
    "dows Forms App)";
            this.picLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogo.InitialImage")));
            this.picLogo.Location = new System.Drawing.Point(6, 6);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(367, 98);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.UseWaitCursor = true;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.CancelButton = this.btOut;
            this.ClientSize = new System.Drawing.Size(378, 255);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.UseWaitCursor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label labelPassWord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btOut;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

