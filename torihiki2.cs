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
    public partial class torihiki2 : Form
    {
        public torihiki2()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

            OleDbConnection olecon = new OleDbConnection();

            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShiiresakiKanri.accdb;";

            try
            {
                olecon.Open();
                OleDbCommand ocmd = new OleDbCommand();
                ocmd.Connection = olecon;

                //ocmd.CommandText = "SELECT * FROM 会員管理";
                ocmd.CommandText = "SELECT TOP 1 * FROM 仕入先管理 ORDER BY 出版社コード DESC";


                OleDbDataAdapter adapter = new OleDbDataAdapter(ocmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ProviderIDN.Text = dt.Rows[0]["出版社コード値"].ToString();
                int i = int.Parse(ProviderIDN.Text);
                i += 1;

                ProviderID.Text = "S" + i.ToString("0000");



                olecon.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
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

                if (Provider.Text == "" || Address.Text == "")
                {
                    MessageBox.Show("出版社名と住所入力してください。");

                }
                else
                {
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");

                    Registereddatabase();
                    this.Hide();
                    torihiki2 f = new torihiki2();
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
            olecon.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ShiiresakiKanri.accdb;";

            OleDbCommand olecmd =
     new OleDbCommand("INSERT INTO 仕入先管理(出版社コード,登録日,出版社名,ふりがな,住所,電話番号,携帯番号,郵便番号,出版社コード値) VALUES(@出版社コード,@登録日,@出版社名,@ふりがな,@住所,@電話番号,@携帯番号,@郵便番号,@出版社コード値)", olecon);

            olecmd.Parameters.Add("@出版社コード", OleDbType.VarChar);
            olecmd.Parameters["@出版社コード"].Value = ProviderID.Text;

            olecmd.Parameters.Add("@登録日", OleDbType.DBDate);
            olecmd.Parameters["@登録日"].Value = dateTimePicker1.Value;

            olecmd.Parameters.Add("@出版社名", OleDbType.VarChar);
            olecmd.Parameters["@出版社名"].Value = Provider.Text;

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

            int i = int.Parse(ProviderIDN.Text);
            i += 1;

            olecmd.Parameters.Add("@出版社コード値", OleDbType.VarChar);
            olecmd.Parameters["@出版社コード値"].Value = i;



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

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void list_Click(object sender, EventArgs e)
        {
            torihiki3 f = new torihiki3();
            f.ShowDialog();
        }
    }
}
