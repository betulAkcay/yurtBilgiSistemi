using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ybs
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");
        OleDbCommand komut; // sql cümlelerini bu kodu kullanarak yazıcaz.

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 formkapa = new Form8();
            formkapa.Close();
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new OleDbCommand("select * from ogrenci where numara Like '%" + textBox1.Text + "%'", baglanti);
            OleDbDataAdapter data = new OleDbDataAdapter(komut);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            dataGridView1.DataSource = tbl;
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new OleDbCommand("select * from ogrenci where isim Like '%" + textBox2.Text + "%' and soyisim Like '%"+textBox3.Text+"%'" , baglanti);
            OleDbDataAdapter data = new OleDbDataAdapter(komut);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            dataGridView1.DataSource = tbl;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new OleDbCommand("select * from ogrenci where bolum Like '%" + textBox4.Text + "%'", baglanti);
            OleDbDataAdapter data = new OleDbDataAdapter(komut);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            dataGridView1.DataSource = tbl;
            baglanti.Close();
        }
    }
}
