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

namespace login
{
    public partial class login2 : Form
    {
        public login2()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            lenguage.Text = login1.lengselected;
            WindowState = FormWindowState.Maximized;

            if (lenguage.Text == "japanese") { }
            else
            {
                label1.Text = "System Management";
                button1.Text = "Partner";
                button2.Text = "Restock";
                button3.Text = "Delivery";
                button4.Text = "Client Order";
                button5.Text = "Sales";
                button6.Text = "Stock Order";
                button7.Text = "Books";
                button8.Text = "Logout";


            }
        }



        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.torihiki1 f3 = new WindowsFormsApplication1.torihiki1(lenguage);

            f3.ShowDialog();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            chumonkanri.chumon1 f = new chumonkanri.chumon1(lenguage);
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            売上管理.uriage1 f3 = new 売上管理.uriage1(lenguage);
            f3.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            発注管理_.発注管理 f1 = new 発注管理_.発注管理(lenguage);
            f1.ShowDialog();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            商品管理.shouhin1 f2 = new 商品管理.shouhin1(lenguage);
            f2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            入庫管理.nyuko1 f1 = new 入庫管理.nyuko1(lenguage);
            f1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            出庫.syuko1 f1 = new 出庫.syuko1(lenguage);
            f1.ShowDialog();
        }

    }
}
