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
using System.Globalization;
using System.Data.SqlClient;


namespace 入庫管理
{
    public partial class nyuko1 : Form
    {

        public nyuko1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

        }

        public nyuko1(TextBox lengt)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            string len = lengt.Text;
            lenguagen1.Text = len;
        }



        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


           
        }

        private void Registeredatebase()
        {

           
        }

        private void kakakupress(object sender, KeyPressEventArgs e)
        {
         
    {
        //0～9と、バックスペース以外の時は、イベントをキャンセルする
        if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
        {
            e.Handled = true;
        }
    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection olecon = new OleDbConnection();
            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";

            //OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKanri.accdb;");
            
            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT * FROM 発注 ORDER BY 発注値 DESC";

                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;


                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            
            //dataGridView1.Columns[3].MinimumWidth = 346;

            //dataGridView1.Sort(dataGridView1.Columns[11], ListSortDirection.Descending);
        
                            
            
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;

                if (dataGridView1.Rows[i].Cells["着荷"].Value.ToString() == "True") 
                {

                    dataGridView1.Rows[i].Cells["着荷"].ReadOnly = true;

                }

                else
                {
                    dataGridView1.Rows[i].Cells["着荷"].ReadOnly = false;


                }
            
            
            }
            dataGridView1.Columns["発注値"].Visible = false;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
                
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void hattyuid_TextChanged(object sender, EventArgs e)
        {
            OleDbConnection olecon = new OleDbConnection();
            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";


        }

        private void button3_Click_1(object sender, EventArgs e)
        {




            DialogResult result = MessageBox.Show("入力した情報更新しますか？", "質問", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;");

                    OleDbCommand cmd = new OleDbCommand("UPDATE 発注 SET 着荷 = ? WHERE 商品名 = ? AND 発注値 = ? ", cn);





                    if (dataGridView1.Rows[i].Cells["着荷"].Value.ToString() == "True")
                    {
                        cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = -1;

                    }
                    else
                    {
                        cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = 0;
                    }







                    cmd.Parameters.Add("@p2", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["商品名"].Value.ToString();
                    cmd.Parameters.Add("@p3", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["発注値"].Value.ToString();


                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();




                    if (dataGridView1.Rows[i].Cells["注文コード"].Value.ToString() != "") 
                    {

                        OleDbConnection cn2 = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;");

                        OleDbCommand cmd2 = new OleDbCommand("UPDATE 注文管理 SET 発注状態 = ? WHERE 注文コード = ? AND 商品名 = ? ", cn2);






                        if (dataGridView1.Rows[i].Cells["着荷"].Value.ToString() == "True")
                        {
                            cmd2.Parameters.Add("@p12", OleDbType.VarChar).Value = "着荷";

                        }
                        else
                        {
                            cmd2.Parameters.Add("@p12", OleDbType.VarChar).Value = "待機";
                        }









                        cmd2.Parameters.Add("@p22", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["注文コード"].Value.ToString();
                        cmd2.Parameters.Add("@p32", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["商品名"].Value.ToString();


                        cn2.Open();
                        cmd2.ExecuteNonQuery();
                        cn2.Close();


                    }


                }


                
              
                MessageBox.Show("更新できました。");

            }



            else if (result == DialogResult.Cancel)
            {

                MessageBox.Show("更新キャンセルされました。");

            }
            
            
            
            
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {/*
            
{
    var dgv = (DataGridView)sender;
    if(dgv.IsCurrentCellDirty)
    {
        dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }
}*/
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            OleDbConnection olecon = new OleDbConnection();
            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT 注文コード,発注状態,伝票日付 FROM 注文管理 WHERE 発注状態<>'いらない' ORDER BY 注文コード DESC";

                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;


                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            dataGridView2.Sort(dataGridView2.Columns[2], ListSortDirection.Descending);



            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                dataGridView2.Rows[i].ReadOnly = true;




            }
        }
    }
}
