using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Guna.UI2.WinForms;
using System.IO;
using System.Xml.Linq;
using System.Drawing.Imaging;
namespace kaenTaVen_V2
{
    public partial class StockManagement : Form
    {
        public static StockManagement instance;
        public DataGridView p;
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        public StockManagement()
        {
            InitializeComponent();
            instance = this;
            p = dataGridView1;
        }
        public void showProData()
        {


            string selectQuery = "SELECT * FROM View_Stock";
            cmd = new SqlCommand(selectQuery, con.conder);
            adt = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AllowUserToAddRows = false;

            table.Clear();
            adt.Fill(table);
            dataGridView1.DataSource = table;


            DataGridViewImageColumn imageColumn;
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[6];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;




            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ສະຕ໋ອກ";
            dataGridView1.Columns[3].HeaderText = "ຫົວໜ່ວຍ";
            dataGridView1.Columns[4].HeaderText = "ຕົ້ນທຶນ";
            dataGridView1.Columns[5].HeaderText = "ລາຄາຂາຍ";
            dataGridView1.Columns[6].HeaderText = "ຮູບ";


        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            con.Connect();
            showProData();
        }
        public System.Drawing.Image GetDataToImage(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as System.Drawing.Image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtproname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtQuantity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtUnit.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtinitprice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtsellprice.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            PicImg.Image = GetDataToImage((byte[])(dataGridView1.CurrentRow.Cells[6].Value));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Update tbProduct set initial_price= @init, sold_price= @sold where product_name = @name ", con.conder);
            cmd.Parameters.AddWithValue("@name", txtproname.Text);
            cmd.Parameters.AddWithValue("@init", txtinitprice.Text);
            cmd.Parameters.AddWithValue("@sold", txtsellprice.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
               
                MessageBox.Show("Update Price Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            showProData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string product_id;
            SqlCommand cmd = new SqlCommand("select product_id from tbProduct where product_name = @name", con.conder);
            cmd.Parameters.AddWithValue("@name", txtproname.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            product_id = Convert.ToString(dr[0]);



            dr.Close();
            cmd = new SqlCommand("Update tbStock set quantity = @quan where product_id = @id ", con.conder);
            cmd.Parameters.AddWithValue("@id", product_id);
            cmd.Parameters.AddWithValue("@quan", txtQuantity.Text);
           
            if(cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Update Stock Successfully","Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            showProData();
        }
    }
}
