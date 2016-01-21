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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");
        OleDbCommand veri; // sql cümlelerini bu kodu kullanarak yazıcaz.

        private void button5_Click(object sender, EventArgs e)
        {

            Form3 formkapa = new Form3();
            formkapa.Close();
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select * from yurt", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && comboBox1.Text.ToString()!="" && textBox7.Text.ToString()!="" && textBox2.Text.ToString()!="" &&  textBox3.Text.ToString()!="" && textBox4.Text.ToString()!="" && comboBox3.Text.ToString()!="" && textBox5.Text.ToString()!="" && comboBox4.Text.ToString()!="" && textBox6.Text.ToString()!="" )
            {
                baglanti.Open();
                veri = new OleDbCommand("insert into yurt (yurtadi,il,ilce,adres,telefon,faks,yurtcins,Oaded,tarih,odakapasitesi,mudurad) values('" + textBox1.Text + "', '" + comboBox1.Text.ToString() + "' , '" + textBox7.Text.ToString() + "','" + textBox2.Text.ToString() + "', '" + textBox3.Text.ToString() + "' , '" + textBox4.Text.ToString() + "','" + comboBox3.Text.ToString() + "', '" + textBox5.Text.ToString() + "' , '" + dateTimePicker1.Text.ToString() + "' , '" + comboBox4.Text.ToString() + "'  , '" + textBox6.Text.ToString() + "')", baglanti);
                veri.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
                baglanti.Close();
            }
            else
                MessageBox.Show("Boş alanları doldurunuz.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox9.Text != "")
            {
                baglanti.Open();

                veri = new OleDbCommand("delete from yurt where yurtID=" + textBox9.Text.ToString() + "", baglanti);
                veri.ExecuteNonQuery();
                MessageBox.Show("silme işleminiz başarıyla gerçekleşti.");
                baglanti.Close();
            }
            else
            {
                MessageBox.Show ("yurtID giriniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
              if (textBox1.Text!="" && comboBox1.Text.ToString()!="" && textBox7.Text.ToString()!="" && textBox2.Text.ToString()!="" &&  textBox3.Text.ToString()!="" && textBox4.Text.ToString()!="" && comboBox3.Text.ToString()!="" && textBox5.Text.ToString()!="" && comboBox4.Text.ToString()!="" && textBox6.Text.ToString()!="" )
            {
            baglanti.Open();
            int satir;
            satir = dataGridView1.CurrentRow.Index;
            int id = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
            veri = new OleDbCommand("update yurt set yurtadi='" + textBox1.Text.ToString() + "',il='" + comboBox1.Text.ToString() + "',ilce='" + textBox7.Text.ToString() + "',adres='" + textBox2.Text.ToString() + "',telefon='" + textBox3.Text.ToString() + "',faks='" + textBox4.Text.ToString() + "',yurtcins='" + comboBox3.Text.ToString() + "',Oaded='" + textBox5.Text.ToString() + "',tarih='" + dateTimePicker1.Text.ToString() + "',odakapasitesi='" + comboBox4.Text.ToString() + "'where yurtID=" + id + "", baglanti);
            veri.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı..");
            }
              else
                  MessageBox.Show("Boş alanları doldurunuz.");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int satir;
            satir = dataGridView1.CurrentRow.Index;
            string k;
            k = dataGridView1.Rows[satir].Cells[0].Value.ToString();
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select * from yurt Where yurtID Like '" + k.Trim() + "'", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);

                textBox1.Text = ds.Tables[0].Rows[0]["yurtadi"].ToString();
                comboBox1.Text = ds.Tables[0].Rows[0]["il"].ToString();
                textBox7.Text = ds.Tables[0].Rows[0]["ilce"].ToString();
                textBox2.Text = ds.Tables[0].Rows[0]["adres"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
                textBox4.Text = ds.Tables[0].Rows[0]["faks"].ToString();
                comboBox3.Text = ds.Tables[0].Rows[0]["yurtcins"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["Oaded"].ToString();
                comboBox4.Text = ds.Tables[0].Rows[0]["odakapasitesi"].ToString();
                dateTimePicker1.Text = ds.Tables[0].Rows[0]["tarih"].ToString();
                textBox6.Text = ds.Tables[0].Rows[0]["mudurad"].ToString();

            baglanti.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

       
    }
}
