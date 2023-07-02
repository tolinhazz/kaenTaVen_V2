using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup.Localizer;
using System.Xml.Linq;

namespace kaenTaVen_V2
{
    public partial class FormInventory : Form
    {
        public static FormInventory instance;
        public Form currentChildForm;
        private Guna2TileButton currentBtn;

        Connector con = new Connector();
        SqlDataAdapter adt = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        SqlDataReader dr;

        public FormInventory()
        {
            InitializeComponent();
            rdbDeliverCheck.Checked = false;
            rdbPaymentCheck.Checked = false;
            guna2DataGridView1.ClearSelection();
            instance = this;


        }
        public void showOrderData()
        {



            string selectQuery = "SELECT * FROM View_PurchaseOrder";
            cmd = new SqlCommand(selectQuery, con.conder);
            adt = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.RowTemplate.Height = 100;
            guna2DataGridView1.AllowUserToAddRows = false;

            table.Clear();
            adt.Fill(table);
            guna2DataGridView1.DataSource = table;



            /*
                        guna2DataGridView1.EnableHeadersVisualStyles = false;
                        guna2DataGridView1.Columns[0].HeaderText = "ລະຫັດ";
                        guna2DataGridView1.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
                        guna2DataGridView1.Columns[2].HeaderText = "ສະຕ໋ອກ";
                        guna2DataGridView1.Columns[3].HeaderText = "ຕົ້ນທຶນ";
                        guna2DataGridView1.Columns[4].HeaderText = "ລາຄາຂາຍ";
                        guna2DataGridView1.Columns[5].HeaderText = "ຮູບ";*/


        }
        public void showProData()
        {



            string selectQuery = "SELECT * FROM View_PurchaseOrder where payment_status_name = N'ຕິດໜີ້' Or delivery_status_name = N'ຍັງບໍ່ໄດ້ຮັບສິນຄ້າ'";
            cmd = new SqlCommand(selectQuery, con.conder);
            adt = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();

            guna2DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            guna2DataGridView1.RowTemplate.Height = 100;
            guna2DataGridView1.AllowUserToAddRows = false;

            table.Clear();
            adt.Fill(table);
            guna2DataGridView1.DataSource = table;



            /*
                        guna2DataGridView1.EnableHeadersVisualStyles = false;
                        guna2DataGridView1.Columns[0].HeaderText = "ລະຫັດ";
                        guna2DataGridView1.Columns[1].HeaderText = "ຊື່ສິນຄ້າ";
                        guna2DataGridView1.Columns[2].HeaderText = "ສະຕ໋ອກ";
                        guna2DataGridView1.Columns[3].HeaderText = "ຕົ້ນທຶນ";
                        guna2DataGridView1.Columns[4].HeaderText = "ລາຄາຂາຍ";
                        guna2DataGridView1.Columns[5].HeaderText = "ຮູບ";*/


        }

        public void InsertProductName()
        {
            SqlCommand cmd = new SqlCommand("select product_name from tbProduct", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbProName.Items.Add(dr[0].ToString());


            }
            dr.Close();


        }
        public void load_Exhanger()
        {

            SqlCommand cmd = new SqlCommand("select Exchanger_name from tbLaoThaiExchange", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbExchanger.Items.Add(dr[0].ToString());


            }
            dr.Close();

        }
        public void load_Express()
        {

            SqlCommand cmd = new SqlCommand("select E_name from tbLaoThaiExpress", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbExpress.Items.Add(dr[0].ToString());


            }
            dr.Close();
        }
        public void load_supplier()
        {

            SqlCommand cmd = new SqlCommand("select supplier_name from tbSupplier", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbSupplier.Items.Add(dr[0].ToString());


            }
            dr.Close();
        }
        public void load_PayType()
        {

            SqlCommand cmd = new SqlCommand("select payment_type_name from tbPaymentType", con.conder);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbPayType.Items.Add(dr[0].ToString());


            }
            dr.Close();
        }


