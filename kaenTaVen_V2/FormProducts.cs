using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaenTaVen_V2
{
    public partial class FormInventory : Form
    {
       
        public FormInventory()
        {
            InitializeComponent();
            
        }
       

        private void btnInventory_Click(object sender, EventArgs e)
        {
            Form1.instance.OpenChildForm(new FormInventoryBtn());

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
    }
}
