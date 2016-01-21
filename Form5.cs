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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");

        private const string MailUygunKalip = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 formkapa = new Form5();
            formkapa.Close();
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select * from personel", baglanti);
            yenial.Fill(tablo, "personel");
            dataGridView1.DataSource = tablo.Tables["personel"];
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.Text != "" && textBox1.Text.ToString() != "" && textBox2.Text != "" && textBox3.Text.ToString() != "" && textBox4.Text.ToString() != "" && textBox5.Text != "" && textBox7.Text.ToString() != "" && comboBox1.Text.ToString()!="" )
            {
            baglanti.Open();
            OleDbDataAdapter veri1 = new OleDbDataAdapter("Select yurtID from yurt Where yurtadi Like '" + comboBox1.Text.ToString() + "'", baglanti);
            DataSet ds1 = new DataSet();
            ds1.Clear();
            veri1.Fill(ds1);
            string yurtID = ds1.Tables[0].Rows[0]["yurtID"].ToString();
            baglanti.Close();

           
            baglanti.Open();//öncelikle bağlantımızı açıyoruz.
            OleDbCommand veri = new OleDbCommand("insert into personel (bolum,tc,ad,telefon,email,adres,maas,tarih,yurtadi,yurtID) values('" + comboBox2.Text + "', '" + textBox1.Text.ToString() + "' , '" + textBox2.Text + "','" + textBox3.Text.ToString() + "', '" + textBox4.Text.ToString() + "' , '" + textBox5.Text + "','" + textBox7.Text.ToString() + "', '" + dateTimePicker1.Text.ToString() + "' ,'" + comboBox1.Text.ToString() + "','" + yurtID + "')", baglanti);
            veri.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();
            }
            else
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            OleDbCommand veri = new OleDbCommand("delete from personel where personelID=" +textBox6.Text.ToString() +"", baglanti);
            veri.ExecuteNonQuery();
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
              if (comboBox2.Text != "" && textBox1.Text.ToString() != "" && textBox2.Text != "" && textBox3.Text.ToString() != "" && textBox4.Text.ToString() != "" && textBox5.Text != "" && textBox7.Text.ToString() != "" && comboBox1.Text.ToString()!="" )
            {
            baglanti.Open();
            int satir;
            satir = dataGridView1.CurrentRow.Index;
            int id = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
            OleDbCommand veri = new OleDbCommand("update personel set bolum='" + comboBox2.Text + "',tc='" + textBox1.Text.ToString() + "',ad='" + textBox2.Text + "',telefon='" + textBox3.Text.ToString() + "',email='" + textBox4.Text.ToString() + "',adres='" + textBox5.Text + "',maas='" + textBox7.Text + "',tarih='" +dateTimePicker1.Text.ToString() +"'where personelID=" + id + "", baglanti);
            veri.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemini< Başarıyla gerçekleşmiştir.");
              }

            else
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz.");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int satir;
            satir = dataGridView1.CurrentRow.Index;
            string k;
            k = dataGridView1.Rows[satir].Cells[0].Value.ToString();
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select * from personel Where personelID Like '" + k + "'", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);


            comboBox2.Text = ds.Tables[0].Rows[0]["bolum"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["tc"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["ad"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["email"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["adres"].ToString();
            textBox7.Text = ds.Tables[0].Rows[0]["maas"].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0]["tarih"].ToString(); 
            comboBox1.Text = ds.Tables[0].Rows[0]["yurtadi"].ToString();


            baglanti.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Form5_Load(object sender, EventArgs e)
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

       
       

       
    }
}
