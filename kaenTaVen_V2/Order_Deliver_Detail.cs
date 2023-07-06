using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using System.Data.SqlClient;

namespace kaenTaVen_V2
{
    public partial class Order_Deliver_Detail : Form
    {
        public static Order_Deliver_Detail deliver;
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        public Order_Deliver_Detail()
        {
            InitializeComponent();
            dataGridView1.Dock = DockStyle.Fill;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        
        public void ShowDeliverOrder()
        {
            adt = new SqlDataAdapter("select  * from View_Order_Deliver_detail  where delivery_status = N'ຍັງບໍ່ທັນສົ່ງ'", con.conder);
            ds.Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Order_Deliver_Detail_Load(object sender, EventArgs e)
        {
            con.Connect();
            ShowDeliverOrder();
        }
    }
}
