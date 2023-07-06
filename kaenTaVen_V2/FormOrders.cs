using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Xml.Linq;

namespace kaenTaVen_V2
{
    public partial class FormOrders : Form
    {
        Connector con = new Connector();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        SqlCommand cmd;
        SqlDataAdapter adt = new SqlDataAdapter();

        public FormOrders()
        {
            InitializeComponent();
            


        }

        public void calculateTotal()
        {
            int sum = 0, i;
            for (i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(guna2DataGridView1.Rows[i].Cells[4].Value);
            }
            btnTotal.Text = "ຍອດລວມ: " + sum.ToString();
        }
        public void searchPhone()
        {
            SqlCommand cmd = new SqlCommand("select tel from tbCustomer", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbTel.Items.Add(dr[0].ToString());


            }
            dr.Close();
        }
        public void autoBillnum()
        {

            cmd = new SqlCommand("Select Top 1 invoice_id from tbInvoice Order by invoice_id DESC", con.conder);
            adt = new SqlDataAdapter(cmd);
            adt.Fill(ds);


            if (ds.Tables[0].Rows.Count > 0)
            {

                int new_id;
                string tmp_id = ds.Tables[0].Rows[0]["invoice_id"].ToString().Substring(3, 5);

                new_id = Convert.ToInt16(tmp_id) + 1;
                lblInvNum.Text = "INV" + new_id.ToString("000");

            }
            else
            {
                lblInvNum.Text = "INV001";
            }


        }
        

