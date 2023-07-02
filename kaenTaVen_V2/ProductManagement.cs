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

    /*public class product
    {
        *//*public string Id { get; set; }
        public string Name { get; set;}

        public byte[] Pic { get; set; }*//*
    }*/
    public partial class ProductManagement : Form
    {
        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds= new DataSet();
        SqlDataReader dr;


        public ProductManagement()
        {
            InitializeComponent();
        }

        public void showProData()
        {
           
           
            string selectQuery = "SELECT * FROM View_Product_Detail";
            cmd = new SqlCommand(selectQuery, con.conder);
            adt = new SqlDataAdapter(cmd);
            /*  List<product> list = new List<product>();
              while (reader.Read())
              {
                  product item = new product();
                  item.Id = reader[0].ToString();
                  item.Name = reader[1].ToString();
                  item.Pic = Byte.Parse(reader[6].ToString());
              }*/

            DataTable table = new DataTable();
            table.Clear();
            adt.Fill(table);
            dataGridView1.DataSource = table;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AllowUserToAddRows = false;


            
            DataGridViewImageColumn imageColumn;
            imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[6
                
                
                ];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;




            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns[0].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ຫົວໜ່ວຍ";
            dataGridView1.Columns[3].HeaderText = "ປະເພດ";
            dataGridView1.Columns[4].HeaderText = "ລາຄາຕົ້ນທຶນ";
            dataGridView1.Columns[5].HeaderText = "ລາຄາຂາຍ";
            dataGridView1.Columns[6].HeaderText = "ຮູບ";


        }


        public void load_unit()
        {
           
            SqlCommand cmd = new SqlCommand("select unit_name from tbProductUnit", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbunit.Items.Add(dr[0].ToString());


            }
            dr.Close();
            
        }
        public void load_Category()
        {
            
            SqlCommand cmd = new SqlCommand("select category_name from tbProductCategory", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbCate.Items.Add(dr[0].ToString());


            }
            dr.Close();
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {
            con.Connect();
            showProData();
            load_unit();
            load_Category();


        }
        string img;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    img = openFileDialog.FileName;
                    PicImg.Image = System.Drawing.Image.FromFile(img);
                }

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            MemoryStream ms = new MemoryStream();
            PicImg.Image.Save(ms, PicImg.Image.RawFormat);
            byte[] img = ms.ToArray();

            string unitID, cateID;
            string STR = "select unit_id from tbProductUnit where unit_name = @unitname";
            cmd = new SqlCommand(STR, con.conder);
            cmd.Parameters.AddWithValue("@unitname", cbunit.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            unitID = Convert.ToString(dr[0]);
            dr.Close();
            string STR1 = "select category_id from tbProductCategory where category_name = @cate_name";
            cmd = new SqlCommand(STR1, con.conder);
            cmd.Parameters.AddWithValue("@cate_name", cbCate.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            cateID = Convert.ToString(dr[0]);
            dr.Close();
                cmd.Parameters.Add(new SqlParameter("@Pro_name", SqlDbType.NVarChar));
                cmd = new SqlCommand("Insert into tbProduct values(@Pro_name, @Pro_unit,@Pro_cate, @Pro_initPrice, @Pro_soldPrice,@image)", con.conder);
                cmd.Parameters.AddWithValue("@Pro_name", txtname.Text);
                cmd.Parameters.AddWithValue("@Pro_unit", unitID);
                cmd.Parameters.AddWithValue("@Pro_cate", cateID);
                cmd.Parameters.AddWithValue("@Pro_initPrice", txtInitprice.Text);
                cmd.Parameters.AddWithValue("@Pro_soldPrice", txtSellPrice.Text);
                cmd.Parameters.AddWithValue("@image", img);
                
            
         
            cmd.ExecuteNonQuery();
            showProData();

            //===================================product_id==============================================
            string product_id; 
            string STR5 = "select product_id from tbProduct where product_name = @pro_name";
            cmd = new SqlCommand(STR5, con.conder);
            cmd.Parameters.AddWithValue("@pro_name", txtname.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            product_id = Convert.ToString(dr[0]);
            dr.Close();

            cmd = new SqlCommand("Insert into tbStock values(@productID,0)", con.conder);
            cmd.Parameters.AddWithValue("@productID", product_id);
            cmd.ExecuteNonQuery();
            
        }

        private void cbunit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
                cmd = new SqlCommand("delete from tbStock where product_id = @id",con.conder);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery ();

                cmd = new SqlCommand("delete from tbProduct where product_id = @id", con.conder);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                showProData();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cbunit.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbCate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtInitprice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSellPrice.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            PicImg.Image = GetDataToImage((byte[])(dataGridView1.CurrentRow.Cells[6].Value));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            PicImg.Image.Save(ms, PicImg.Image.RawFormat);
            byte[] img = ms.ToArray();

            string unitID, cateID, productID;
            string STR = "select unit_id from tbProductUnit where unit_name = @unitname";
            cmd = new SqlCommand(STR, con.conder);
            cmd.Parameters.AddWithValue("@unitname", cbunit.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            unitID = Convert.ToString(dr[0]);
            dr.Close();
            string STR1 = "select category_id from tbProductCategory where category_name = @cate_name";
            cmd = new SqlCommand(STR1, con.conder);
            cmd.Parameters.AddWithValue("@cate_name", cbCate.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            cateID = Convert.ToString(dr[0]);
            dr.Close();
            string STR2 = "select product_id from tbProduct where product_name = @pro_name";
            cmd = new SqlCommand(STR2, con.conder);
            cmd.Parameters.AddWithValue("@pro_name", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            dr = cmd.ExecuteReader();
            dr.Read();
            productID = Convert.ToString(dr[0]);
            dr.Close();


        
              

                cmd = new SqlCommand("update tbProduct set product_name = @name, unit_id = @unitID, category_id= @cateID, initial_price = @initPrice, sold_price = @soldPrice, Product_image = @image where product_id = @id", con.conder);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@id", productID);
            
              
                cmd.Parameters.AddWithValue("@unitID", unitID);
         
                cmd.Parameters.AddWithValue("@cateID", cateID);
            cmd.Parameters.AddWithValue("@initPrice", txtInitprice.Text);
            cmd.Parameters.AddWithValue("@soldPrice", txtSellPrice.Text);
            cmd.Parameters.AddWithValue("@image", img);
            
          
            cmd.ExecuteNonQuery();
            showProData();
        }
    }
}
