using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Atestat
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(459, 530);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
            this.Close();
            
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                label2_Click(sender, e);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Breakout" + Environment.NewLine + "Proiect realizat de Toncea Alin","About");
        }
    }
}
