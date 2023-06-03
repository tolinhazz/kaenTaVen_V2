
namespace kaenTaVen_V2
{
    partial class FormAllSales
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrint.Location = new System.Drawing.Point(450, 515);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 23;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(64, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(888, 334);
            this.dataGridView1.TabIndex = 22;
            // 
            // txtDateReceived
            // 
            this.txtDateReceived.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateReceived.Location = new System.Drawing.Point(665, 74);
            this.txtDateReceived.Multiline = true;
            this.txtDateReceived.Name = "txtDateReceived";
            this.txtDateReceived.Size = new System.Drawing.Size(287, 37);
            this.txtDateReceived.TabIndex = 18;
            // 
            // txtDateDelivery
            // 
            this.txtDateDelivery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateDelivery.Location = new System.Drawing.Point(190, 74);
            this.txtDateDelivery.Multiline = true;
            this.txtDateDelivery.Name = "txtDateDelivery";
            this.txtDateDelivery.Size = new System.Drawing.Size(287, 37);
            this.txtDateDelivery.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(523, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Date Received";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date Delivery";
            // 
            // FormAllSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1044, 617);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDateReceived);
            this.Controls.Add(this.txtDateDelivery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormAllSales";
            this.Text = "FormAllSales";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
    }
}