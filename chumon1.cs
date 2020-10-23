using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace chumonkanri
{
    public partial class chumon1 : Form
    {

        public chumon1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

            


        }

        public chumon1(TextBox lengt)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            string len = lengt.Text;
            lenguagec1.Text = len;


            if (lenguagec1.Text == "japanese") { }
            else
            {
                label1.Text = "Client Order Management";
                button_kensaku.Text = "Search";
                button_generallist.Text = "List";
                button_kensaku2.Text = "Search";
                button2.Text = "List";
                button4.Text = "Add Order";

                ExitBtn.Text = "Close";
                label2.Text = "Comment";
                label3.Text = "OrderID";
                label11.Text = "Total Price";
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("注文コード")] = "OrderID";
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("店名")] = "Client";
                comboBox_kensaku.Text = "Select one";

                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("注文コード")] = "OrderID";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("金額")] = "Total Price";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("コメント")] = "Comment";

                comboBox_kensaku2.Text = "Select one";


            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            chumon2 f = new chumon2();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            chumon2 f = new chumon2();
            f.ShowDialog();
        }

        private void ExitBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button_kensaku_Click(object sender, EventArgs e)
        {
            if (lenguagec1.Text == "japanese") 
            { }
            else
            {
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("OrderID")] = "注文コード";
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("Client")] = "店名";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("OrderID")] = "注文コード";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("Total Price")] = "金額";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("Comment")] = "コメント";
            }
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT 注文コード,商品コード,商品名,店コード,店名,伝票日付,単価,数量,金額商品,発送,発注状態 FROM 注文管理";

                
                if (comboBox_kensaku.SelectedItem != null && textBox_kensaku.Text != null)
                {
                    ocmd.CommandText += " WHERE " + comboBox_kensaku.SelectedItem.ToString() + " LIKE '%" + textBox_kensaku.Text + "%' ORDER BY 注文コード DESC";
                         
                }
                else
                {
                   
                    ocmd.CommandText += " ORDER BY 注文コード DESC";
                }
                

                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                
                int i = 0;
                while (i < 10)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                    i++;
                }







                
                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }




            if (lenguagec1.Text == "japanese")
            { }
            else
            {
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("注文コード")] = "OrderID";
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("店名")] = "Client";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("注文コード")] = "OrderID";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("金額")] = "Total Price";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("コメント")] = "Comment";
                dataGridView1.Columns[0].HeaderText = "OrderID ";
                dataGridView1.Columns[1].HeaderText = "GoodsID ";
                dataGridView1.Columns[2].HeaderText = "Goods";

                dataGridView1.Columns[3].HeaderText = "ClientID ";
                dataGridView1.Columns[4].HeaderText = "Client ";

                dataGridView1.Columns[5].HeaderText = "Date ";
                dataGridView1.Columns[6].HeaderText = "Unit Price";
                dataGridView1.Columns[7].HeaderText = "Quantity ";
                dataGridView1.Columns[8].HeaderText = "Total/goods ";
                dataGridView1.Columns[9].HeaderText = "Delivery ";
                dataGridView1.Columns[10].HeaderText = "Stock ";
                
                
                


            }

        }

        private void button_generallist_Click(object sender, EventArgs e)
        {

            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

            try
            {
                olecon.Open();

                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;


                OleDbCommand ocmd2 = new OleDbCommand();
                ocmd2.Connection = olecon;


                ocmd.CommandText = "SELECT 注文コード,商品コード,商品名,店コード,店名,伝票日付,単価,数量,金額商品,発送,発注状態 FROM 注文管理 ORDER BY 注文コード DESC";
               
                ocmd2.CommandText = "SELECT * FROM 注文管理金額 ORDER BY 注文コード DESC";



                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;


                int i = 0;
                while (i < 10)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                    i++;
                }



                OleDbDataAdapter adapter2 = new OleDbDataAdapter(ocmd2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                dataGridView2.DataSource = dt2;








                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }




        }

        private void selectdata(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //string id = dataGridView1.SelectedCells[0].Value.ToString();
                int rowindex = dataGridView1.CurrentRow.Index;
                string chumon = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();















                



            }











            

        }

        private void textBox_chumoncompare_TextChanged(object sender, EventArgs e)
        {



            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

            try
            {
                olecon.Open();

                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;


                OleDbCommand ocmd2 = new OleDbCommand();
                ocmd2.Connection = olecon;


                ocmd.CommandText = "SELECT 注文コード,商品コード,商品名,店コード,店名,伝票日付,単価,数量,金額商品,発送,発注状態 FROM 注文管理 ORDER BY 注文コード DESC";

                ocmd2.CommandText = "SELECT * FROM 注文管理金額 ORDER BY 注文コード DESC";



                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;


                int i = 0;
                while (i < 10)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                    i++;
                }



                OleDbDataAdapter adapter2 = new OleDbDataAdapter(ocmd2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                dataGridView2.DataSource = dt2;








                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }



        }

        private void selectdata2(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                //string id = dataGridView1.SelectedCells[0].Value.ToString();
                int rowindex = dataGridView2.CurrentRow.Index;
                string chumon = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
                string chumoncito = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
                string coment = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();

                textBox_KINGAKUFINAL.Text = chumon;
                textBox_chumoncito.Text = chumoncito;
                textBox_comment.Text = coment;




                textBox_KINGAKUFINAL.Text = textBox_KINGAKUFINAL.Text+"\\";













            }
        }

        private void button_kensaku2_Click(object sender, EventArgs e)
        {
            if (lenguagec1.Text == "japanese")
            { }
            else
            {
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("OrderID")] = "注文コード";
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("Client")] = "店名";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("OrderID")] = "注文コード";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("Total Price")] = "金額";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("Comment")] = "コメント";

            }
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT * FROM 注文管理金額";


                if (comboBox_kensaku2.SelectedItem != null && textBox_kensaku2.Text != null)
                {
                    ocmd.CommandText += " WHERE " + comboBox_kensaku2.SelectedItem.ToString() + " LIKE '%" + textBox_kensaku2.Text + "%' ORDER BY 注文コード DESC";

                }
                else
                {

                    ocmd.CommandText += " ORDER BY 注文コード DESC";
                }


                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;


                int i = 0;
                while (i < 3)
                {
                    dataGridView2.Columns[i].ReadOnly = true;
                    i++;
                }








                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            if (lenguagec1.Text == "japanese")
            { }
            else
            {
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("注文コード")] = "OrderID";
                comboBox_kensaku.Items[comboBox_kensaku.FindStringExact("店名")] = "Client";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("注文コード")] = "OrderID";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("金額")] = "Total Price";
                comboBox_kensaku2.Items[comboBox_kensaku2.FindStringExact("コメント")] = "Comment";
                dataGridView2.Columns[0].HeaderText = "OrderID ";
                dataGridView2.Columns[1].HeaderText = "Total Price";
                dataGridView2.Columns[2].HeaderText = "Comment";

            }
        }

        private void button_actualiseishon_Click(object sender, EventArgs e)
        {
      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
