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
    public partial class torihiki3 : Form
    {
        public torihiki3()
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

                ocmd.CommandText = "SELECT 出版社コード,登録日,出版社名,ふりがな,住所,電話番号,携帯番号,郵便番号 FROM 仕入先管理 ORDER BY 出版社コード ASC";
                //ocmd.CommandText = "SELECT TOP 1 * FROM 会員管理 ORDER BY 店コード DESC";


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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