        public void select_product_Info()
        {


            string STR1 = "select product_name,Product_image from tbProduct where product_id=1";
            cmd = new SqlCommand(STR1, con.conder);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblLaiy.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                VenlaiyPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();

            string STR2 = "select product_name,Product_image from tbProduct where product_id=3";
            cmd = new SqlCommand(STR2, con.conder);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblLaiyNrk.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                LaiyNrkPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();

            string STR3 = "select product_name,Product_image from tbProduct where product_id=2";
            cmd = new SqlCommand(STR3, con.conder);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblDum.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                DumPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();


            string STR4 = "select product_name,Product_image from tbProduct where product_id=4";
            cmd = new SqlCommand(STR4, con.conder);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblBong.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                BongPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();

            string STR5 = "select product_name,Product_image from tbProduct where product_id=5";
            cmd = new SqlCommand(STR5, con.conder);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lbltao.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                LunTaoPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();


            string STR6 = "select product_name,Product_image from tbProduct where product_id=6";
            cmd = new SqlCommand(STR6, con.conder);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblDIn.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                DinPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();


            string STR7 = "select product_name,Product_image from tbProduct where product_id=7";
            cmd = new SqlCommand(STR7, con.conder);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                lblThart.Text = Convert.ToString(dr[0]);
                Byte[] byteBLOBData = new Byte[0];
                byteBLOBData = (Byte[])((byte[])dr[1]);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteBLOBData);
                ThartPic.Image = System.Drawing.Image.FromStream(ms);
            }
            dr.Close();

        }



        private void FormOrders_Load(object sender, EventArgs e)
        {


        }

        private void FormOrders_Load_1(object sender, EventArgs e)
        {
            con.Connect();
            autoBillnum();
            select_product_Info();
            searchPhone();
      
            lblJaiyKrn.Visible = false;
            txtFirstInstallment.Visible = false;
            lblfirstInstallTypeAlert.Visible = false;
            cbFirstInstallType.Visible = false;
            lblFirstInstallType.Visible = false;

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox11_KeyDown(object sender, KeyEventArgs e)
        {
            /*   if (e.KeyCode == Keys.Enter)
               {
                   string STR = "select customer_id,customer_name from tbCustomer where tel=@search";
                   cmd = new SqlCommand(STR, con.conder);
                   cmd.Parameters.AddWithValue("@search", txtsearch.Text);
                   dr = cmd.ExecuteReader();
                   if (dr.Read())
                   {
                       lblId.Text = Convert.ToString(dr[0]);
                       lblCusname.Text = Convert.ToString(dr[1]);
                   }
               }*/

        }

        private void txtsearch_Enter(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            int total = int.Parse(txtTavenPrice.Text) * int.Parse(txtTavenQuan.Text);


            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                        .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);

            guna2DataGridView1.Rows.Add(MaxID, lblLaiy.Text, txtTavenPrice.Text, txtTavenQuan.Text, total.ToString());

            txtPriceUnit.Text = txtTavenPrice.Text;
            txtQuanUnit.Text = txtTavenQuan.Text;
            txtTotal.Text = total.ToString();
            calculateTotal();








        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {


            int total = int.Parse(txtTavenLaiyPrice.Text) * int.Parse(txtTavenLaiyQuan.Text);

            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                       .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);

            guna2DataGridView1.Rows.Add(MaxID, lblLaiyNrk.Text, txtTavenLaiyPrice.Text, txtTavenLaiyQuan.Text, total.ToString());

            txtPriceUnit.Text = txtTavenLaiyPrice.Text;
            txtQuanUnit.Text = txtTavenLaiyQuan.Text;
            txtTotal.Text = total.ToString();
            calculateTotal();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {


            int total = int.Parse(txtDumPrice.Text) * int.Parse(txtDumQuan.Text);

            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                       .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);

            guna2DataGridView1.Rows.Add(MaxID, lblDum.Text, txtDumPrice.Text, txtDumQuan.Text, total.ToString());
            txtPriceUnit.Text = txtDumPrice.Text;
            txtQuanUnit.Text = txtDumQuan.Text;
            txtTotal.Text = total.ToString();

            calculateTotal();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {


            int total = int.Parse(txtBongPrice.Text) * int.Parse(txtBongQuan.Text);

            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                       .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);
            guna2DataGridView1.Rows.Add(MaxID, lblBong.Text, txtBongPrice.Text, txtBongQuan.Text, total.ToString());
            txtPriceUnit.Text = txtBongPrice.Text;
            txtQuanUnit.Text = txtBongQuan.Text;
            txtTotal.Text = total.ToString();
            calculateTotal();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {


            int total = int.Parse(txtTaoPrice.Text) * int.Parse(txtTaoQuan.Text);

            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                       .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);

            guna2DataGridView1.Rows.Add(MaxID, lbltao.Text, txtTaoPrice.Text, txtTaoQuan.Text, total.ToString());
            txtPriceUnit.Text = txtTaoPrice.Text;
            txtQuanUnit.Text = txtTaoQuan.Text;
            txtTotal.Text = total.ToString();
            calculateTotal();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            int total = int.Parse(txtDinPrice.Text) * int.Parse(txtDinQuan.Text);

            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                       .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);

            guna2DataGridView1.Rows.Add(MaxID, lblDIn.Text, txtDinPrice.Text, txtDinQuan.Text, total.ToString());
            txtPriceUnit.Text = txtDinPrice.Text;
            txtQuanUnit.Text = txtDinQuan.Text;
            txtTotal.Text = total.ToString();
            calculateTotal();
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {


            int total = int.Parse(txtThartPrice.Text) * int.Parse(txtThartQuan.Text);

            var MaxID = guna2DataGridView1.Rows.Cast<DataGridViewRow>()
                       .Max(r => Convert.ToInt32(r.Cells["Order_num"].Value) + 1);

            guna2DataGridView1.Rows.Add(MaxID, lblThart.Text, txtThartPrice.Text, txtThartQuan.Text, total.ToString());
            txtPriceUnit.Text = txtThartPrice.Text;
            txtQuanUnit.Text = txtThartQuan.Text;
            txtTotal.Text = total.ToString();
            calculateTotal();
        }

        private void guna2DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.guna2DataGridView1.SelectedRows.Count > 0)
            {
                if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblLaiy.Text)
                {
                    txtTavenQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtTavenPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtTavenPrice.Text;
                    txtQuanUnit.Text = txtTavenQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }

                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblLaiyNrk.Text)
                {
                    txtTavenLaiyQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtTavenLaiyPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtTavenLaiyPrice.Text;
                    txtQuanUnit.Text = txtTavenLaiyQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }

                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblDum.Text)
                {
                    txtDumQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtDumPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtDumPrice.Text;
                    txtQuanUnit.Text = txtDumQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }

                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblBong.Text)
                {
                    txtBongQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtBongPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtBongPrice.Text;
                    txtQuanUnit.Text = txtBongQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }

                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lbltao.Text)
                {
                    txtTaoQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtTaoPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtTaoPrice.Text;
                    txtQuanUnit.Text = txtTaoQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }

                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblDIn.Text)
                {
                    txtDinQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtDinPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtDinPrice.Text;
                    txtQuanUnit.Text = txtDinQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }

                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblThart.Text)
                {
                    txtThartQuan.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();

                    txtThartPrice.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();

                    int total = int.Parse(guna2DataGridView1.CurrentRow.Cells[3].Value.ToString()) * int.Parse(guna2DataGridView1.CurrentRow.Cells[2].Value.ToString());

                    guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                    txtPriceUnit.Text = txtThartPrice.Text;
                    txtQuanUnit.Text = txtThartQuan.Text;
                    txtTotal.Text = total.ToString();
                    calculateTotal();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
        }



        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblLaiy.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtTavenQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtTavenPrice.Text;

                int total = int.Parse(txtTavenPrice.Text) * int.Parse(txtTavenQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtTavenPrice.Text;
                txtQuanUnit.Text = txtTavenQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }
            else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblLaiyNrk.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtTavenLaiyQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtTavenLaiyPrice.Text;

                int total = int.Parse(txtTavenLaiyPrice.Text) * int.Parse(txtTavenLaiyQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtTavenLaiyPrice.Text;
                txtQuanUnit.Text = txtTavenLaiyQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }
            else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblDum.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtDumQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtDumPrice.Text;

                int total = int.Parse(txtDumPrice.Text) * int.Parse(txtDumQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtDumPrice.Text;
                txtQuanUnit.Text = txtDumQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }
            else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblBong.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtBongQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtBongPrice.Text;

                int total = int.Parse(txtBongPrice.Text) * int.Parse(txtBongQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtBongPrice.Text;
                txtQuanUnit.Text = txtBongQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }
            else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lbltao.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtTaoQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtTaoPrice.Text;

                int total = int.Parse(txtTaoPrice.Text) * int.Parse(txtTaoQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtTaoPrice.Text;
                txtQuanUnit.Text = txtTaoQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }
            else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblDIn.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtDinQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtDinPrice.Text;

                int total = int.Parse(txtDinPrice.Text) * int.Parse(txtDinQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtDinPrice.Text;
                txtQuanUnit.Text = txtDinQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }
            else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblThart.Text)
            {
                guna2DataGridView1.CurrentRow.Cells[3].Value = txtThartQuan.Text;

                guna2DataGridView1.CurrentRow.Cells[2].Value = txtThartPrice.Text;

                int total = int.Parse(txtThartPrice.Text) * int.Parse(txtThartQuan.Text);

                guna2DataGridView1.CurrentRow.Cells[4].Value = total.ToString();
                txtPriceUnit.Text = txtThartPrice.Text;
                txtQuanUnit.Text = txtThartQuan.Text;
                txtTotal.Text = total.ToString();
                calculateTotal();
            }

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (this.guna2DataGridView1.SelectedRows.Count > 0)
            {
                if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblLaiy.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtTavenPrice.Text = "";
                    txtTavenQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();
                }
                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblLaiyNrk.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtTavenLaiyPrice.Text = "";
                    txtTavenLaiyQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();
                }
                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblDum.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtDumPrice.Text = "";
                    txtDinQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();
                }
                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblBong.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtBongPrice.Text = "";
                    txtBongQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();
                }
                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lbltao.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtTaoPrice.Text = "";
                    txtTaoQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();
                }
                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblDIn.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtDinPrice.Text = "";
                    txtDinQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();
                }
                else if (guna2DataGridView1.CurrentRow.Cells[1].Value.ToString() == lblThart.Text)
                {
                    guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
                    txtPriceUnit.Text = "";
                    txtQuanUnit.Text = "";
                    txtThartPrice.Text = "";
                    txtThartQuan.Text = "";
                    txtTotal.Text = "";
                    calculateTotal();

                }

            }

        }

        private void DinPic_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtPriceUnit.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtQuanUnit.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTotal.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTel_KeyPress(object sender, KeyPressEventArgs e)
        {

            /*    string STR = "select tel from tbCustomer where tel=@search";
                cmd = new SqlCommand(STR, con.conder);
                cmd.Parameters.AddWithValue("@search", cbTel.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblId.Text = Convert.ToString(dr[0]);
                    lblCusname.Text = Convert.ToString(dr[1]);
                }*/
        }

        private void cbTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string STR = "select customer_id,customer_name from tbCustomer where tel=@search";
                cmd = new SqlCommand(STR, con.conder);
                cmd.Parameters.AddWithValue("@search", cbTel.Text);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblCusID.Text = Convert.ToString(dr[0]);
                    lblCusname.Text = Convert.ToString(dr[1]);
                }
                dr.Close();
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        public void InsertDatatoDatabase_UpdateStock()
        {
            //Insert into tbInvocie
            cmd = new SqlCommand("Insert into tbInvoice values (@InvID,@CusID,CURRENT_TIMESTAMP)", con.conder);
            cmd.Parameters.AddWithValue("@InvID", lblInvNum.Text);
            cmd.Parameters.AddWithValue("@CusID", lblCusID.Text);
            cmd.ExecuteNonQuery();
            for (int index = 0; index < guna2DataGridView1.Rows.Count - 1; index++)
            {


                string product_ID;
                string STR3 = "select product_id from tbProduct where product_name = N'" + guna2DataGridView1.Rows[index].Cells[1].Value + "'";
                cmd = new SqlCommand(STR3, con.conder);

                dr = cmd.ExecuteReader();
                dr.Read();
                product_ID = Convert.ToString(dr[0]);
                dr.Close();


                //Insert into Order_detail
                cmd = new SqlCommand("INSERT into Order_detail VALUES(@InvNum, @proID, @unitPrice,@quan,@subTotal)", con.conder);
                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);
                cmd.Parameters.AddWithValue("@proID", product_ID);
                cmd.Parameters.AddWithValue("@unitPrice", guna2DataGridView1.Rows[index].Cells[2].Value);
                cmd.Parameters.AddWithValue("@quan", guna2DataGridView1.Rows[index].Cells[3].Value);
                cmd.Parameters.AddWithValue("@subTotal", guna2DataGridView1.Rows[index].Cells[4].Value);

                cmd.ExecuteNonQuery();

                string stock_quan;
                string STR7 = "select quantity from tbStock where product_id = @ProID";
                SqlCommand cmd1 = new SqlCommand(STR7, con.conder);
                cmd1.Parameters.AddWithValue("@ProID", product_ID);
                //   cmd1.Parameters.AddWithValue("@ProID", );
                dr = cmd1.ExecuteReader();
                dr.Read();
                stock_quan = Convert.ToString(dr[0]);

                dr.Close();
                float quan = float.Parse(stock_quan) - float.Parse(guna2DataGridView1.Rows[index].Cells[3].Value.ToString());
                //Update Stock  Quantity
                SqlCommand cmd2 = new SqlCommand("Update tbStock set quantity = @quan where product_id = @id", con.conder);
                cmd2.Parameters.AddWithValue("@id", product_ID);
                cmd2.Parameters.AddWithValue("@quan", quan);
                if (cmd2.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(quan.ToString());
                    MessageBox.Show("Stock quantity has been deducted");
                }
                

            }
        }
        public void InsertDataTodatabse()
        {
            //Insert into tbInvocie
            cmd = new SqlCommand("Insert into tbInvoice values (@InvID,@CusID,CURRENT_TIMESTAMP)", con.conder);
            cmd.Parameters.AddWithValue("@InvID", lblInvNum.Text);
            cmd.Parameters.AddWithValue("@CusID", lblCusID.Text);
            cmd.ExecuteNonQuery();

            for (int index = 0; index < guna2DataGridView1.Rows.Count - 1; index++)
            {


                string product_ID;
                string STR3 = "select product_id from tbProduct where product_name = N'" + guna2DataGridView1.Rows[index].Cells[1].Value + "'";
                cmd = new SqlCommand(STR3, con.conder);

                dr = cmd.ExecuteReader();
                dr.Read();
                product_ID = Convert.ToString(dr[0]);
                dr.Close();


                //Insert into Order_detail
                cmd = new SqlCommand("INSERT into Order_detail VALUES(@InvNum, @proID, @unitPrice,@quan,@subTotal)", con.conder);
                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);
                cmd.Parameters.AddWithValue("@proID", product_ID);
                cmd.Parameters.AddWithValue("@unitPrice", guna2DataGridView1.Rows[index].Cells[2].Value);
                cmd.Parameters.AddWithValue("@quan", guna2DataGridView1.Rows[index].Cells[3].Value);
                cmd.Parameters.AddWithValue("@subTotal", guna2DataGridView1.Rows[index].Cells[4].Value);

                cmd.ExecuteNonQuery();
                
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (lblCusID.Text != "result cusID" && lblCusID.Text != "Result CusName")
            {


                string Payment_StatusID;

                if (cbReceivedChannel.Text == "ຝາກຂົນສົ່ງ")
                {
                    if (PayCheck.Checked == true && DeliverCheck.Checked == true)
                    {
                        if ( txtExpressOrig.Text != "" && txtExpressDes.Text != "")
                        {
                            if (cbPayType.Text != "")
                            {


                                InsertDatatoDatabase_UpdateStock();

                                string STR6 = "select payment_status_id from tbPaymentStatus where payment_status_name = @paystatusename";
                                cmd = new SqlCommand(STR6, con.conder);
                                cmd.Parameters.AddWithValue("@paystatusename", PayCheck.Text);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                Payment_StatusID = Convert.ToString(dr[0]);
                                dr.Close();





                                cmd = new SqlCommand("Insert into tbSales values (@InvNum,@paytypeID,@payStatusID,@totalBill,0 ,@delivery_status,@expressOri,CURRENT_TIMESTAMP,@expressDes,@receivedChannel)", con.conder);
                                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);
                                cmd.Parameters.AddWithValue("@paytypeID", cbPayType.Text);
                                cmd.Parameters.AddWithValue("@payStatusID", Payment_StatusID);
                                cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));

                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Ordered Successful");
                                    MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    autoBillnum();
                                }
                            }
                            else {
                                MessageBox.Show("Input to Payment Type");
                                lblPayTypeAlert.Visible = true;
                            }


                        }
                        else
                        {
                            MessageBox.Show("Input Neccessary info!!");
                         
                            label7.Visible = true;
                        }
                    }
                    else if (PayCheck.Checked == true && DeliverCheck.Checked == false)
                    {
                        if ( txtExpressOrig.Text != "" && txtExpressDes.Text != "")
                        {
                            if (cbPayType.Text != "")
                            {


                                string STR6 = "select payment_status_id from tbPaymentStatus where payment_status_name = @paystatusename";
                                cmd = new SqlCommand(STR6, con.conder);
                                cmd.Parameters.AddWithValue("@paystatusename", PayCheck.Text);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                Payment_StatusID = Convert.ToString(dr[0]);
                                dr.Close();


                                InsertDataTodatabse();

                                cmd = new SqlCommand("Insert into tbSales values (@InvNum,@paytypeID,@payStatusID,@totalBill,0,@delivery_status,@expressOri,null,@expressDes,@receivedChannel)", con.conder);
                                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);
                                cmd.Parameters.AddWithValue("@paytypeID", cbPayType.Text);
                                cmd.Parameters.AddWithValue("@payStatusID", Payment_StatusID);
                                cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Ordered Successful");
                                    MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    autoBillnum();
                                }
                            }
                            else
                            {
                                lblPayTypeAlert.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Input Neccessary info!!");
                            label7.Visible = true;
                     
                        }
                    }
                    else if (DebtCheck.Checked == true && DeliverCheck.Checked == true)
                    {
                        if (txtExpressOrig.Text != "" && txtExpressDes.Text != "")
                        {
                            if (txtFirstInstallment.Text == "0")
                            {
                                float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                                InsertDatatoDatabase_UpdateStock();
                                cmd = new SqlCommand("Insert into tbSales values(@InvNum,null,2,@totalBill,@first_install,@delivery_status,@expressOri,CURRENT_TIMESTAMP,@expressDes,@receivedChannel)", con.conder);
                                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                                cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                                cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Ordered Successful");
                                    MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    autoBillnum();
                                }

                            }

                            else if (txtFirstInstallment.Text != "0")
                            {
                                if (cbFirstInstallType.Text != "" && txtFirstInstallment.Text != "")
                                {


                                    float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                                    InsertDatatoDatabase_UpdateStock();
                                    cmd = new SqlCommand("Insert into tbSales values(@InvNum,@paytype,2,@totalBill,@first_install,@delivery_status,@expressOri,CURRENT_TIMESTAMP,@expressDes,@receivedChannel)", con.conder);
                                    cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                                    cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                    cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                    cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                    cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                    cmd.Parameters.AddWithValue("@paytype", cbFirstInstallType.Text);
                                    cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                                    cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Ordered Successful");
                                        MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        autoBillnum();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please Input Payment Type");
                                    lblfirstInstallAlert.Visible = true; 
                                }
                            }
                            
                        }
                    


                    else
                    {
                        MessageBox.Show("Input Neccessary info!!");
                        label7.Visible = true;
                    }
                

                    }
                    else if (DebtCheck.Checked == true && DeliverCheck.Checked == false)
                    {
                        if (txtExpressOrig.Text != "" && txtExpressDes.Text != "")
                        {
                            if (txtFirstInstallment.Text == "0")
                            {
                                float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                                InsertDatatoDatabase_UpdateStock();
                                cmd = new SqlCommand("Insert into tbSales values(@InvNum,null,2,@totalBill,@first_install,@delivery_status,@expressOri,null,@expressDes,@receivedChannel)", con.conder);
                                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                                cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                                cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Ordered Successful");
                                    MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    autoBillnum();
                                }

                            }

                            else if (txtFirstInstallment.Text != "0")
                            {
                                if (txtFirstInstallment.Text != "" && cbFirstInstallType.Text !="")
                                {


                                    float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                                    InsertDatatoDatabase_UpdateStock();
                                    cmd = new SqlCommand("Insert into tbSales values(@InvNum,@paytype,2,@totalBill,@first_install,@delivery_status,@expressOri,null,@expressDes,@receivedChannel)", con.conder);
                                    cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                                    cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                    cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                    cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                    cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                    cmd.Parameters.AddWithValue("@paytype", cbFirstInstallType.Text);
                                    cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                                    cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Ordered Successful");
                                        MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        autoBillnum();
                                    }
                                }
                               
                                else
                                {
                                    MessageBox.Show("Please Input Payment Type and installment");
                                    lblfirstInstallAlert.Visible = true;
                                    lblfirstInstallTypeAlert.Visible = true;
                                }
                                
                            
                               
                            }
                         }
                        else
                        {
                            MessageBox.Show("Input Neccessary info!!");
                            label7.Visible = true;
                        }
                    }
                   
                }
                else if (cbReceivedChannel.Text == "ມາເອົາເອງ")
                {
                    if (PayCheck.Checked == true && DeliverCheck.Checked == true)
                    {
                        if (cbPayType.Text != "")
                        {
                            string STR6 = "select payment_status_id from tbPaymentStatus where payment_status_name = @paystatusename";
                            cmd = new SqlCommand(STR6, con.conder);
                            cmd.Parameters.AddWithValue("@paystatusename", PayCheck.Text);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            Payment_StatusID = Convert.ToString(dr[0]);
                            dr.Close();
                            InsertDatatoDatabase_UpdateStock();

                            cmd = new SqlCommand("Insert into tbSales values (@InvNum,@paytypeID,@payStatusID,@totalBill,@first_install,@delivery_status,@expressOri,CURRENT_TIMESTAMP,@expressDes,@receivedChannel)", con.conder);
                            cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);
                            cmd.Parameters.AddWithValue("@paytypeID", cbPayType.Text);
                            cmd.Parameters.AddWithValue("@payStatusID", Payment_StatusID);
                            cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                            cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                            cmd.Parameters.AddWithValue("@first_install", txtFirstInstallment.Text);
                            cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                            cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                            cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Ordered Successful");
                                MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                autoBillnum();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Input Neccessary Information");
                            lblPayTypeAlert.Visible = true;
                        }
                    }
                    else if (PayCheck.Checked == true && DeliverCheck.Checked == false)
                    {
                        if (cbPayType.Text != "")
                        {
                            string STR6 = "select payment_status_id from tbPaymentStatus where payment_status_name = @paystatusename";
                            cmd = new SqlCommand(STR6, con.conder);
                            cmd.Parameters.AddWithValue("@paystatusename", PayCheck.Text);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            Payment_StatusID = Convert.ToString(dr[0]);
                            dr.Close();
                            InsertDatatoDatabase_UpdateStock();

                            cmd = new SqlCommand("Insert into tbSales values (@InvNum,@paytypeID,@payStatusID,@totalBill,@first_install,@delivery_status,@expressOri,null,@expressDes,@receivedChannel)", con.conder);
                            cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);
                            cmd.Parameters.AddWithValue("@paytypeID", cbPayType.Text);
                            cmd.Parameters.AddWithValue("@payStatusID", Payment_StatusID);
                            cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                            cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                            cmd.Parameters.AddWithValue("@first_install", txtFirstInstallment.Text);
                            cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                            cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                            cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Ordered Successful");
                                MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                autoBillnum();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Input Neccessary Information");
                            lblPayTypeAlert.Visible = true;
                        }
                    }
                    else if (DebtCheck.Checked == true && DeliverCheck.Checked == true)
                    {
                        if (txtFirstInstallment.Text == "0" && txtFirstInstallment.Text != "")
                        {
                            float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                            InsertDatatoDatabase_UpdateStock();
                            cmd = new SqlCommand("Insert into tbSales values(@InvNum,null,2,@totalBill,@first_install,@delivery_status,@expressOri,CURRENT_TIMESTAMP,@expressDes,@receivedChannel)", con.conder);
                            cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                            cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                            cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                            cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                            cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                            cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                            cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Ordered Successful");
                                MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                autoBillnum();
                            }

                        }


                        else if (txtFirstInstallment.Text != "0")
                        {
                            if (cbFirstInstallType.Text != "" && txtFirstInstallment.Text != "")
                            {


                                float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                                InsertDatatoDatabase_UpdateStock();
                                cmd = new SqlCommand("Insert into tbSales values(@InvNum,@paytype,2,@totalBill,@first_install,@delivery_status,@expressOri,CURRENT_TIMESTAMP,@expressDes,@receivedChannel)", con.conder);
                                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                                cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                cmd.Parameters.AddWithValue("@paytype", cbFirstInstallType.Text);
                                cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                                cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Ordered Successful");
                                    MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    autoBillnum();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Input Payment Type");
                                lblfirstInstallAlert.Visible = true;
                            }
                        }

                        }
                    else if (DebtCheck.Checked == true && DeliverCheck.Checked == false)
                    {

                        if (txtFirstInstallment.Text == "0")
                        {
                            float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                            InsertDatatoDatabase_UpdateStock();
                            cmd = new SqlCommand("Insert into tbSales values(@InvNum,null,2,@totalBill,@first_install,@delivery_status,@expressOri,null,@expressDes,@receivedChannel)", con.conder);
                            cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                            cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                            cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                            cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                            cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                            cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                            cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Ordered Successful");
                                MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                autoBillnum();
                            }

                        }

                        else if (txtFirstInstallment.Text != "0")
                        {
                            if (cbFirstInstallType.Text != "" && txtFirstInstallment.Text != "")
                            {


                                float Firstinstallment = float.Parse(txtFirstInstallment.Text);



                                InsertDatatoDatabase_UpdateStock();
                                cmd = new SqlCommand("Insert into tbSales values(@InvNum,@paytype,2,@totalBill,@first_install,@delivery_status,@expressOri,null,@expressDes,@receivedChannel)", con.conder);
                                cmd.Parameters.AddWithValue("@InvNum", lblInvNum.Text);

                                cmd.Parameters.AddWithValue("@expressOri", txtExpressOrig.Text);
                                cmd.Parameters.AddWithValue("@expressDes", txtExpressDes.Text);
                                cmd.Parameters.AddWithValue("@delivery_status", DeliverCheck.Text);
                                cmd.Parameters.AddWithValue("@receivedChannel", cbReceivedChannel.Text);
                                cmd.Parameters.AddWithValue("@paytype", cbFirstInstallType.Text);
                                cmd.Parameters.AddWithValue("@first_install", Firstinstallment);
                                cmd.Parameters.AddWithValue("@totalBill", float.Parse(btnTotal.Text.Substring(8)));
                                if (cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Ordered Successful");
                                    MessageBox.Show("Do you want to print bill?", "Print Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    autoBillnum();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Input Payment Type");
                                lblfirstInstallAlert.Visible = true;
                                lblfirstInstallTypeAlert.Visible = true;
                            }
                        }
                        }
                }
                else
                {
                    MessageBox.Show("Input Received Channel");
                    lblDeliverChannelAlert.Visible = true;


                }


            }
            else
            {
                MessageBox.Show("Make Sure that you Input Customer Information");

            }
        }



    
        

        private void guna2ShadowPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DebtCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DebtCheck.Checked == true)
            {
                txtFirstInstallment.Text = "0";
                lblSumlah.Visible = false;

                lblJaiyKrn.Visible = true;
                txtFirstInstallment.Visible = true;
                PayCheck.Visible = false;
                cbPayType.Visible = false;
                lblfirstInstallTypeAlert.Visible = false;
                cbFirstInstallType.Visible = false;
                lblFirstInstallType.Visible = false;
            }
            else if (DebtCheck.Checked == false)
            {
                lblJaiyKrn.Visible = true;
                txtFirstInstallment.Visible = true;
                PayCheck.Visible = true;
                lblSumlah.Visible = true;
                cbPayType.Visible = true;
                lblfirstInstallTypeAlert.Visible = false;
                cbFirstInstallType.Visible = false;
                lblFirstInstallType.Visible = false;
            }
        }

        private void txtTavenLaiyPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbReceivedChannel.Text == "ຝາກຂົນສົ່ງ")
            {
                PayCheck.Visible = true;
                cbPayType.Visible = true;
                lblJaiyKrn.Visible = true;
                DebtCheck.Visible = true;
                txtFirstInstallment.Visible = true;
                DeliverCheck.Visible = true;
                lblOrigin.Visible = true;
                txtExpressOrig.Visible = true;
                lbldestination.Visible = true;
                lblSumlah.Visible = true;
                txtExpressDes.Visible = true;
            }
            else if (cbReceivedChannel.Text == "ມາເອົາເອງ")
            {
                PayCheck.Visible = true;
                cbPayType.Visible = true;
                lblSumlah.Visible = true;
                lblJaiyKrn.Visible = true;
                DebtCheck.Visible = true;
                txtFirstInstallment.Visible = true;
                DeliverCheck.Visible = true;
                lblOrigin.Visible = false;
                txtExpressOrig.Visible = false;
                lbldestination.Visible = false;
                txtExpressDes.Visible = false;
            }
        }

        private void PayCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PayCheck.Checked == true)
            {
                DebtCheck.Visible = false;
                lblJaiyKrn.Visible = false;
                txtFirstInstallment.Visible = false;
                lblfirstInstallTypeAlert.Visible = false;
                cbFirstInstallType.Visible = false;
                lblFirstInstallType.Visible = false;
            }
            else if (PayCheck.Checked == false)
            {
                DebtCheck.Visible = true;
                lblJaiyKrn.Visible = true;
                txtFirstInstallment.Visible = true;
                
                cbFirstInstallType.Visible = false;
                lblFirstInstallType.Visible = false;
                lblPayTypeAlert.Visible=false;
            }
        }

        private void DeliverCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(DeliverCheck.Checked == true)
            {
                DeliverCheck.Text = "ສົ່ງສິນຄ້າແລ້ວ";
            }
            else if(DeliverCheck.Checked == false)
            {
                DeliverCheck.Text = "ຍັງບໍ່ທັນສົ່ງ";
            }
        }

        private void txtExpressOrig_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void txtExpressDes_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void cbPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPayTypeAlert.Visible=false;
        }

        private void cbFirstInstallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblfirstInstallTypeAlert.Visible=false;
        }

        private void txtFirstInstallment_TextChanged(object sender, EventArgs e)
        {
            cbFirstInstallType.Visible = true;
            lblFirstInstallType.Visible = true;
            lblfirstInstallAlert.Visible = false;
        }
    }
    }



