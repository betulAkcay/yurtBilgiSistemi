using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ybs
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form6 formkapa = new Form6();
            formkapa.Close();
            Form7 form = new Form7();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form6 formkapa = new Form6();
            formkapa.Close();
            Form8 form = new Form8();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 formkapa = new Form6();
            formkapa.Close();
            Form9 form = new Form9();
            form.Show();
            this.Hide();
        }
    }
}
