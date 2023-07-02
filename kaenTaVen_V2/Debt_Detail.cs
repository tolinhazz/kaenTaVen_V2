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
    public partial class Debt_Detail : Form
    {
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        public Debt_Detail()
        {
            InitializeComponent();
            dataGridView1.Dock= DockStyle.Fill;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        public void showDebtData()
        {
            adt = new SqlDataAdapter("Select * from View_Debt_Detail where payment_status_name = N'ຕິດໜີ້'",con.conder);
            ds.Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Debt_Detail_Load(object sender, EventArgs e)
        {
            con.Connect();
            showDebtData();

        }
    }
}
