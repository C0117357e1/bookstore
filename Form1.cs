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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("入力した内容を登録しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (hattyuid.Text == "" || syohinid.Text == "" || syohinmei.Text == "" || syuppansya.Text == "" || syuppansyaid.Text == "" || nyukokakaku.Text == "" || suryo.Text == "")
                {
                    MessageBox.Show("空いているところを入力してください。");

                }
                else
                {
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");

                    Registeredatebase();
                    this.Hide();

                }
            }
            else if (result == DialogResult.No)
            {
                Console.WriteLine("「いいえ」が選択されました");
            }
        }

        private void Registeredatebase()
        {

            OleDbConnection olecon = new OleDbConnection();
            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Nyukokanri.accdb;";

            

            //実行するSQL文の指定 
            OleDbCommand olecmd =
                new OleDbCommand("INSERT INTO 入庫(発注ID,商品ID,商品名,出版社名,出版社ID,日付,入庫価格,数量) VALUES(@発注ID,@商品ID,@商品名,@出版社名,@出版社ID,@日付,@入庫価格,@数量)", olecon);

            olecmd.Parameters.Add("@発注ID", OleDbType.VarChar);
            olecmd.Parameters["@発注ID"].Value = hattyuid.Text;

            olecmd.Parameters.Add("@商品ID", OleDbType.VarChar);
            olecmd.Parameters["@商品ID"].Value = syohinid.Text;

            olecmd.Parameters.Add("@商品名", OleDbType.VarChar);
            olecmd.Parameters["@商品名"].Value = syohinmei.Text;

            olecmd.Parameters.Add("@出版社名", OleDbType.VarChar);
            olecmd.Parameters["@出版社名"].Value = syuppansya.Text;

            olecmd.Parameters.Add("@出版社ID", OleDbType.VarChar);
            olecmd.Parameters["@出版社ID"].Value = syuppansyaid.Text;

            olecmd.Parameters.Add("@日付", OleDbType.VarChar);
            olecmd.Parameters["@日付"].Value = dateTimePicker1.Value;

            olecmd.Parameters.Add("@入庫価格", OleDbType.VarChar);
            olecmd.Parameters["@入庫価格"].Value = nyukokakaku.Text;

            olecmd.Parameters.Add("@数量", OleDbType.VarChar);
            olecmd.Parameters["@数量"].Value = suryo.Text;
 
            



            try
            {
                //データベースを開く 
                olecon.Open();

                int row = olecmd.ExecuteNonQuery();
                if (row != -1)
                {
                    MessageBox.Show("内容を登録しました。");
                    this.Hide();
                    Form1 f = new Form1();
                    f.Show();
                    
                }
            }
            catch
            {
                MessageBox.Show("登録に失敗しました。");

            }
            finally
            {
                olecon.Close();
            }
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
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Nyukokanri.accdb;";

            
            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                ocmd.CommandText = "SELECT * FROM 入庫";

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

            
            dataGridView1.Columns[3].MinimumWidth = 346;

            dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Descending);
        
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
    }
}
