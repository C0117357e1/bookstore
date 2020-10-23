using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class torihiki1 : Form
    {
        public torihiki1()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            WindowState = FormWindowState.Maximized;

        }

         public torihiki1(TextBox lengt)
        {
            InitializeComponent();

            string len = lengt.Text;
            lenguaget1.Text = len;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            torihiki2 f = new torihiki2();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            torihiki4 f = new torihiki4();
            f.ShowDialog();
        }
    }
}
