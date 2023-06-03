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
    public partial class FormInventoryBtn : Form
    {
        public FormInventoryBtn()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Form1.instance.OpenChildForm(new FormInventory());
        }

        private void FormInventoryBtn_Load(object sender, EventArgs e)
        {

        }
    }
}
