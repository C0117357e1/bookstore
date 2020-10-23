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

namespace 発注管理_
{
    public partial class 発注管理 : Form
    {
        public 発注管理()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

        }

        public 発注管理(TextBox lengt)
        {
            InitializeComponent();

            string len = lengt.Text;
            lenguageh1.Text = len;
            WindowState = FormWindowState.Maximized;

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_hacchuu_btn_Click(object sender, EventArgs e)
        {
            txt_chuumoncode2 f = new txt_chuumoncode2();
            f.ShowDialog();
        }

        private void showlist_btn_Click(object sender, EventArgs e)
        {
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";


            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT *  FROM 発注 ORDER BY 発注コード DESC";


                //ocmd.CommandText += " WHERE 発注ID LIKE '%" + textBox1.Text + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;

                int i = 0;
                while (i < 14)
                {
                    dataGridView2.Columns[i].ReadOnly = true;
                    i++;
                }
                dataGridView2.Columns["発注値"].Visible =false;

                olecon.Close();



                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }





            OleDbConnection olecon2 = new OleDbConnection();

            olecon2.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";


            try
            {
                olecon2.Open();
                OleDbCommand ocmd2 = new OleDbCommand();
                ocmd2.Connection = olecon2;

                ocmd2.CommandText = "SELECT *  FROM 発注金額 ORDER BY 発注コード DESC";


                //ocmd.CommandText += " WHERE 発注ID LIKE '%" + textBox1.Text + "%'";

                OleDbDataAdapter adapter2 = new OleDbDataAdapter(ocmd2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                dataGridView1.DataSource = dt2;

                int i2 = 0;
                while (i2 < 3)
                {
                    dataGridView1.Columns[i2].ReadOnly = true;
                    i2++;
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                olecon2.Close();



                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }






           

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            
            
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";

            if (search_combo.SelectedItem == null || search_box.Text == "")
            {
                    error_search.Text = "検索条件を選択し、または検索内容を入力してください！";
                    //olecon.Close();
            }
            else
            {
                error_search.Text = "";
                try
                {
                    olecon.Open();
                    OleDbCommand ocmd = new OleDbCommand();
                    ocmd.Connection = olecon;

                    ocmd.CommandText = "SELECT *  FROM 発注";

                
             
                    if (search_combo.SelectedItem.ToString() == "発注ID検索")
                    {
                        ocmd.CommandText += " WHERE 発注コード LIKE '%" + search_box.Text + "%'  ORDER BY 発注コード DESC";
                    }
                    else
                    {
                        ocmd.CommandText += " WHERE 出版社名 LIKE '%" + search_box.Text + "%'   ORDER BY 発注コード DESC";
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView2.DataSource = dt;

                    int i = 0;
                    while (i < 8)
                    {
                        dataGridView2.Columns[i].ReadOnly = true;
                        i++;
                    }
                    dt.Columns[7].ReadOnly = false;
                    dataGridView2.Columns["発注値"].Visible = false;

                    //bool flag = dataGridView1.CurrentRow.Selected;

                    olecon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }

        }

        private void search_total_btn_Click(object sender, EventArgs e)
        {


            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";

            if (search_total_box.Text == "")
            {
                search_total_error.Text = "検索内容を入力してください！";
                //olecon.Close();
            }
            else
            {
                search_total_error.Text = "";
                try
                {
                    olecon.Open();
                    OleDbCommand ocmd = new OleDbCommand();
                    ocmd.Connection = olecon;

                    ocmd.CommandText = "SELECT *  FROM 発注金額 WHERE 発注コード LIKE '%" + search_total_box.Text + "%' ORDER BY 発注コード DESC";



                    OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                    int i = 0;
                    while (i < 3)
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                        i++;
                    }

                    //bool flag = dataGridView1.CurrentRow.Selected;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    olecon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }







            
        }

        private void show_totallist_btn_Click(object sender, EventArgs e)
        {
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";


            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT *  FROM 発注 ORDER BY 発注コード DESC";


                //ocmd.CommandText += " WHERE 発注ID LIKE '%" + textBox1.Text + "%'";

                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView2.DataSource = dt;

                int i = 0;
                while (i < 14)
                {
                    dataGridView2.Columns[i].ReadOnly = true;
                    i++;
                }
                dataGridView2.Columns["発注値"].Visible = false;

                olecon.Close();



                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }





            OleDbConnection olecon2 = new OleDbConnection();

            olecon2.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";


            try
            {
                olecon2.Open();
                OleDbCommand ocmd2 = new OleDbCommand();
                ocmd2.Connection = olecon2;

                ocmd2.CommandText = "SELECT *  FROM 発注金額 ORDER BY 発注コード DESC";


                //ocmd.CommandText += " WHERE 発注ID LIKE '%" + textBox1.Text + "%'";

                OleDbDataAdapter adapter2 = new OleDbDataAdapter(ocmd2);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                dataGridView1.DataSource = dt2;

                int i2 = 0;
                while (i2 < 3)
                {
                    dataGridView1.Columns[i2].ReadOnly = true;
                    i2++;
                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                olecon2.Close();



                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }














        }

    }
}
