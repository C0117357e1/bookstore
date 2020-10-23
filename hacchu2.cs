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
    public partial class txt_chuumoncode2 : Form
    {
        int k = 0;
        string mise_id = "";
        string mise_name = "";

        public txt_chuumoncode2()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

            textBox1.Text = "true";
            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                //ocmd.CommandText = "SELECT * FROM 会員管理";
                ocmd.CommandText = "SELECT TOP 1 * FROM 発注 ORDER BY 発注コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                txt_hacchuunum.Text = dt.Rows[0]["発注値"].ToString();
                int i = int.Parse(txt_hacchuunum.Text);
                i += 1;
                txt_hacchuunum.Text = i.ToString();
                txt_hacchuucode.Text = "H" + i.ToString("000");

                txt_arrival.Text = dt.Rows[0]["着荷"].ToString();
                textBox2.Text = dt.Rows[0]["注文コード"].ToString();
                if (textBox2.Text != "")
                {
                    mise_id = dt.Rows[0]["店コード"].ToString();
                    mise_name = dt.Rows[0]["店名"].ToString();

                }
                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }






            dataGridView1.Columns["new在庫"].Visible = false;


        }





        public txt_chuumoncode2(DataGridView dg)
        {
            InitializeComponent();
            textBox1.Text = "true";

            string columnName = dg.Columns[0].Name;

            prueba.Text = columnName;
            /*
             * 
             * 
             * from here add nith
            */


            if (prueba.Text == "注文コード") {

                Register.Enabled = false;
                button2.Enabled = false;
                ExitBtn.Enabled = false;
                this.ControlBox = false;


                OleDbConnection olecon = new OleDbConnection();

                olecon.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";

                try
                {
                    olecon.Open();
                    OleDbCommand ocmd = new OleDbCommand();
                    ocmd.Connection = olecon;

                    //ocmd.CommandText = "SELECT * FROM 会員管理";
                    ocmd.CommandText = "SELECT TOP 1 * FROM 発注 ORDER BY 発注コード DESC";


                    OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    txt_hacchuunum.Text = dt.Rows[0]["発注値"].ToString();
                    int i = int.Parse(txt_hacchuunum.Text);
                    i += 1;
                    txt_hacchuunum.Text = i.ToString();
                    txt_hacchuucode.Text = "H" + i.ToString("000");

                    txt_arrival.Text = dt.Rows[0]["着荷"].ToString();
                    textBox2.Text = dt.Rows[0]["注文コード"].ToString();
                    if (textBox2.Text != "")
                    {
                        mise_id = dt.Rows[0]["店コード"].ToString();
                        mise_name = dt.Rows[0]["店名"].ToString();

                    }
                    olecon.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex);
                }











                int kakakufinal = 0;

                for (int i = 0; i < dg.RowCount - 1; i++)
                {
                    // if (Convert.ToDouble(dg.Rows[i].Cells[13].Value) < 50)
                    // {

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[3].Value = dg.Rows[i].Cells[0].Value;   // 注文コード
                    dataGridView1.Rows[i].Cells[6].Value = dg.Rows[i].Cells[1].Value;
                    dataGridView1.Rows[i].Cells[7].Value = dg.Rows[i].Cells[2].Value;
                    dataGridView1.Rows[i].Cells[2].Value = dg.Rows[i].Cells[3].Value;
                    dataGridView1.Rows[i].Cells[1].Value = dg.Rows[i].Cells[4].Value;
                    dataGridView1.Rows[i].Cells[4].Value = dg.Rows[i].Cells[5].Value;
                    dataGridView1.Rows[i].Cells[5].Value = dg.Rows[i].Cells[6].Value;
                    dataGridView1.Rows[i].Cells[11].Value = dg.Rows[i].Cells[7].Value;
                    dataGridView1.Rows[i].Cells[9].Value = dg.Rows[i].Cells[8].Value;
                    dataGridView1.Rows[i].Cells[10].Value = dg.Rows[i].Cells[10].Value;
                    dataGridView1.Rows[i].Cells[12].Value = txt_hacchuunum.Text;
                    dataGridView1.Rows[i].Cells[0].Value = txt_hacchuucode.Text;
                    dataGridView1.Rows[i].Cells[8].Value = dg.Rows[i].Cells[14].Value;
                    dataGridView1.Rows[i].Cells["new在庫"].Value=50;
                    // kakakufinal+=Convert.ToInt32(dg.Rows[i].Cells[10].Value);
                    //txt_totalprice_final.Text = kakakufinal.ToString();
                    //  }

                }


                for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    //if (!row.IsNewRow && row.Cells[0].Value == null)
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value) < 0)
                    {
                        dataGridView1.Rows.RemoveAt(i);
                    }





                }

                for (int o = 0; o < dg.RowCount - 1; o++)
                {


                    kakakufinal += Convert.ToInt32(dg.Rows[o].Cells[10].Value);
                    total_price.Text = kakakufinal.ToString();


                }
            }

            else 
            {
                dataGridView1.AutoGenerateColumns = false;
                int sum = 0;
                txt_chuumoncode2 n = new txt_chuumoncode2();
                for (int i = 0; i < dg.RowCount - 1; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["発注コード"].Value = n.txt_hacchuucode.Text;      // 発注コード
                    dataGridView1.Rows[i].Cells["商品コード"].Value = dg.Rows[i].Cells[0].Value;   // 商品コード
                    dataGridView1.Rows[i].Cells["商品名"].Value = dg.Rows[i].Cells[1].Value;       // 商品名
                    dataGridView1.Rows[i].Cells["出版社コード"].Value = dg.Rows[i].Cells[4].Value; // 出版社コード
                    dataGridView1.Rows[i].Cells["出版社名"].Value = dg.Rows[i].Cells[3].Value;      // 出版社名 

                    int hachuu_num = 50 - Convert.ToInt32(dg.Rows[i].Cells[6].Value);
                    dataGridView1.Rows[i].Cells["発注数量"].Value = hachuu_num;                  //発注数量

                    dataGridView1.Rows[i].Cells["単価"].Value = dg.Rows[i].Cells[7].Value;        // 単価

                    int money = hachuu_num * Convert.ToInt32(dg.Rows[i].Cells[7].Value);
                    dataGridView1.Rows[i].Cells["金額"].Value = money;                            //金額



                    dataGridView1.Rows[i].Cells["発注日付"].Value = dateTimePicker1.Value.ToString("yyyy/MM/dd"); //発注日付

                    dataGridView1.Rows[i].Cells["発注値"].Value = n.txt_hacchuunum.Text;           //発注値
                    dataGridView1.Rows[i].Cells["注文コード"].Value = "";                          //注文コード
                    dataGridView1.Rows[i].Cells["店コード"].Value = "";                            //店コード
                    dataGridView1.Rows[i].Cells["店名"].Value = "";                                //店名
                    //if(dg.Rows[i].)
                    dataGridView1.Rows[i].Cells["new在庫"].Value = 50;                             //new在庫
                    dataGridView1.Rows[i].Cells["チェック"].Value = dg.Rows[i].Cells[8].Value;     //チェック


                }


                for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                {
                    //DataGridViewRow row = dataGridView1.Rows[i];
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells["チェック"].Value) == 0 || Convert.ToInt32(dataGridView1.Rows[i].Cells["発注数量"].Value) <= 0)
                    {

                        dataGridView1.Rows.RemoveAt(i);

                    }


                }

                //if (txt_totalprice_final.Text == "")

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    //have_data.Text += dataGridView1.Rows[i].Cells["金額"].Value.ToString();
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["金額"].Value);
                    //sum += sum;
                    total_price.Text = sum.ToString();
                }

            }


            dataGridView1.Columns["new在庫"].Visible = false;

        }




      






        private void ExitBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "false";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_shouhinnid.Text == "" || txt_shuppannsyaid.Text == "" || txt_suuryou.Text == "")
            {
                MessageBox.Show("商品名また出版社名を入力してください！");
            }
            else
            {
                int sum = int.Parse(txt_price.Text) * int.Parse(txt_suuryou.Text);
                txt_totalprice_final.Text = sum.ToString();

                string hachuucode = txt_hacchuucode.Text;
                string shuppancode = txt_shuppannsyaid.Text;
                string shuppanname = com_shuppan.SelectedValue.ToString();
                string chumoncode = textBox2.Text;
                string shouhincode = txt_shouhinnid.Text;
                string shouhinname = com_shouhin.SelectedValue.ToString();

                string misecode = mise_id;
                string misename = mise_name;
                string suuryou = txt_suuryou.Text;
                string tannka = (int.Parse(txt_price.Text)).ToString();
                string total = txt_totalprice_final.Text;
                string date = dateTimePicker1.Value.ToString("yyyy/MM/dd");

                string newzaiko = (int.Parse(txt_zaiko.Text)+int.Parse(suuryou) ).ToString();

                //bool c15 = false;
                string c10 = txt_hacchuunum.Text;
                //int total = 0;
                //total += sum;
                //txt_totalprice_final.Text = total.ToString();

                k = k + int.Parse(total);
                total_price.Text = k.ToString();

                //c3 = c3 + "\\";
                //c4 = c4 + "\\";

                if (prueba.Text=="")
                {
                    chumoncode = "";
                    misecode = "";
                    misename = "";

                }




                string[] row = { hachuucode, shuppancode, shuppanname, chumoncode, shouhincode, shouhinname, misecode, misename, suuryou, tannka, total, date, c10,newzaiko };
                dataGridView1.Rows.Add(row);

                clear();
            }
        }
        

        private void clear()
        {
            com_shouhin.SelectedIndex = 0;
            com_shuppan.SelectedIndex = 0;
            txt_shouhinnid.Text = "";
            txt_shuppannsyaid.Text = "";
            txt_zaiko.Text = "";
            txt_suuryou.Text = "";
        }
        
        private void label10_Click(object sender, EventArgs e)
        {
        
        }

        private void suuryou_Click(object sender, EventArgs e)
        {
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'kainKanriDataSet.会員管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.会員管理TableAdapter.Fill(this.kainKanriDataSet.会員管理);
            // TODO: このコード行はデータを 'shouhinKanriDataSet2.商品管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.商品管理TableAdapter2.Fill(this.shouhinKanriDataSet2.商品管理);
            // TODO: このコード行はデータを 'shiiresakiKanriDataSet.仕入先管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
           this.仕入先管理TableAdapter.Fill(this.shiiresakiKanriDataSet.仕入先管理);
            // TODO: このコード行はデータを 'shouhinKanriDataSet1.商品管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            //this.商品管理TableAdapter1.Fill(this.shouhinKanriDataSet1.商品管理);
            // TODO: このコード行はデータを 'shouhinKanriDataSet.商品管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
           // this.商品管理TableAdapter.Fill(this.shouhinKanriDataSet.商品管理);
            // TODO: このコード行はデータを 'hacchuuKannriDataSet1.発注' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
           

        }

        private void com_shouhin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "true")
            {
                    OleDbConnection olecon = new OleDbConnection();
                    olecon.ConnectionString =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";


                    OleDbCommand olecmd =
                            new OleDbCommand("SELECT * FROM 商品管理 WHERE 商品名=@shouhinmei", olecon);

                    olecmd.Parameters.Add("@shouhinmei", OleDbType.VarChar);
                    olecmd.Parameters["@shouhinmei"].Value = com_shouhin.SelectedValue.ToString();

                    try
                    {
                        olecon.Open();

                        OleDbDataReader oledr = olecmd.ExecuteReader();

                        if (oledr.Read())
                        {
                            txt_shouhinnid.Text = oledr["商品コード"].ToString();
                            txt_zaiko.Text = oledr["在庫数"].ToString();
                            txt_price.Text = oledr["価格"].ToString();
                            //com_shuppan.SelectedItem.Equals(oledr["出版社名"].ToString());
                            com_shuppan.SelectedValue = oledr["出版社"].ToString();
                            txt_shuppannsyaid.Text = oledr["出版社コード"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("エラー 逃げろ！！！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    finally
                    {
                        olecon.Close();
                    }
            }
            
        }

        private void com_shuppan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "true")
            {
                OleDbConnection olecon = new OleDbConnection();
                olecon.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShiiresakiKanri.accdb;";


                OleDbCommand olecmd =
                        new OleDbCommand("SELECT * FROM 仕入先管理 WHERE 出版社名=@shuppanmei", olecon);

                olecmd.Parameters.Add("@shuppanmei", OleDbType.VarChar);
                olecmd.Parameters["@shuppanmei"].Value = com_shuppan.SelectedValue.ToString();

                try
                {
                    olecon.Open();

                    OleDbDataReader oledr = olecmd.ExecuteReader();

                    if (oledr.Read())
                    {
                        txt_shuppannsyaid.Text = oledr["出版社コード"].ToString();
                        //txt_zaiko.Text = oledr["在庫数"].ToString();
                       // com_shouhin.SelectedValue = "";

                    }
                    else
                    {
                        MessageBox.Show("エラー 逃げろ！！！", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                finally
                {
                    olecon.Close();
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "false";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("入力した情報を登録しますか？", "質問", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                RegisterDatagrid();
            }
            else if(result == DialogResult.Cancel)
            {

            }
        }

        private void RegisterDatagrid()
        {
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                OleDbConnection olecon = new OleDbConnection();
                olecon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=HacchuuKannri.accdb;";

                OleDbCommand olecmd =
            new OleDbCommand("INSERT INTO 発注 (発注コード,出版社コード,出版社名,注文コード,商品コード,商品名,店コード,店名,発注数量,単価,金額,発注日付,発注値) VALUES(@発注コード,@出版社コード,@出版社名,@注文コード,@商品コード,@商品名,@店コード,@店名,@発注数量,@単価,@金額,@発注日付,@発注値)", olecon);

                OleDbCommand olecmd2 =
            new OleDbCommand("INSERT INTO 発注金額 (発注コード,金額,コメント) VALUES(@発注コード2,@金額2,@コメント)", olecon);


                olecmd.Parameters.Add("@発注コード", OleDbType.VarChar);
                olecmd.Parameters["@発注コード"].Value = dataGridView1.Rows[i].Cells["発注コード"].Value.ToString();

                olecmd.Parameters.Add("@出版社コード", OleDbType.VarChar);
                olecmd.Parameters["@出版社コード"].Value = dataGridView1.Rows[i].Cells["出版社コード"].Value.ToString();

                olecmd.Parameters.Add("@出版社名", OleDbType.VarChar);
                olecmd.Parameters["@出版社名"].Value = dataGridView1.Rows[i].Cells["出版社名"].Value.ToString();

                olecmd.Parameters.Add("@注文コード", OleDbType.VarChar);
                olecmd.Parameters["@注文コード"].Value = dataGridView1.Rows[i].Cells["注文コード"].Value.ToString();

                olecmd.Parameters.Add("@商品コード", OleDbType.VarChar);
                olecmd.Parameters["@商品コード"].Value = dataGridView1.Rows[i].Cells["商品コード"].Value.ToString();

                olecmd.Parameters.Add("@商品名", OleDbType.VarChar);
                olecmd.Parameters["@商品名"].Value = dataGridView1.Rows[i].Cells["商品名"].Value.ToString();

                olecmd.Parameters.Add("@店コード", OleDbType.VarChar);
                olecmd.Parameters["@店コード"].Value = dataGridView1.Rows[i].Cells["店コード"].Value.ToString();

                olecmd.Parameters.Add("@店名", OleDbType.VarChar);
                olecmd.Parameters["@店名"].Value = dataGridView1.Rows[i].Cells["店名"].Value.ToString();

                olecmd.Parameters.Add("@発注数量", OleDbType.VarChar);
                olecmd.Parameters["@発注数量"].Value = dataGridView1.Rows[i].Cells["発注数量"].Value.ToString();

                olecmd.Parameters.Add("@単価", OleDbType.VarChar);
                olecmd.Parameters["@単価"].Value = dataGridView1.Rows[i].Cells["単価"].Value.ToString();

                olecmd.Parameters.Add("@金額", OleDbType.VarChar);
                olecmd.Parameters["@金額"].Value = dataGridView1.Rows[i].Cells["金額"].Value.ToString();

                olecmd.Parameters.Add("@発注日付", OleDbType.VarChar);
                olecmd.Parameters["@発注日付"].Value = dataGridView1.Rows[i].Cells["発注日付"].Value.ToString();

                olecmd.Parameters.Add("@発注値", OleDbType.VarChar);
                olecmd.Parameters["@発注値"].Value = dataGridView1.Rows[i].Cells["発注値"].Value.ToString();


                if (i == dataGridView1.Rows.Count - 1)
                {
                    olecmd2.Parameters.Add("@発注コード2", OleDbType.VarChar);
                    olecmd2.Parameters["@発注コード2"].Value = dataGridView1.Rows[0].Cells["発注コード"].Value.ToString();

                    olecmd2.Parameters.Add("@金額2", OleDbType.VarChar);
                    olecmd2.Parameters["@金額2"].Value = total_price.Text;

                    olecmd2.Parameters.Add("@コメント", OleDbType.VarChar);
                    olecmd2.Parameters["@コメント"].Value = txt_comment.Text;
                }

                try
                {
                    olecon.Open();


                    int row = olecmd.ExecuteNonQuery();

                    if (row != -1)
                    {

                        if (i == dataGridView1.Rows.Count - 1)
                        {
                            MessageBox.Show("登録しました");
                            this.Close();

                            
                            //dataGridView1.Rows.Clear();
                            //dataGridView1.Refresh();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("例   登録に失敗しました。");
                    //MessageBox.Show(dataGridView1.Rows[0].Cells["発注コード"].Value.ToString());

                }
                finally
                {

                    olecon.Close();
                }


                try
                {
                    olecon.Open();


                    int row2 = olecmd2.ExecuteNonQuery();

                    if (row2 != -1)
                    {

                    }

                }
                catch
                {
                }
                finally
                {

                    olecon.Close();
                }



                OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;");

                OleDbCommand cmd = new OleDbCommand("UPDATE 商品管理 SET 在庫数 = ? WHERE 商品名 = ?", cn);

                cmd.Parameters.Add("@p1", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["new在庫"].Value.ToString();
                cmd.Parameters.Add("@p2", OleDbType.VarChar).Value = dataGridView1.Rows[i].Cells["商品名"].Value.ToString();


                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            
        }

        private void suuryopress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            if (e.KeyChar == 13)
            {
                txt_suuryou.Text = string.Format("{0:n0}", double.Parse(txt_suuryou.Text));
            }
        }

        private void 商品名検索_Click(object sender, EventArgs e)
        {
            int i = com_shouhin.FindStringExact(textBox3.Text);
            if (i >= 0)
            {
                com_shouhin.SelectedIndex = com_shouhin.FindStringExact(textBox3.Text);
            }
            else
            {
                textBox3.Text = "";
            }
        }
    }
}
