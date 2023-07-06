using FontAwesome.Sharp;
using Guna.UI2.WinForms;
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
    public partial class Order_Detail : Form
    {
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;

        public Form currentChildForm;
        private Guna2Button currentBtn;


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

     
        }
        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Order_DetailPanel.Controls.Add(childForm);
            Order_DetailPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
       
            OpenChildForm(new Active());

        }

        private void unpaid_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Debt_Detail());
        }

        private void Undeliver_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Order_Deliver_Detail());
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        
        public void showdata()
        {
            adt = new SqlDataAdapter("Select  *  from View_Active_Order  WHERE CONVERT(date,date_recorded,105) = CONVERT(date,date_recorded,105);    ", con.conder);
            ds.Clear();
         
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ລູກຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ເລກບິນ";
            dataGridView1.Columns[3].HeaderText = "ລາຄາບິນ";
            dataGridView1.Columns[4].HeaderText = "ວັນທີອອກບິນ";
            dataGridView1.Columns[5].HeaderText = "ສະຖານະການຈ່າຍ";
            


            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 400;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 210;

        }

    

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Order_Detail_Load(object sender, EventArgs e)
        {
            con.Connect();
            showdata();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
        }
        public void searchCustomer()
        {
            if (txtSearch.Text != "")
            {
                DataSet d = new DataSet();

             //   cmd = new SqlCommand("Select * from View_Active_Order_Today where customer_name LIKE N'%"+ txtSearch.Text +"%'", con.conder);
          
         
                adt= new SqlDataAdapter("Select * from View_Active_Order_Today where customer_name LIKE N'%" + txtSearch.Text + "%'", con.conder);

                d.Clear();
                adt.Fill(d);
                dataGridView1.DataSource = d.Tables[0].DefaultView;
            }
            else
            {
                showdata();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            searchCustomer();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
           if(btnActive.ForeColor == Color.Red)
            {
                cmd = new SqlCommand("Update tbSales set payment_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                Active.act.showActiveOrder();
            }
           else if(btnUnpaid.ForeColor == Color.Red)
            {
                cmd = new SqlCommand("Update tbSales set payment_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                Debt_Detail.debt.showDebtData();

            }
            else if (btnUndeliver.ForeColor == Color.Red)
            {
                cmd = new SqlCommand("Update tbSales set payment_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                Order_Deliver_Detail.deliver.ShowDeliverOrder();
            }
            else
            {
                cmd = new SqlCommand("Update tbSales set payment_status = 1 where sales_id = @id ",con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                showdata();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (btnActive.ForeColor == Color.Red)
            {
                cmd = new SqlCommand("Update tbSales set delivery_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                Active.act.showActiveOrder();
            }
            else if (btnUnpaid.ForeColor == Color.Red)
            {
                cmd = new SqlCommand("Update tbSales set delivery_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                Debt_Detail.debt.showDebtData();

            }
            else if (btnUndeliver.ForeColor == Color.Red)
            {
                cmd = new SqlCommand("Update tbSales set delivery_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();    
                Order_Deliver_Detail.deliver.ShowDeliverOrder();
            }
            else
            {
                cmd = new SqlCommand("Update tbSales set delivery_status = 1 where sales_id = @id ", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();
                showdata();
            }
        }
    }
}
