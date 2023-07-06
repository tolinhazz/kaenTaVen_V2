namespace kaenTaVen_V2.Report
{
    partial class PrintInvoiceFOrm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Invoice_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "kaenTaVen_V2.Report.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 107);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 745);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(617, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Invoice_ID
            // 
            this.txt_Invoice_ID.Location = new System.Drawing.Point(215, 37);
            this.txt_Invoice_ID.Name = "txt_Invoice_ID";
            this.txt_Invoice_ID.Size = new System.Drawing.Size(272, 26);
            this.txt_Invoice_ID.TabIndex = 2;
            // 
            // PrintInvoiceFOrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 878);
            this.Controls.Add(this.txt_Invoice_ID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintInvoiceFOrm";
            this.Text = "PrintInvoiceForm";
            this.Load += new System.EventHandler(this.PrintInvoiceFOrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Invoice_ID;
    }
}