        public void Insert()
        {
            string productname, supplierName, paymentType, paymentStatus, receievStatus, exchagner, express;

            //===================================productname==============================================
            string STR = "select product_id from tbProduct where product_name = @Pro_name";
            cmd = new SqlCommand(STR, con.conder);
            cmd.Parameters.AddWithValue("@Pro_name", cbProName.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            productname = Convert.ToString(dr[0]);
            dr.Close();
            //===================================supplierName==============================================
            string STR1 = "select supplier_id from tbSupplier where supplier_name = @supplier_name";
            cmd = new SqlCommand(STR1, con.conder);
            cmd.Parameters.AddWithValue("@supplier_name", cbSupplier.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            supplierName = Convert.ToString(dr[0]);
            dr.Close();
            //===================================ExchangerName==============================================
            string STR5 = "select Exchanger_id from tbLaoThaiExchange where Exchanger_name = @Exchanger_name";
            cmd = new SqlCommand(STR5, con.conder);
            cmd.Parameters.AddWithValue("@Exchanger_name", cbExchanger.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            exchagner = Convert.ToString(dr[0]);
            dr.Close();
            //===================================paymentType==============================================
            string STR2 = "select payment_type_id from tbPaymentType where payment_type_name = @payment_type_name";
            cmd = new SqlCommand(STR2, con.conder);
            cmd.Parameters.AddWithValue("@payment_type_name", cbPayType.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            paymentType = Convert.ToString(dr[0]);
            dr.Close();

            //====================================paymentStatus=============================================

            if (rdbPaymentCheck.Checked == false)
            {
                rdbPaymentCheck.Text = "ຕິດໜີ້";
                string STR3 = "select payment_status_id from tbPaymentStatus where payment_status_name = @payment_status_name";
                cmd = new SqlCommand(STR3, con.conder);
                cmd.Parameters.AddWithValue("@payment_status_name", rdbPaymentCheck.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                paymentStatus = Convert.ToString(dr[0]);
                dr.Close();
            }
            else
            {
                string STR3 = "select payment_status_id from tbPaymentStatus where payment_status_name = @payment_status_name";
                cmd = new SqlCommand(STR3, con.conder);
                cmd.Parameters.AddWithValue("@payment_status_name", rdbPaymentCheck.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                paymentStatus = Convert.ToString(dr[0]);
                dr.Close();
            }


            //====================================receievStatus=============================================
            if (rdbDeliverCheck.Checked == false)
            {
                rdbDeliverCheck.Text = "ຍັງບໍ່ໄດ້ຮັບສິນຄ້າ";

                string STR4 = "select delivery_status_id from tbCheckDeliverStatus where delivery_status_name = @delivery_status_name";
                cmd = new SqlCommand(STR4, con.conder);
                cmd.Parameters.AddWithValue("@delivery_status_name", rdbDeliverCheck.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                receievStatus = Convert.ToString(dr[0]);
                dr.Close();
            }
            else
            {
                string STR4 = "select delivery_status_id from tbCheckDeliverStatus where delivery_status_name = @delivery_status_name";
                cmd = new SqlCommand(STR4, con.conder);
                cmd.Parameters.AddWithValue("@delivery_status_name", rdbDeliverCheck.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                receievStatus = Convert.ToString(dr[0]);
                dr.Close();
            }
            //===================================Express Name==============================================
            string STR7 = "select E_id from tbLaoThaiExpress where E_name = @E_name";
            cmd = new SqlCommand(STR7, con.conder);
            cmd.Parameters.AddWithValue("@E_name", cbExpress.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            express = Convert.ToString(dr[0]);
            dr.Close();
            //====================================Insert Data to tbPurchaseOrder=============================================

            cmd = new SqlCommand("Insert into tbPurchaseOrder values(@Proname,@Quan, @total,@SupName,@ExchangerName,CURRENT_TIMESTAMP, @PayType,@PayStatus,@ReceivedStatus, @Express_name,@Express_fee)", con.conder);
            cmd.Parameters.AddWithValue("@Proname", productname);
            cmd.Parameters.AddWithValue("@Quan", txtquan.Text);
            cmd.Parameters.AddWithValue("@total", txtcost.Text);
            cmd.Parameters.AddWithValue("@SupName", supplierName);
            cmd.Parameters.AddWithValue("@ExchangerName", exchagner);
            cmd.Parameters.AddWithValue("@PayType", paymentType);
            cmd.Parameters.AddWithValue("@PayStatus", paymentStatus);
            cmd.Parameters.AddWithValue("@ReceivedStatus", receievStatus);
            cmd.Parameters.AddWithValue("@Express_name", express);
            cmd.Parameters.AddWithValue("@Express_fee", txtExpressFee.Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Insert successfully");
                showProData();
            }


        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Guna2TileButton)senderBtn;
                currentBtn.FillColor = RGBColors.color1;
                currentBtn.ForeColor = Color.White;




            }
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(0, 128, 0);
            public static Color color2 = Color.WhiteSmoke;
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.FillColor = RGBColors.color2;
                currentBtn.ForeColor = Color.Black;


            }
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
            guna2Panel1.Controls.Add(childForm);
            guna2Panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnInventory_Click(object sender, EventArgs e)
        {


        }

        private void btnExpense_Click(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormInventory_Load(object sender, EventArgs e)
        {
            con.Connect();
            showProData();
            load_Exhanger();
            load_Express();
            load_supplier();
            load_PayType();
            InsertProductName();
            lblStock.Visible = false;
            lblStockQuan.Visible = false;



        }

        private void guna2TileButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new ProductManagement());
        }

        private void guna2TileButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new StockManagement());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            StockManagement st = new StockManagement();
            st.ShowDialog();
            st.Size = new Size(1560, 1560);
        }
        public void showStock()
        {

            string Stock_quantity, product_id;
            ///================================== Find ProductID ==============================================

            string STR8 = "select product_id from tbProduct where product_name = @name";
            SqlCommand cmd2 = new SqlCommand(STR8, con.conder);
            cmd2.Parameters.AddWithValue("@name", cbProName.Text);
            dr = cmd2.ExecuteReader();
            dr.Read();
            product_id = Convert.ToString(dr[0]);
            dr.Close();
            ///==================================Find StockQuantity==============================================
            string STR7 = "select quantity from tbStock where product_id = @ProID";
            SqlCommand cmd1 = new SqlCommand(STR7, con.conder);
            cmd1.Parameters.AddWithValue("@ProID", product_id);
            //   cmd1.Parameters.AddWithValue("@ProID", );
            dr = cmd1.ExecuteReader();
            dr.Read();
            lblStockQuan.Text = Convert.ToString(dr[0]);
      
            dr.Close();
        }
        int selectedID, rowIndex, scrollIndex;
        bool IsSelectedRow;
        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cbProName.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtcost.Text = guna2DataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtquan.Text = guna2DataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbSupplier.Text = guna2DataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbPayType.Text = guna2DataGridView1.CurrentRow.Cells[7].Value.ToString();
            cbExchanger.Text = guna2DataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbExpress.Text = guna2DataGridView1.CurrentRow.Cells[10].Value.ToString();
            txtExpressFee.Text = guna2DataGridView1.CurrentRow.Cells[11].Value.ToString();

            showStock();
            lblStock.Visible = true;
            lblStockQuan.Visible = true;

            btnConvfirm.Text = "ອັບເດດການສັ່ງຊື້";




            if (e.RowIndex < 0)
            {


                selectedID = (int)guna2DataGridView1.SelectedRows[0].Cells[0].Value;
                scrollIndex = guna2DataGridView1.FirstDisplayedScrollingRowIndex;
                IsSelectedRow = true;
            }



            if (guna2DataGridView1.CurrentRow.Cells[8].Value.ToString() == "ຈ່າຍແລ້ວ")
            {
                rdbPaymentCheck.Checked = true;


            }

            else
            {
                rdbPaymentCheck.Checked = false;

            }

            if (guna2DataGridView1.CurrentRow.Cells[9].Value.ToString() == "ຮັບສິນຄ້າແລ້ວ")
            {
                rdbDeliverCheck.Checked = true;
            }

            else
            {
                rdbDeliverCheck.Checked = false;



            }

        }

        private void rdbDeliverCheck_CheckedChanged(object sender, EventArgs e)
        {
            /* if (guna2DataGridView1.SelectedRows.Count > 0)
             {

                 string id;
             string STR = "select purchase_order from purchase_bill where purchase_bil_id = @id";
             cmd = new SqlCommand(STR, con.conder);
             cmd.Parameters.AddWithValue("@id", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
             dr = cmd.ExecuteReader();
             dr.Read();
             id = Convert.ToString(dr[0]);
             dr.Close();
             if (rdbDeliverCheck.Checked == true)
             {

                 cmd = new SqlCommand("update tbPurchaseOrder set received_status = 3 where purchase_order_id = @order_id ", con.conder);
                 cmd.Parameters.AddWithValue("@order_id", id);
                 cmd.ExecuteNonQuery();
                 showProData();
             }
             else if(rdbDeliverCheck.Checked == false)
             {
                 cmd = new SqlCommand("update tbPurchaseOrder set received_status = 4 where purchase_order_id = @order_id", con.conder);
                 cmd.Parameters.AddWithValue("@order_id", id);
                 cmd.ExecuteNonQuery();
                 showProData();
             }
              }
             else
             {

             }*/

        }

        private void rdbDeliverCheck_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void rdbDeliverCheck_CheckStateChanged(object sender, EventArgs e)
        {

        }
        /*
                if (guna2DataGridView1.Rows.Count > 0)
                    {


                        if (guna2DataGridView1.CurrentRow.Cells[8].Value.ToString() == "ຈ່າຍແລ້ວ" && guna2DataGridView1.CurrentRow.Cells[9].Value.ToString() == "ຮັບສິນຄ້າແລ້ວ")
                        {
                            cmd = new SqlCommand("Insert into puchase_bill values(@Purchase_Order_ID, CURRENTIMESTMAP)", con.conder);
                cmd.Parameters.AddWithValue("@Purchase_Order_ID", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("ສຳເລັດການສັ່ງຊື້");
                            }
        }
                    }*/

        private void rdbDeliverCheck_Click(object sender, EventArgs e)
        {






        }
        public void updatePurchaseReceived()
        {



            guna2DataGridView1.CurrentRow.Cells[9].Value = "ຮັບສິນຄ້າແລ້ວ";
            cmd = new SqlCommand("update tbPurchaseOrder set received_status = 3 where purchase_order_id = @order_id ", con.conder);
            cmd.Parameters.AddWithValue("@order_id", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();

            int selectedRowIndex = guna2DataGridView1.SelectedRows.Count > 0 ? guna2DataGridView1.SelectedRows[0].Index : -1;

            if (selectedRowIndex >= 0 && selectedRowIndex < guna2DataGridView1.Rows.Count)
            {
                guna2DataGridView1.Rows[selectedRowIndex].Selected = true;
            }


            if (guna2DataGridView1.Rows[selectedRowIndex].Cells[9].Value.ToString() == "ຮັບສິນຄ້າແລ້ວ" && guna2DataGridView1.Rows[selectedRowIndex].Cells[8].Value.ToString() == "ຈ່າຍແລ້ວ")
            {
                string product_id;
                ///================================== Find ProductID ==============================================

                string STR8 = "select product_id from tbProduct where product_name = @name";
                SqlCommand cmd2 = new SqlCommand(STR8, con.conder);
                cmd2.Parameters.AddWithValue("@name", cbProName.Text);
                dr = cmd2.ExecuteReader();
                dr.Read();
                product_id = Convert.ToString(dr[0]);
                dr.Close();


                float quan = float.Parse(lblStockQuan.Text) + float.Parse(txtquan.Text);


                SqlCommand cmd3 = new SqlCommand("Update tbStock set quantity =@quan where product_id = @id", con.conder);
                cmd3.Parameters.AddWithValue("@quan", quan);
                cmd3.Parameters.AddWithValue("@id", product_id);
                cmd3.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into purchase_bill values(@Purchase_order_id, CURRENT_TIMESTAMP)", con.conder);
                cmd.Parameters.AddWithValue("@Purchase_order_id", guna2DataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("ສຳເລັດການສັ່ງຊື້");
                showProData();
                showStock();




            }







        }

        public void updatePurchasePayment()
        {


            guna2DataGridView1.CurrentRow.Cells[8].Value = "ຈ່າຍແລ້ວ";

            cmd = new SqlCommand("update tbPurchaseOrder set payment_status = 1 where purchase_order_id = @order_id ", con.conder);
            cmd.Parameters.AddWithValue("@order_id", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            int selectedRowIndex = guna2DataGridView1.SelectedRows.Count > 0 ? guna2DataGridView1.SelectedRows[0].Index : -1;

            if (selectedRowIndex >= 0 && selectedRowIndex < guna2DataGridView1.Rows.Count)
            {
                guna2DataGridView1.Rows[selectedRowIndex].Selected = true;
            }



            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill
            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill
            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill
            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill
            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill
            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill

            // y tit error. trng karn hai condition me hup sin kar lw && jaiy lw jg insert in purchase bill
            if (guna2DataGridView1.Rows[selectedRowIndex].Cells[9].Value.ToString() == "ຮັບສິນຄ້າແລ້ວ" && guna2DataGridView1.Rows[selectedRowIndex].Cells[8].Value.ToString() == "ຈ່າຍແລ້ວ")
            {



                string product_id;
                ///================================== Find ProductID ==============================================

                string STR8 = "select product_id from tbProduct where product_name = @name";
                SqlCommand cmd2 = new SqlCommand(STR8, con.conder);
                cmd2.Parameters.AddWithValue("@name", cbProName.Text);
                dr = cmd2.ExecuteReader();
                dr.Read();
                product_id = Convert.ToString(dr[0]);
                dr.Close();


                float quan = float.Parse(lblStockQuan.Text) + float.Parse(txtquan.Text);


                SqlCommand cmd3 = new SqlCommand("Update tbStock set quantity =@quan where product_id = @id", con.conder);
                cmd3.Parameters.AddWithValue("@quan", quan);
                cmd3.Parameters.AddWithValue("@id", product_id);
                cmd3.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into purchase_bill values(@Purchase_order_id, CURRENT_TIMESTAMP)", con.conder);
                cmd.Parameters.AddWithValue("@Purchase_order_id", guna2DataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("ສຳເລັດການສັ່ງຊື້");

                showProData();
                showStock();







            }
        }




        private void rdbPaymentCheck_Click(object sender, EventArgs e)
        {


        }

        private void guna2DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.ClearSelection();
            cbProName.Text = "";
            txtcost.Text = "";
            txtExpressFee.Text = "";
            txtquan.Text = "";
            cbExchanger.Text = "";
            cbExpress.Text = "";
            cbPayType.Text = "";
            cbSupplier.Text = "";
            rdbPaymentCheck.Checked = false;
            rdbDeliverCheck.Checked = false;
            btnConvfirm.Text = "ຢືນຢັນການສັ່ງ";
            lblStock.Visible= false;
            lblStockQuan.Visible= false;

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string id;
            string STR = "select purchase_order from purchase_bill where purchase_bil_id = @id";
            cmd = new SqlCommand(STR, con.conder);
            cmd.Parameters.AddWithValue("@id", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
            dr = cmd.ExecuteReader();
            dr.Read();
            id = Convert.ToString(dr[0]);
            dr.Close();

            cmd = new SqlCommand("Delete from tbPurchaseOrder where purchase_bil_id = @id", con.conder);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            showProData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (btnConvfirm.Text == "ຢືນຢັນການສັ່ງ")
            {
                Insert();
            }

            if (btnConvfirm.Text == "ອັບເດດການສັ່ງຊື້")
            {
          
                if (guna2DataGridView1.SelectedRows.Count > 0)
                {


                    if (rdbPaymentCheck.Checked == true)
                    {
                        updatePurchasePayment();
                    }
                    else if (rdbPaymentCheck.Checked == false)
                    {
                        guna2DataGridView1.CurrentRow.Cells[8].Value = "ຕິດໜີ້";
                        cmd = new SqlCommand("update tbPurchaseOrder set payment_status = 2 where purchase_order_id = @order_id", con.conder);
                        cmd.Parameters.AddWithValue("@order_id", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();

                    }
                    if (rdbDeliverCheck.Checked == true)
                    {
                        updatePurchaseReceived();
                    }
                    else if (rdbDeliverCheck.Checked == false)
                    {
                        guna2DataGridView1.CurrentRow.Cells[9].Value = "ຍັງບໍ່ໄດ້ຮັບສິນຄ້າ";
                        cmd = new SqlCommand("update tbPurchaseOrder set received_status = 4 where purchase_order_id = @order_id", con.conder);
                        cmd.Parameters.AddWithValue("@order_id", guna2DataGridView1.CurrentRow.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();


                    }
                    else { }
                }
            }
        }
    }
}

                

                

            
         
        

        
    


