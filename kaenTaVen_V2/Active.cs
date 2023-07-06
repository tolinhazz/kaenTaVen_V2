using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kaenTaVen_V2
{
    public partial class Active : Form
    {
        public static Active act;
        
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        public Active()
        {
            InitializeComponent();
            dataGridView1.Dock = DockStyle.Fill;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        public void showActiveOrder()
        {
            adt = new SqlDataAdapter("select  * from View_Active_Order  where payment_status_name = N'ຕິດໜີ້' Or delivery_status= N'ຍັງບໍ່ທັນສົ່ງ'", con.conder);
            ds.Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.EnableHeadersVisualStyles = false;
          /*  dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ລູກຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ເລກບິນ";
            dataGridView1.Columns[3].HeaderText = "ລາຄາບິນ";
            dataGridView1.Columns[4].HeaderText = "ວັນທີອອກບິນ";
            dataGridView1.Columns[5].HeaderText = "ສະຖານະການຈ່າຍ";
            dataGridView1.Columns[6].HeaderText = "ປະເພດການຈ່າຍ";
            dataGridView1.Columns[7].HeaderText = "ສະຖານະການສົ່ງເຄື່ອງ";
            dataGridView1.Columns[8].HeaderText = "ມື້ຝາກເຄື່ອງ";*/


            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 400;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;
        }


        private void Active_Load(object sender, EventArgs e)
        {
            con.Connect();
            showActiveOrder();

        }
    }
}
