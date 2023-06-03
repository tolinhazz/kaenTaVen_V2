
namespace kaenTaVen_V2
{
    partial class FormSetting
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
            this.SuspendLayout();
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Black;
            this.lblTitleChildForm.Location = new System.Drawing.Point(460, 298);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(101, 21);
            this.lblTitleChildForm.TabIndex = 3;
            this.lblTitleChildForm.Text = "Setting Der";
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1044, 617);
            this.Controls.Add(this.lblTitleChildForm);
            this.Name = "FormSetting";
            this.Text = "FormSetting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleChildForm;
    }
}