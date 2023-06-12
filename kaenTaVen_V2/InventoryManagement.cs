using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace kaenTaVen_V2
{
    public partial class FormInventory : Form
    {
        public Form currentChildForm;
        private Guna2TileButton currentBtn;

        public FormInventory()
        {
            InitializeComponent();
            
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Guna2TileButton)senderBtn;
                currentBtn.FillColor = RGBColors.color1;
                currentBtn.ForeColor = Color.White;


              
          
            }
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(0, 128, 0);
            public static Color color2 = Color.WhiteSmoke;
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.FillColor = RGBColors.color2;
                currentBtn.ForeColor = Color.Black;


            }
        }
        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            guna2Panel1.Controls.Add(childForm);
            guna2Panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnInventory_Click(object sender, EventArgs e)
        {
          

        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Form1.instance.OpenChildForm(new FormExpense());
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormInventory_Load(object sender, EventArgs e)
        {

        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ProductManagement());
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new StockManagement());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            

        }
    }
}
