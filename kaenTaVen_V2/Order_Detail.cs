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
using System.Windows.Forms;

namespace kaenTaVen_V2
{
    public partial class Order_Detail : Form
    {
        public static Order_Detail inst;
        public Guna2ShadowPanel p;
        // Fields


        public Order_Detail()
        {
            InitializeComponent();
            inst = this;



            //instance = this;
            p = Order_DetailPanel;
        
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            guna2DataGridView1.Dock = DockStyle.Fill;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button2.Checked = false;
            guna2Button1.Checked = true;
            guna2Button3.Checked = false;
            Active act = new Active();
            act.TopLevel = false;
            act.FormBorderStyle = FormBorderStyle.None;
            act.Dock = DockStyle.Fill;
            Order_DetailPanel.Controls.Add(act);
            Order_DetailPanel.Tag = act;
            act.BringToFront();
            act.Show();

        }

        private void unpaid_Click(object sender, EventArgs e)
        {
            guna2Button2.Checked = true;
            guna2Button1.Checked = false;
            guna2Button3.Checked = false;

            Debt_Detail d = new Debt_Detail();
            d.TopLevel = false;
            d.FormBorderStyle = FormBorderStyle.None;
            d.Dock = DockStyle.Fill;
            Order_DetailPanel.Controls.Add(d);
            Order_DetailPanel.Tag = d;
            d.BringToFront();
            d.Show();
        }

        private void Undeliver_Click(object sender, EventArgs e)
        {
            guna2Button2.Checked = false;
            guna2Button1.Checked = false;
            guna2Button3.Checked = true;

            Order_Deliver_Detail Deliver = new Order_Deliver_Detail();
            Deliver.TopLevel = false;
            Deliver.FormBorderStyle = FormBorderStyle.None;
            Deliver.Dock = DockStyle.Fill;
            Order_DetailPanel.Controls.Add(Deliver);
            Order_DetailPanel.Tag = Deliver;
            Deliver.BringToFront();
            Deliver.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Active_Order_Load(object sender, EventArgs e)
        {

        }
    }
}
