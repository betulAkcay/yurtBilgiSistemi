using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
namespace ybs
{
    
    public partial class Form4 : Form
    {
        private BindingSource cb = new BindingSource();
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");
        OleDbCommand komut; // sql cümlelerini bu kodu kullanarak yazıcaz.

        private const string MailUygunKalip = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        private void button4_Click(object sender, EventArgs e)
        {

            Form4 formkapa = new Form4();
            formkapa.Close();
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool retVal = false;
            retVal = Regex.IsMatch(textBox5.Text, MailUygunKalip);
            if (retVal)
            {

            }
            else
            {
                MessageBox.Show("Mail Adresi Geçersiz...");
                return;
            }
            if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "" && textBox4.Text.ToString() != "" && textBox6.Text.ToString() != "" && textBox7.Text.ToString() != "" && textBox3.Text.ToString() != "" && textBox5.Text.ToString() != "" && comboBox1.Text.ToString() != "" && textBox8.Text.ToString() != "" && textBox10.Text.ToString() != "")
            {
                baglanti.Open();
                OleDbDataAdapter veri1 = new OleDbDataAdapter("Select yurtID from yurt Where yurtadi Like '" + comboBox1.Text.ToString() + "'", baglanti);
                DataSet ds1 = new DataSet();
                ds1.Clear();
                veri1.Fill(ds1);
                string yurtID = ds1.Tables[0].Rows[0]["yurtID"].ToString();
                baglanti.Close();

                baglanti.Open();
                OleDbCommand komut1 = new OleDbCommand("INSERT INTO mudur ( tc,isim,soyisim,yas,adres,telefon,eposta,yurtadi,yurtID,kullaniciad,kullanicisifre) VALUES ('" + textBox1.Text.ToString() + "'  ,  '" + textBox2.Text.ToString() + "' , '" + textBox4.Text.ToString() + "' , '" + textBox6.Text.ToString() + "' , '" + textBox7.Text.ToString() + "' , '" + textBox3.Text.ToString() + "' , '" + textBox5.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + yurtID + "', '" + textBox8.Text.ToString() + "', '" + textBox10.Text.ToString() + "') ", baglanti);
                komut1.ExecuteNonQuery();
                MessageBox.Show("kayıt eklendi");
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select * from mudur", baglanti);
            yenial.Fill(tablo, "mudur");
            dataGridView1.DataSource = tablo.Tables["mudur"];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new OleDbCommand("delete from mudur where mudurID=" + textBox9.Text.ToString() + "", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("silme işleminiz başarıyla gerçekleşti.");
            baglanti.Close();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool retVal = false;
            retVal = Regex.IsMatch(textBox5.Text, MailUygunKalip);
            if (retVal)
            {

            }
            else
            {
                MessageBox.Show("Mail Adresi Geçersiz...");
                return;
            }
            if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "" && textBox4.Text.ToString() != "" && textBox6.Text.ToString() != "" && textBox7.Text.ToString() != "" && textBox3.Text.ToString() != "" && textBox5.Text.ToString() != "" && comboBox1.Text.ToString() != "" && textBox8.Text.ToString() != "" && textBox10.Text.ToString() != "")
            {
                baglanti.Open();
                OleDbDataAdapter veri1 = new OleDbDataAdapter("Select yurtID from yurt Where yurtadi Like '" + comboBox1.Text.ToString() + "'", baglanti);
                DataSet ds1 = new DataSet();
                ds1.Clear();
                veri1.Fill(ds1);
                string yurtID = ds1.Tables[0].Rows[0]["yurtID"].ToString();
                baglanti.Close();

                baglanti.Open();
                int satir;
                satir = dataGridView1.CurrentRow.Index;
                int id = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
                komut = new OleDbCommand("update mudur set tc='" + textBox1.Text.ToString() + "',isim='" + textBox2.Text.ToString() + "',soyisim='" + textBox4.Text.ToString() + "',yas='" + textBox6.Text.ToString() + "',adres='" + textBox7.Text.ToString() + "',telefon='" + Convert.ToString(textBox3.Text) + "',eposta='" + textBox5.Text.ToString() + "',yurtID='"+Convert.ToInt32(yurtID)+"',yurtadi='"+comboBox1.Text.ToString()+"',kullaniciad='"+textBox8.Text.ToString()+"',kullanicisifre='"+textBox10.Text.ToString()+"' where mudurID=" + id + "", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme işleminiz başarıyla gerçekleşmiştir.");
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int satir;
            satir = dataGridView1.CurrentRow.Index;
            string k;
            k = dataGridView1.Rows[satir].Cells[0].Value.ToString();
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select * from mudur Where mudurID Like '" +Int32.Parse(k) + "'", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            textBox1.Text = ds.Tables[0].Rows[0]["tc"].ToString();
            textBox7.Text = ds.Tables[0].Rows[0]["adres"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["isim"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["soyisim"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["eposta"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["yas"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["mudurID"].ToString();
            textBox10.Text = ds.Tables[0].Rows[0]["kullanicisifre"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["kullaniciad"].ToString();

            baglanti.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
                OleDbCommand veri = new OleDbCommand("SELECT yurtadi FROM yurt", baglanti);
                OleDbDataReader oku;
                baglanti.Open();
                oku = veri.ExecuteReader();

                while (oku.Read())
                {
                   comboBox1.Items.Add(oku["yurtadi"].ToString());
                }
                oku.Close();
                baglanti.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
