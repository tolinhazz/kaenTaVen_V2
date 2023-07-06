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
    public partial class Addcustomer : Form
    {
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        public Addcustomer()
        {
            InitializeComponent();
            txtname.Focus();
        }
        

        private void Addcustomer_Load(object sender, EventArgs e)
        {
            con.Connect();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Insert into tbCustomer values(@name,@tel,@address)",con.conder);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@tel", txtTel.Text);
            cmd.Parameters.AddWithValue("@address", txtAddress.Text);

            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("ເພີ່ມລຸກຄ້າສຳເລັດ");
                DialogResult g = MessageBox.Show("ເຈົ້າຢາກເພີ່ມລູກຄ້າອີກບໍ່","ຄຳຖາມ",MessageBoxButtons.YesNo);
                if(g == DialogResult.No)
                {
                    this.Hide();
                    FormCustomers.cus.showCustomer();
                }
            }
         
        }
    }
}
