
namespace kaenTaVen_V2
{
    partial class FormCustomerSale
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDateReceived = new System.Windows.Forms.TextBox();
            this.txtDateDelivery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch2 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.Location = new System.Drawing.Point(469, 545);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(80, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(888, 326);
            this.dataGridView1.TabIndex = 28;
            // 
            // txtDateReceived
            // 
            this.txtDateReceived.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateReceived.Location = new System.Drawing.Point(681, 128);
            this.txtDateReceived.Multiline = true;
            this.txtDateReceived.Name = "txtDateReceived";
            this.txtDateReceived.Size = new System.Drawing.Size(287, 37);
            this.txtDateReceived.TabIndex = 27;
            // 
            // txtDateDelivery
            // 
            this.txtDateDelivery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateDelivery.Location = new System.Drawing.Point(206, 128);
            this.txtDateDelivery.Multiline = true;
            this.txtDateDelivery.Name = "txtDateDelivery";
            this.txtDateDelivery.Size = new System.Drawing.Size(287, 37);
            this.txtDateDelivery.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Date Received";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Date Delivery";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSearch.Location = new System.Drawing.Point(206, 29);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(287, 37);
            this.txtSearch.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Search";
            // 
            // btnSearch2
            // 
            this.btnSearch2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch2.BackColor = System.Drawing.Color.Turquoise;
            this.btnSearch2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch2.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearch2.IconColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch2.IconSize = 40;
            this.btnSearch2.Location = new System.Drawing.Point(499, 29);
            this.btnSearch2.Name = "btnSearch2";
            this.btnSearch2.Size = new System.Drawing.Size(40, 40);
            this.btnSearch2.TabIndex = 33;
            this.btnSearch2.TabStop = false;
            // 
            // FormCustomerSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1044, 617);
            this.Controls.Add(this.btnSearch2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDateReceived);
            this.Controls.Add(this.txtDateDelivery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormCustomerSale";
            this.Text = "FormCustomerSale";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtDateReceived;
        private System.Windows.Forms.TextBox txtDateDelivery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconPictureBox btnSearch2;
    }
}