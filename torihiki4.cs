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



namespace WindowsFormsApplication1
{
    public partial class torihiki4 : Form
    {
        public torihiki4()
        {
           

            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KainKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                //ocmd.CommandText = "SELECT * FROM 会員管理";
                ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                StoreIDN.Text = dt.Rows[0]["店コード値"].ToString();
                int i = int.Parse(StoreIDN.Text);
                i += 1;

                StoreID.Text = "K" + i.ToString("0000");



                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("入力した内容登録しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                if (Store.Text == "" || Address.Text == "" || Furigana.Text == "" || Telephone.Text == "" || Keitai.Text == "" || Postal.Text == "")
                {
                    MessageBox.Show("空いているところ入力してください。");

                }
                else
                {
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");

                    Registereddatabase();
                    this.Hide();
                    torihiki4 f = new torihiki4();
                    f.ShowDialog();
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
            olecon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KainKanri.accdb;";

            OleDbCommand olecmd =
     new OleDbCommand("INSERT INTO 会員管理(店コード,登録日,店名,ふりがな,住所,電話番号,携帯番号,郵便番号,店コード値) VALUES(@店コード,@登録日,@店名,@ふりがな,@住所,@電話番号,@携帯番号,@郵便番号,@店コード値)", olecon);

            olecmd.Parameters.Add("@店コード", OleDbType.VarChar);
            olecmd.Parameters["@店コード"].Value = StoreID.Text;

            olecmd.Parameters.Add("@登録日", OleDbType.DBDate);
            olecmd.Parameters["@登録日"].Value = dateTimePicker1.Value;

            olecmd.Parameters.Add("@店名", OleDbType.VarChar);
            olecmd.Parameters["@店名"].Value = Store.Text;

            olecmd.Parameters.Add("@ふりがな", OleDbType.VarChar);
            olecmd.Parameters["@ふりがな"].Value = Furigana.Text;

            olecmd.Parameters.Add("@住所", OleDbType.VarChar);
            olecmd.Parameters["@住所"].Value = Address.Text;

            olecmd.Parameters.Add("@電話番号", OleDbType.VarChar);
            olecmd.Parameters["@電話番号"].Value = Telephone.Text;

            olecmd.Parameters.Add("@携帯番号", OleDbType.VarChar);
            olecmd.Parameters["@携帯番号"].Value = Keitai.Text;

            olecmd.Parameters.Add("@郵便番号", OleDbType.VarChar);
            olecmd.Parameters["@郵便番号"].Value = Postal.Text;

            int i = int.Parse(StoreIDN.Text);
            i += 1;

            olecmd.Parameters.Add("@店コード値", OleDbType.VarChar);
            olecmd.Parameters["@店コード値"].Value = i;

            

            try
            {
                olecon.Open();


                int row = olecmd.ExecuteNonQuery();
                if (row != -1)
                {
                    MessageBox.Show("登録しました");

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

        private void StoreList_Click(object sender, EventArgs e)
        {
            torihiki5 f = new torihiki5();
            f.ShowDialog();
        }
    }
}
