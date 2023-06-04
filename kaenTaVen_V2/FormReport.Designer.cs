
namespace kaenTaVen_V2
{
    partial class FormReport
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
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.btnCustomerSaleDetail = new FontAwesome.Sharp.IconButton();
            this.btnAllSales = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Black;
            this.lblTitleChildForm.Location = new System.Drawing.Point(892, 570);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(100, 21);
            this.lblTitleChildForm.TabIndex = 3;
            this.lblTitleChildForm.Text = "Report Der";
            // 
            // btnCustomerSaleDetail
            // 
            this.btnCustomerSaleDetail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCustomerSaleDetail.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btnCustomerSaleDetail.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCustomerSaleDetail.IconColor = System.Drawing.Color.Black;
            this.btnCustomerSaleDetail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomerSaleDetail.Location = new System.Drawing.Point(592, 133);
            this.btnCustomerSaleDetail.Name = "btnCustomerSaleDetail";
            this.btnCustomerSaleDetail.Size = new System.Drawing.Size(350, 350);
            this.btnCustomerSaleDetail.TabIndex = 7;
            this.btnCustomerSaleDetail.Text = "Customer Sale Detail";
            this.btnCustomerSaleDetail.UseVisualStyleBackColor = true;
            this.btnCustomerSaleDetail.Click += new System.EventHandler(this.btnCustomerSaleDetail_Click);
            // 
            // btnAllSales
            // 
            this.btnAllSales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAllSales.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btnAllSales.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAllSales.IconColor = System.Drawing.Color.Black;
            this.btnAllSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAllSales.Location = new System.Drawing.Point(102, 133);
            this.btnAllSales.Name = "btnAllSales";
            this.btnAllSales.Size = new System.Drawing.Size(350, 350);
            this.btnAllSales.TabIndex = 6;
            this.btnAllSales.Text = "All Sales";
            this.btnAllSales.UseVisualStyleBackColor = true;
            this.btnAllSales.Click += new System.EventHandler(this.btnAllSales_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1044, 617);
            this.Controls.Add(this.btnCustomerSaleDetail);
            this.Controls.Add(this.btnAllSales);
            this.Controls.Add(this.lblTitleChildForm);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconButton btnCustomerSaleDetail;
        private FontAwesome.Sharp.IconButton btnAllSales;
    }
}