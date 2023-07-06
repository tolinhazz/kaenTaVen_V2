using Microsoft.Reporting.WinForms;
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
    public partial class FormReport : Form
    {
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        public FormReport()
        {
            InitializeComponent();
        }

        private void btnAllSales_Click(object sender, EventArgs e)
        {
        
        }

        private void btnCustomerSaleDetail_Click(object sender, EventArgs e)
        {
     
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            con.Connect();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /*Report_Sales r= new Report_Sales();
            r.Show();

            cmd = new SqlCommand("Select * from View_Active_Order", con.conder);
            adt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adt.Fill(dt);


            Report_Sales.instance.report.LocalReport.DataSources.Clear();

            ReportDataSource source = new ReportDataSource("DataSet2", dt);
            Report_Sales.instance.report.LocalReport.ReportPath = @"C:\\Users\\anoul\\source\\repos\\tolinhazz\\kaenTaVen_V2\\kaenTaVen_V2\Report1.rdlc";
            Report_Sales.instance.report.LocalReport.DataSources.Add(source);
            Report_Sales.instance.report.RefreshReport();
*/
        }
    }
}
