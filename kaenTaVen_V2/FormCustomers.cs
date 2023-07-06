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
    public partial class FormCustomers : Form
    {
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;

        public static FormCustomers cus;
        public DataGridView dgv;
        public FormCustomers()
        {
            InitializeComponent();
            cus = this;
            dgv = dataGridView1;

        }
        public void showCustomer()
        {
            adt = new SqlDataAdapter("Select * from tbCustomer",con.conder);
            ds.Clear();
            adt.Fill(ds);
           dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            con.Connect();
            showCustomer();

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Addcustomer add=  new Addcustomer();
            add.ShowDialog();
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cmd = new SqlCommand("Update tbCustomer set customer_name =@name, tel = @tel, address= @address where customer_id=@id", con.conder);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@name", dataGridView1.CurrentRow.Cells[1].Value);
            cmd.Parameters.AddWithValue("@tel", dataGridView1.CurrentRow.Cells[2].Value);
            cmd.Parameters.AddWithValue("@address", dataGridView1.CurrentRow.Cells[3].Value);
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
                showCustomer();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Update tbCustomer set customer_name =@name, tel = @tel, address= @address where customer_id=@id",con.conder);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@name", dataGridView1.CurrentRow.Cells[1].Value);
            cmd.Parameters.AddWithValue("@tel", dataGridView1.CurrentRow.Cells[2].Value);
            cmd.Parameters.AddWithValue("@address", dataGridView1.CurrentRow.Cells[3].Value);
            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
                showCustomer();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete from tbCustomer where customer_id=@id", con.conder);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
 
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("ລົບຂໍ້ມູນສຳເລັດ");
                showCustomer();
            }
        }
    }
}
