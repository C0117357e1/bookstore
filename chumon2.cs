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


namespace chumonkanri
{
    public partial class chumon2 : Form
    {

        int k = 0;

        public chumon2()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            dataGridView1.Columns["注文コード値"].Visible = false;
            dataGridView1.Columns["new在庫"].Visible = false;
            dataGridView1.Columns["new発注"].Visible = false;

            WindowState = FormWindowState.Maximized;

            textBox1.Text = "true";

            textBox_suuryou.Text = "0";

            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                //ocmd.CommandText = "SELECT * FROM 会員管理";
                ocmd.CommandText = "SELECT TOP 1 * FROM 注文管理 ORDER BY 注文コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                textBox_chumonid.Text = dt.Rows[0]["注文コード値"].ToString();
                int i = int.Parse(textBox_chumonid.Text);
                i += 1;
                textBox_chumonid2.Text=i.ToString();

                textBox_chumon.Text = "C" + i.ToString("0000");



                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }



        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "false";
            this.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: このコード行はデータを 'kainKanriDataSet1.会員管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.会員管理TableAdapter1.Fill(this.kainKanriDataSet1.会員管理);
            // TODO: このコード行はデータを 'shouhinKanriDataSet1.商品管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.商品管理TableAdapter1.Fill(this.shouhinKanriDataSet1.商品管理);

