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
    public partial class FormExpense : Form
    {
        public FormExpense()
        {
            InitializeComponent();
        }

        private void FormExpense_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Form1.instance.OpenChildForm(new FormInventory());
        }
    }
}
