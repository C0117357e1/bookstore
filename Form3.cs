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

namespace 出庫
{
    public partial class syuko1 : Form
    {
        public syuko1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

        }

        public syuko1(TextBox lengt)
        {
            InitializeComponent();

            string len = lengt.Text;
            lenguagesh1.Text = len;
            WindowState = FormWindowState.Maximized;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection olecon = new OleDbConnection();


            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";


            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT * FROM 注文管理 ORDER BY 注文コード DESC";

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

            //dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Descending);

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;

                if (dataGridView1.Rows[i].Cells["発送"].Value.ToString() == "True")
                {

                    dataGridView1.Rows[i].Cells["発送"].ReadOnly = true;

                }

                else
                {
                    dataGridView1.Rows[i].Cells["発送"].ReadOnly = false;


                }


            }
            dataGridView1.Columns["注文コード値"].Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
             DialogResult result = MessageBox.Show("入力した情報更新しますか？", "質問", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

             if (result == DialogResult.OK)
             {
                 for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                 {

                    /* if (dataGridView1.Rows[i].Cells["発注状態"].Value.ToString() == "待機")
                     {
                         MessageBox.Show("発注状態は「待機」出庫できません");

                     }
                     else
                     {*/
                         OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;");

                         OleDbCommand cmd = new OleDbCommand("UPDATE 注文管理 SET 発送 = ? WHERE 商品名 = ? AND 注文コード値 = ? ", cn);





                         if (dataGridView1.Rows[i].Cells["発送"].Value.ToString() == "True" && dataGridView1.Rows[i].Cells["発注状態"].Value.ToString() != "待機")
                         {
                             cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = -1;

                         }
                         else
                         {
                             cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = 0;
                         }







                         cmd.Parameters.Add("@p2", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["商品名"].Value.ToString();
                         cmd.Parameters.Add("@p3", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["注文コード値"].Value.ToString();


                         cn.Open();
                         cmd.ExecuteNonQuery();
                         cn.Close();

                     }
                     MessageBox.Show("更新できました。");
                 }
             //}



             else if (result == DialogResult.Cancel)
             {

                 MessageBox.Show("更新キャンセルされました。");

             }
        }
    }
}
