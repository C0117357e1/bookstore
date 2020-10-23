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

namespace 売上管理
{
    public partial class uriage1 : Form
    {
        public uriage1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            combo_year.ItemHeight = 20;
            combo_month.ItemHeight = 20;
            combo_month.Items.Add("1月");
            combo_month.Items.Add("2月");
            combo_month.Items.Add("3月");
            combo_month.Items.Add("4月");
            combo_month.Items.Add("5月");
            combo_month.Items.Add("6月");
            combo_month.Items.Add("7月");
            combo_month.Items.Add("8月");
            combo_month.Items.Add("9月");
            combo_month.Items.Add("10月");
            combo_month.Items.Add("11月");
            combo_month.Items.Add("12月");

            
        }

        public uriage1(TextBox lengt)
        {
            InitializeComponent();

            string len = lengt.Text;
            lenguageu1.Text = len;


            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            combo_year.ItemHeight = 20;
            combo_month.ItemHeight = 20;
            combo_month.Items.Add("1月");
            combo_month.Items.Add("2月");
            combo_month.Items.Add("3月");
            combo_month.Items.Add("4月");
            combo_month.Items.Add("5月");
            combo_month.Items.Add("6月");
            combo_month.Items.Add("7月");
            combo_month.Items.Add("8月");
            combo_month.Items.Add("9月");
            combo_month.Items.Add("10月");
            combo_month.Items.Add("11月");
            combo_month.Items.Add("12月");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (combo_month.SelectedItem == null || combo_year.SelectedItem == null)
            {
                MessageBox.Show("年・月を選んでください！");
            }
            else
            {
                OleDbConnection olecon = new OleDbConnection();
                olecon.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=売上管理.accdb;";

                try
                {
                    olecon.Open();
                    OleDbCommand ocmd = new OleDbCommand();
                    ocmd.Connection = olecon;

                    OleDbCommand ocmd2 = new OleDbCommand();
                    ocmd2.Connection = olecon;

                    if (combo_year.Text == "平成30年")
                    {
                        switch (combo_month.Text)
                        {
                            case "1月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "2月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "3月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "4月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "5月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "6月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "7月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "8月": ocmd.CommandText = "SELECT * FROM 8月 WHERE 番号 IS NOT NULL";
                                ocmd2.CommandText = "SELECT * FROM 8月 WHERE 番号 IS NULL";
                                //dataGridView1.Columns[5].Visible = false;
                               // dataGridView2.Columns[5].Visible = false;
                                break;
                            case "9月": ocmd.CommandText = "SELECT * FROM 9月 WHERE 番号 IS NOT NULL";
                                ocmd2.CommandText = "SELECT * FROM 9月 WHERE 番号 IS NULL";
                                break;
                            case "10月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "11月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                            case "12月": ocmd.CommandText = "SELECT * FROM 現状況";
                                ocmd2.CommandText = "SELECT * FROM 現状況";
                                break;
                        }
                    }
                    else
                    {
                        ocmd.CommandText = "SELECT * FROM 現状況";
                        ocmd2.CommandText = "SELECT * FROM 現状況";
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(ocmd2);
                    DataTable dt2 = new DataTable();
                    adapter2.Fill(dt2);
                    dataGridView2.DataSource = dt2;

                    if (combo_month.Text == "8月" || combo_month.Text == "9月")
                    {
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView2.Columns[5].Visible = false;
                    }

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView2.ColumnHeadersVisible = false;
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    olecon.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combo_year_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
