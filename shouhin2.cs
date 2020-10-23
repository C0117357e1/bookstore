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

namespace 商品管理
{
    public partial class shouhin2 : Form
    {
        int changeprovider = 1;

        public shouhin2()
        {
            InitializeComponent();

            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeprovider = 0;
            this.Close();
        }

        private void register_Click(object sender, EventArgs e)
        {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("入力した内容登録しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {

                if (shouhinMei.Text == "" || price.Text == "")
                {
                    MessageBox.Show("情報入力してください。");

                }
                else
                {
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");

                    Registereddatabase();
                    this.Hide();
                    
                }
            }
            else if (result == DialogResult.No)
            {
                Console.WriteLine("「いいえ」が選択されました");
            }
        }

        private void Registereddatabase()
        {
            OleDbConnection olecon = new OleDbConnection();
            olecon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";

            OleDbCommand olecmd =
             new OleDbCommand("INSERT INTO 商品管理(商品コード,商品名,ジャンル,出版社,出版社コード,発売日,在庫数,価格,ジャンル値) VALUES(@商品コード,@商品名,@ジャンル,@出版社,@出版社コード,@発売日,@在庫数,@価格,@ジャンル値)", olecon);

            olecmd.Parameters.Add("@商品コード", OleDbType.VarChar);
            olecmd.Parameters["@商品コード"].Value = shouhinID.Text;

            olecmd.Parameters.Add("@商品名", OleDbType.VarChar);
            olecmd.Parameters["@商品名"].Value = shouhinMei.Text;

            olecmd.Parameters.Add("@ジャンル", OleDbType.VarChar);
            olecmd.Parameters["@ジャンル"].Value = genre.Text;

            olecmd.Parameters.Add("@出版社", OleDbType.VarChar);
            olecmd.Parameters["@出版社"].Value = provider.Text;

            olecmd.Parameters.Add("@出版社コード", OleDbType.VarChar);
            olecmd.Parameters["@出版社コード"].Value = providerID.Text;

            olecmd.Parameters.Add("@発売日", OleDbType.DBDate);
            olecmd.Parameters["@発売日"].Value = dateTimePicker1.Value;

            olecmd.Parameters.Add("@在庫数", OleDbType.VarChar);
            olecmd.Parameters["@在庫数"].Value = qua.Text;


           

            olecmd.Parameters.Add("@価格", OleDbType.VarChar);
            olecmd.Parameters["@価格"].Value = price.Text;


            int i = int.Parse(genreN.Text);
            i += 1;

            olecmd.Parameters.Add("@ジャンル値", OleDbType.VarChar);
            olecmd.Parameters["@ジャンル値"].Value = i;



            try
            {
                olecon.Open();


                int row = olecmd.ExecuteNonQuery();
                if (row != -1)
                {
                    MessageBox.Show("登録しました");
                    changeprovider = 0;
                    this.Hide();
                    shouhin2 f = new shouhin2();
                    f.ShowDialog();

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

        private void genre_SelectedIndexChanged(object sender, EventArgs e)
        {
           textBox1.Text=genre.SelectedItem.ToString();
           switch (textBox1.Text)
           {
               case "教育": textBox2.Text = "ED";
                   break;
               case "英語": textBox2.Text = "EN";
                   break;
               case "歴史": textBox2.Text = "HI";
                   break;
               case "映画": textBox2.Text = "MG";
                   break;
               case "小説": textBox2.Text = "NV";
                   break;
               default: textBox2.Text = "ED";
                   break;
           }


           OleDbConnection olecon = new OleDbConnection();

           olecon.ConnectionString =
               "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";

           try
           {
               olecon.Open();
               OleDbCommand ocmd = new OleDbCommand();
               ocmd.Connection = olecon;

               //ocmd.CommandText = "SELECT * FROM 会員管理";
               ocmd.CommandText = "SELECT TOP 1 * FROM 商品管理  WHERE 商品コード LIKE '%" + textBox2.Text + "%' ORDER BY ジャンル値 DESC";


               OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
               DataTable dt = new DataTable();
               adapter.Fill(dt);

               genreN.Text = dt.Rows[0]["ジャンル値"].ToString();
               int i = int.Parse(genreN.Text);
               i += 1;

               shouhinID.Text = textBox2.Text + i.ToString("0000");



               olecon.Close();
           }

           catch (Exception ex)
           {
               MessageBox.Show("Error " + ex);
           }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'shiiresakiKanriDataSet1.仕入先管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.仕入先管理TableAdapter1.Fill(this.shiiresakiKanriDataSet1.仕入先管理);
            // TODO: このコード行はデータを 'shiiresakiKanriDataSet.仕入先管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.仕入先管理TableAdapter.Fill(this.shiiresakiKanriDataSet.仕入先管理);
    

        }

        private void kakakupress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) &&  e.KeyChar!=(char)8;
            if (e.KeyChar == 13)
            {
                price.Text = string.Format("{0:n0}", double.Parse(price.Text));
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.仕入先管理TableAdapter.FillBy(this.shiiresakiKanriDataSet.仕入先管理);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void qua_TextChanged(object sender, EventArgs e)
        {

        }

        private void provider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changeprovider == 1)
            {
                OleDbConnection olecon = new OleDbConnection();

                olecon.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShiiresakiKanri.accdb;";

                try
                {
                    olecon.Open();
                    OleDbCommand ocmd = new OleDbCommand();
                    ocmd.Connection = olecon;

                    //ocmd.CommandText = "SELECT * FROM 会員管理";
                    ocmd.CommandText = "SELECT 出版社コード FROM 仕入先管理 WHERE 出版社名 LIKE '%" + provider.SelectedValue.ToString() + "%'";


                    OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    providerID.Text = dt.Rows[0]["出版社コード"].ToString();



                    olecon.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }
            }
        }
    }
}
