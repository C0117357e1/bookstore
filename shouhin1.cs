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
using System.Data.SqlClient;


namespace 商品管理
{
    public partial class shouhin1 : Form
    {
        int hacchukakunin = 0;
        public shouhin1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        public shouhin1(TextBox lengt)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            string len = lengt.Text;
            lenguages1.Text = len;
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            
            label1.Text = "ご指定いただいた検索条件に該当する商品がみつかりませんでした。";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hacchukakunin == 1)
            {


                発注管理_.txt_chuumoncode2 f2 = new 発注管理_.txt_chuumoncode2(dataGridView1);
                f2.ShowDialog();
            }
            else
            {
            
            }
        }

        private void toolStripMenuItem_Education_Click(object sender, EventArgs e)
        {
            string MenuItemName = sender.ToString();
            textBox2.Text = MenuItemName;
        }

        private void toolStripMenuItem_English_Click(object sender, EventArgs e)
        {
            string MenuItemName = sender.ToString();
            textBox2.Text = MenuItemName;
        }

        private void toolStripMenuItem_History_Click(object sender, EventArgs e)
        {
            string MenuItemName = sender.ToString();
            textBox2.Text = MenuItemName;
        }

        private void toolStripMenuItem_Manga_Click(object sender, EventArgs e)
        {
            string MenuItemName = sender.ToString();
            textBox2.Text = MenuItemName;
        }

        private void toolStripMenuItem_Novel_Click(object sender, EventArgs e)
        {
            string MenuItemName = sender.ToString();
            textBox2.Text = MenuItemName;
        }

        private void ToolStripMenuItem_All_Click(object sender, EventArgs e)
        {
            string MenuItemName = sender.ToString();
            textBox2.Text = MenuItemName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hacchukakunin = 1;
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT 商品コード, 商品名, ジャンル, 出版社, 出版社コード, 発売日, 在庫数, 価格, チェック  FROM 商品管理";

                if (comboBox1.SelectedItem != null && textBox1.Text != null)
                {
                    switch (textBox2.Text)
                    {
                        case "教育": ocmd.CommandText += " WHERE ジャンル='教育' AND " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                        case "英語": ocmd.CommandText += " WHERE ジャンル='英語' AND " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                        case "歴史": ocmd.CommandText += " WHERE ジャンル='歴史' AND " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                        case "漫画": ocmd.CommandText += " WHERE ジャンル='漫画' AND " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                        case "小説": ocmd.CommandText += " WHERE ジャンル='小説' AND " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                        case "すべて": ocmd.CommandText += " WHERE " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                        default: ocmd.CommandText += " WHERE " + comboBox1.SelectedItem.ToString() + " LIKE '%" + textBox1.Text + "%'";
                            break;
                    }
                    ocmd.CommandText += " ORDER BY 商品コード";
                }
                else
                {
                    switch (textBox2.Text)
                    {
                        case "教育": ocmd.CommandText += " WHERE ジャンル='教育'";
                            break;
                        case "英語": ocmd.CommandText += " WHERE ジャンル='英語'";
                            break;
                        case "歴史": ocmd.CommandText += " WHERE ジャンル='歴史'";
                            break;
                        case "漫画": ocmd.CommandText += " WHERE ジャンル='漫画'";
                            break;
                        case "小説": ocmd.CommandText += " WHERE ジャンル='小説'";
                            break;
                        case "すべて": break;
                    }
                    ocmd.CommandText += " ORDER BY 商品コード";
                }


                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                dataGridView1.DataSource = dt;

                int i = 0;
                while(i<8){
                    dataGridView1.Columns[i].ReadOnly = true;
                    i++;
                }
                dt.Columns[7].ReadOnly = false;

                //bool flag = dataGridView1.CurrentRow.Selected;


                
                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shouhin2 f = new shouhin2();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hacchukakunin = 1;
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT 商品コード, 商品名, ジャンル, 出版社, 出版社コード, 発売日, 在庫数, 価格, チェック  FROM 商品管理 WHERE 在庫数 < 50 ORDER BY 商品コード";
                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                int i = 0;
                while (i <= dataGridView1.Columns.Count)
                {
                   // dataGridView1.Rows[i].Cells[8].Value = true;
                    i++;
                }
                
                
                
                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }


           



            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[8];
                chk.Value = true;

                
              
            }




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void selectdata(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                //string id = dataGridView1.SelectedCells[0].Value.ToString();
                int rowindex = dataGridView1.CurrentRow.Index;

                //dataGridView1.Rows[rowindex].Cells[6].Value.ToString()
                 //textBo
                if(int.Parse(dataGridView1.Rows[rowindex].Cells[6].Value.ToString()) < 50)
                {
                    textBox3.Text = "発注してください！";
                }
                else
                {
                    textBox3.Text = "";
                }
            }
        }
    }
}
