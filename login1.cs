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
using System.Drawing.Drawing2D;

namespace login
{
    public partial class login1 : Form
    {
        public login1()
        {

            InitializeComponent();
            lengselected = lenguage.Text; 


            //button1.Width = 75;
            //button1.Height = 30;
            //GraphicsPath p = new GraphicsPath();
           // p.AddEllipse(-1,-1,75,30);
            //button1.Region = new Region(p);

            //button1.Size = new System.Drawing.Size(75, 30);
        }

        public static string lengselected;

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection olecon = new OleDbConnection();
            olecon.ConnectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb;";

            OleDbCommand olecmd =
                new OleDbCommand("SELECT * FROM UserTbl WHERE username=@user AND psw=@psw", olecon);

            olecmd.Parameters.Add("@user", OleDbType.VarChar);
            olecmd.Parameters["@user"].Value = textBox1.Text;
            olecmd.Parameters.Add("@psw", OleDbType.VarChar);
            olecmd.Parameters["@psw"].Value = textBox2.Text;

            try
            {
                olecon.Open();

                OleDbDataReader oledr = olecmd.ExecuteReader();

                if (oledr.Read())
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    login2 f3 = new login2();
                    f3.ShowDialog();
                }
                else
                {
                    MessageBox.Show("ユーザIDまたパスワードが間違えています！もう一度入力してください...", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                olecon.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lenguage.Text = "english";
            lengselected = lenguage.Text;

            label1.Text = "Staff ID";
            label2.Text = "Password";
            button1.Text = "Login";
            button2.Text = "Exit";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lenguage.Text = "japanese";
            lengselected = lenguage.Text;
            label1.Text = "スタッフ　ID";
            label2.Text = "パスワード";
            button1.Text = "ログイン";
            button2.Text = "戻り";
        }


    }
}

