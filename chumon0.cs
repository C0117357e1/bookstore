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
    public partial class cumon1 : Form
    {
        public cumon1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chumon2 f = new chumon2();
            f.Show();
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
            f.Show();
        }

        private void ExitBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button_kensaku_Click(object sender, EventArgs e)
        {
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
                    ocmd.CommandText += " WHERE " + comboBox_kensaku.SelectedItem.ToString() + " LIKE '%" + textBox_kensaku.Text + "%' ORDER BY 注文コード";
                         
                }
                else
                {
                   
                    ocmd.CommandText += " ORDER BY 注文コード";
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


                ocmd.CommandText = "SELECT 注文コード,商品コード,商品名,店コード,店名,伝票日付,単価,数量,金額商品,発送,発注状態 FROM 注文管理 ORDER BY 注文コード";
               
                ocmd2.CommandText = "SELECT * FROM 注文管理金額 ORDER BY 注文コード";



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


                ocmd.CommandText = "SELECT 注文コード,商品コード,商品名,店コード,店名,伝票日付,単価,数量,金額商品,発送,発注状態 FROM 注文管理 ORDER BY 注文コード";

                ocmd2.CommandText = "SELECT * FROM 注文管理金額 ORDER BY 注文コード";



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
                    ocmd.CommandText += " WHERE " + comboBox_kensaku2.SelectedItem.ToString() + " LIKE '%" + textBox_kensaku2.Text + "%' ORDER BY 注文コード";

                }
                else
                {

                    ocmd.CommandText += " ORDER BY 注文コード";
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

        }

        private void button_actualiseishon_Click(object sender, EventArgs e)
        {
      
        }

        
    }
}