            // TODO: このコード行はデータを 'kainKanriDataSet.会員管理' テーブルに読み込みます。必要に応じて移動、または削除をしてください。
            this.会員管理TableAdapter.Fill(this.kainKanriDataSet.会員管理);
 

        }

        private void shouhinmei_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "true")
            {

                OleDbConnection olecon = new OleDbConnection();
                olecon.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";

                OleDbCommand olecmd =
                    new OleDbCommand("SELECT * FROM 商品管理 WHERE 商品名=@shouhinmei", olecon);

                olecmd.Parameters.Add("@shouhinmei", OleDbType.VarChar);
                olecmd.Parameters["@shouhinmei"].Value = ComboBox_shouhinmei.SelectedValue.ToString();


                try
                {
                    olecon.Open();

                    OleDbDataReader oledr = olecmd.ExecuteReader();

                    if (oledr.Read())
                    {
                        TextBox_shouhinid.Text = oledr[0].ToString();
                        textBox_zaikosuu.Text = oledr[6].ToString();
                        textBox_kakaku.Text = oledr[7].ToString()+"\\";
                        textBox_kakakunoen.Text = oledr[7].ToString();

                        if (int.Parse(textBox_zaikosuu.Text) < 50)
                        {
                            textBox_anzenzaiko.Text = "発注してください。";
                        }
                        else
                        {
                            textBox_anzenzaiko.Text = "";

                        }

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

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void Combobox_misemei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "true")
            {

                OleDbConnection olecon = new OleDbConnection();
                olecon.ConnectionString =
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KainKanri.accdb;";

                OleDbCommand olecmd =
                    new OleDbCommand("SELECT * FROM 会員管理 WHERE 店名=@misemei", olecon);

                olecmd.Parameters.Add("@misemei", OleDbType.VarChar);
                olecmd.Parameters["@misemei"].Value = ComboBox_misemei.SelectedValue.ToString();


                try
                {
                    olecon.Open();

                    OleDbDataReader oledr = olecmd.ExecuteReader();

                    if (oledr.Read())
                    {
                        TextBox_miseid.Text = oledr[0].ToString();
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

        private void button_shouhintsuika_Click(object sender, EventArgs e)
        {

            if (TextBox_shouhinid.Text == "" || TextBox_miseid.Text == "" || ComboBox_misemei.SelectedValue.ToString() == "" || ComboBox_shouhinmei.SelectedValue.ToString() == "" || textBox_suuryou.Text == "0")
            {
                MessageBox.Show("店名/商品名/数量を入力してください。", "情報入力", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
               

                    DataTable dt = new DataTable();
                    dt = (DataTable)dataGridView1.DataSource;
                    string c1 = textBox_chumon.Text;
                    string c4 = TextBox_shouhinid.Text;
                    string c2 = TextBox_miseid.Text;
                    string c5 = ComboBox_shouhinmei.SelectedValue.ToString();
                    string c3 = ComboBox_misemei.SelectedValue.ToString();
                    string c6 = dateTimePicker1.Value.ToString("yyyy/MM/dd");
                    string c8 = textBox_suuryou.Text;
                    string c7 = textBox_kakakunoen.Text;
                    string c10 = textBox_chumonid2.Text;
                    string c9 = ((int.Parse(textBox_kakakunoen.Text)) * (int.Parse(textBox_suuryou.Text))).ToString();
                    string c11 = textBox_hacchujoutai.Text;

                    int zaiko = int.Parse(textBox_zaikosuu.Text);
                    int suryou = int.Parse(textBox_suuryou.Text);
                    int newzaiko = zaiko - suryou;
                    int newhacchu = 50 - newzaiko;

                    string c12 = newzaiko.ToString();
                    string c15 = newhacchu.ToString();



                    OleDbConnection olecon = new OleDbConnection();
                    olecon.ConnectionString =
                        "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShouhinKanri.accdb;";

                    OleDbCommand olecmd =
                        new OleDbCommand("SELECT * FROM 商品管理 WHERE 商品名=@shouhinmei", olecon);

                    olecmd.Parameters.Add("@shouhinmei", OleDbType.VarChar);
                    olecmd.Parameters["@shouhinmei"].Value = ComboBox_shouhinmei.SelectedValue.ToString();


                    try
                    {
                        olecon.Open();

                        OleDbDataReader oledr = olecmd.ExecuteReader();

                        if (oledr.Read())
                        {
                            shuppanshacode_add.Text = oledr[3].ToString();
                            shuppanshamei_add.Text = oledr[4].ToString();
                         

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
                
                
                
                
                
                 string c13=shuppanshacode_add.Text ;
                 string c14 = shuppanshamei_add.Text;
                
                
                
                
                
                    





                    k = k + int.Parse(c9);
                    textBox_KINGAKUFINALnoen.Text = k.ToString();

                    textBox_KINGAKUFINAL.Text = textBox_KINGAKUFINALnoen.Text + "\\";

                    string[] row = { c1, c2, c3, c13, c14, c4, c5, c6, c7, c8, c9, c10, c11, c12,c15 };
                    dataGridView1.Rows.Add(row);

                    textBox_hacchujoutai.Text = "いらない";

                    ComboBox_shouhinmei.SelectedIndex = 0;
                    TextBox_shouhinid.Text = "";
                    textBox_kakaku.Text = "";
                    textBox_zaikosuu.Text = "";
                    textBox_suuryou.Text = "0";
                    textBox_anzenzaiko.Text = "";


            }

            
        }

        private void textBox_suuryou_TextChanged(object sender, EventArgs e)
        {

           

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox1.Text = "false";

        }

        private void button_kakunin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("入力した情報とうろくしますか？", "質問", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                int chumondekinai=0;
                for (int p = 0; p < dataGridView1.Rows.Count - 1; p++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[p].Cells["new在庫"].Value) < 0 && dataGridView1.Rows[p].Cells["発注状態"].Value.ToString() == "いらない") { chumondekinai += 1; }
                    else {  }
                }


                if (chumondekinai==0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {


                        OleDbConnection olecon = new OleDbConnection();
                        olecon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ChumonKanri.accdb;";

                        OleDbCommand olecmd =
                 new OleDbCommand("INSERT INTO 注文管理 (注文コード,商品コード,商品名, 店コード,店名,伝票日付,単価,数量,金額商品,注文コード値,発注状態) VALUES(@注文コード,@商品コード,@商品名, @店コード,@店名,@伝票日付,@単価,@数量,@金額商品,@注文コード値,@発注状態)", olecon);

                        OleDbCommand olecmd2 =
                 new OleDbCommand("INSERT INTO 注文管理金額 (注文コード,金額,コメント) VALUES(@注文コード2,@金額,@コメント)", olecon);





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

                        olecmd.Parameters.Add("@伝票日付", OleDbType.VarChar);
                        olecmd.Parameters["@伝票日付"].Value = dataGridView1.Rows[i].Cells["伝票日付"].Value.ToString();

                        olecmd.Parameters.Add("@単価", OleDbType.VarChar);
                        olecmd.Parameters["@単価"].Value = dataGridView1.Rows[i].Cells["単価"].Value.ToString();

                        olecmd.Parameters.Add("@数量", OleDbType.VarChar);
                        olecmd.Parameters["@数量"].Value = dataGridView1.Rows[i].Cells["数量"].Value.ToString();

                        olecmd.Parameters.Add("@金額商品", OleDbType.VarChar);
                        olecmd.Parameters["@金額商品"].Value = dataGridView1.Rows[i].Cells["金額商品"].Value.ToString();

                        olecmd.Parameters.Add("@注文コード値", OleDbType.VarChar);
                        olecmd.Parameters["@注文コード値"].Value = dataGridView1.Rows[i].Cells["注文コード値"].Value.ToString();

                        olecmd.Parameters.Add("@発注状態", OleDbType.VarChar);
                        olecmd.Parameters["@発注状態"].Value = dataGridView1.Rows[i].Cells["発注状態"].Value.ToString();


                        if (i == dataGridView1.Rows.Count - 2)
                        {
                            olecmd2.Parameters.Add("@注文コード2", OleDbType.VarChar);
                            olecmd2.Parameters["@注文コード2"].Value = dataGridView1.Rows[0].Cells["注文コード"].Value.ToString();

                            olecmd2.Parameters.Add("@金額", OleDbType.VarChar);
                            olecmd2.Parameters["@金額"].Value = textBox_KINGAKUFINALnoen.Text;


                            olecmd2.Parameters.Add("@コメント", OleDbType.VarChar);
                            olecmd2.Parameters["@コメント"].Value = textBox_comment.Text;
                        }







                        try
                        {
                            olecon.Open();


                            int row = olecmd.ExecuteNonQuery();

                            if (row != -1)
                            {
                                if (i == dataGridView1.Rows.Count - 2)
                                {
                                    MessageBox.Show("登録しました");

                                }


                            }





                        }
                        catch
                        {
                            MessageBox.Show("例 " + i.ToString() + "   登録に失敗しました。");

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





                    ComboBox_shouhinmei.SelectedIndex = 0;
                    TextBox_shouhinid.Text = "";
                    textBox_kakaku.Text = "";
                    textBox_zaikosuu.Text = "";
                    textBox_suuryou.Text = "0";
                    textBox_anzenzaiko.Text = "";
                    TextBox_miseid.Text = "";
                    ComboBox_misemei.SelectedIndex = 0;
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    textBox_KINGAKUFINAL.Text = "";


                    button_shouhintsuika.Enabled = true;
                    button_cancel.Enabled = true;
                    ExitBtn.Enabled = true;
                    button_hacchu.Enabled = true;
                    this.ControlBox = true;

                }

                else
                {
                    MessageBox.Show("発注してください。");

                }

                

            }

            else if (result == DialogResult.Cancel)
            {
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button_hacchu_Click(object sender, EventArgs e)
        {





            DialogResult result = MessageBox.Show("入力した情報発注しますか？", "質問", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                button_shouhintsuika.Enabled = false;
                button_cancel.Enabled = false;
                ExitBtn.Enabled = false;
                button_hacchu.Enabled = false;
                this.ControlBox = false;


                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {

                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value) < 50)
                    {
                        dataGridView1.Rows[i].Cells[12].Value = "待機";
                        dataGridView1.Rows[i].Cells["new在庫"].Value = 50;
                    }


                }

                //textBox_hacchujoutai.Text = "待っている";

                発注管理_.txt_chuumoncode2 f1 = new 発注管理_.txt_chuumoncode2(dataGridView1);
                f1.ShowDialog();
                // Form4 f = new Form4(); go to hacchuuuuuuuuu
                //f.Show();

            }



            else if (result == DialogResult.Cancel)
            {

                MessageBox.Show("発注キャンセルされました。");

            }
        








            
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }


    

        private void suuryoupress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            textBox_kakaku.Text = "";
            textBox_zaikosuu.Text="";
            textBox_anzenzaiko.Text = "";
            textBox_suuryou.Text="0";
            dataGridView1.Rows.Clear();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
         
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void 商品名検索_Click(object sender, EventArgs e)
        {



            int i = ComboBox_shouhinmei.FindStringExact(textBox2.Text);
            if (i >= 0)
            {
                ComboBox_shouhinmei.SelectedIndex = ComboBox_shouhinmei.FindStringExact(textBox2.Text);
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
