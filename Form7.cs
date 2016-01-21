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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private const string MailUygunKalip = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
        private void button4_Click(object sender, EventArgs e)
        {

            Form7 formkapa = new Form7();
            formkapa.Close();
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");

        public void mudurID() { 
        
        
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
            if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "" && textBox3.Text.ToString() != "" && textBox7.Text.ToString() != "" && textBox13.Text.ToString() != "" && textBox6.Text.ToString() != "" && textBox5.Text.ToString() != "" && textBox4.Text.ToString() != "" && comboBox2.Text.ToString() != "" && comboBox1.Text.ToString() != "" && textBox14.Text.ToString() != "" && textBox11.Text.ToString() != "" && textBox9.Text.ToString() != "" && textBox8.Text.ToString() != "" && textBox12.Text.ToString() != "" && textBox16.Text.ToString() != "" && comboBox5.Text.ToString() != "" && comboBox3.Text.ToString() != "" && textBox20.Text.ToString() != "" && textBox19.Text.ToString() != "" && textBox18.Text.ToString() != "" && textBox17.Text.ToString()!="")
            {
                baglanti.Open();
                OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss", baglanti);
                DataSet ds = new DataSet();
                ds.Clear();
                komutt.Fill(ds);
                string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
                baglanti.Close();

                baglanti.Open();//öncelikle bağlantımızı açıyoruz.
                OleDbCommand veri = new OleDbCommand("INSERT INTO ogrenci(mudurID,isim,soyisim,tc,dtarih,telefon,eposta,universite,fakulte,bolum,sinif,ogretim,numara,v_isim,v_soyisim,v_tel,v_eposta,odano,odatip,kat1,masa,dolap,yatak,sandalye) VALUES ('" + Int32.Parse(mudurID) + "','" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dateTimePicker9.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox13.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox14.Text.ToString() + "','" + textBox11.Text.ToString() + "','" + textBox9.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox12.Text.ToString() + "','" + textBox16.Text.ToString() + "','" + comboBox5.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox20.Text.ToString() + "','" + textBox19.Text.ToString() + "','" + textBox18.Text.ToString() + "','" + textBox17.Text.ToString() + "')", baglanti);
                veri.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı");
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("Boş alanları doldurnuz.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select * from ogrenci where mudurID Like '"+Int32.Parse(mudurID)+"'", baglanti);
            yenial.Fill(tablo, "ogrenci");
            dataGridView1.DataSource = tablo.Tables["ogrenci"];
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
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
             if (textBox1.Text.ToString() != "" && textBox2.Text.ToString() != "" && textBox3.Text.ToString() != "" && textBox7.Text.ToString() != "" && textBox13.Text.ToString() != "" && textBox6.Text.ToString() != "" && textBox5.Text.ToString() != "" && textBox4.Text.ToString() != "" && comboBox2.Text.ToString() != "" && comboBox1.Text.ToString() != "" && textBox14.Text.ToString() != "" && textBox11.Text.ToString() != "" && textBox9.Text.ToString() != "" && textBox8.Text.ToString() != "" && textBox12.Text.ToString() != "" && textBox16.Text.ToString() != "" && comboBox5.Text.ToString() != "" && comboBox3.Text.ToString() != "" && textBox20.Text.ToString() != "" && textBox19.Text.ToString() != "" && textBox18.Text.ToString() != "" && textBox17.Text.ToString()!="")
            {
            baglanti.Open();
            int satir;
            satir = dataGridView1.CurrentRow.Index;
            int id = Convert.ToInt32(dataGridView1.Rows[satir].Cells[0].Value);
            OleDbCommand veri = new OleDbCommand("update ogrenci set isim='" + textBox1.Text.ToString() + "',soyisim='" + textBox2.Text.ToString() + "',tc='" + textBox3.Text.ToString() + "',dtarih='" + dateTimePicker9.Text.ToString() + "',telefon='" + textBox7.Text.ToString() + "',eposta='" + textBox13.Text.ToString() + "',universite='" + textBox6.Text.ToString() + "',fakulte='" + textBox5.Text.ToString() + "',bolum='" + textBox4.Text.ToString() + "',sinif='" + comboBox2.Text.ToString() + "',ogretim='" + comboBox1.Text.ToString() + "',numara='" + textBox14.Text.ToString() + "',v_isim='" + textBox11.Text.ToString() + "',v_soyisim='" + textBox9.Text.ToString() + "',v_tel='" + textBox8.Text.ToString() + "',v_eposta='" + textBox12.Text.ToString() + "',odano='" + textBox16.Text.ToString() + "',odatip='" + comboBox5.Text.ToString() + "',kat1='" + comboBox3.Text.ToString() + "',masa='" + textBox20.Text.ToString() + "',dolap='" + textBox19.Text.ToString() + "',yatak='" + textBox18.Text.ToString() + "',sandalye='" + textBox17.Text.ToString() + "' where ogrenciID=" + id + "", baglanti);
            veri.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı..");
            }
             else
             {
                 MessageBox.Show("Boş alanları doldurnuz.");
             }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int s;
            s = dataGridView1.CurrentRow.Index;
            string k;
            k = dataGridView1.Rows[s].Cells[0].Value.ToString();
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select * from ogrenci Where ogrenciID Like '" + k + "'", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);

            textBox10.Text = ds.Tables[0].Rows[0]["ogrenciID"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["isim"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["soyisim"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["tc"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["bolum"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["fakulte"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["universite"].ToString();
            textBox7.Text = ds.Tables[0].Rows[0]["telefon"].ToString();
            comboBox2.Text = ds.Tables[0].Rows[0]["sinif"].ToString();
            comboBox1.Text = ds.Tables[0].Rows[0]["ogretim"].ToString();
            textBox14.Text = ds.Tables[0].Rows[0]["numara"].ToString();
            textBox11.Text = ds.Tables[0].Rows[0]["v_isim"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["v_soyisim"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["v_tel"].ToString();
            textBox12.Text = ds.Tables[0].Rows[0]["v_eposta"].ToString();
            dateTimePicker9.Text = ds.Tables[0].Rows[0]["dtarih"].ToString();
            textBox16.Text = ds.Tables[0].Rows[0]["odano"].ToString();
            comboBox5.Text = ds.Tables[0].Rows[0]["odatip"].ToString();
            comboBox3.Text = ds.Tables[0].Rows[0]["kat1"].ToString();
            textBox20.Text = ds.Tables[0].Rows[0]["masa"].ToString();
            textBox19.Text = ds.Tables[0].Rows[0]["dolap"].ToString();
            textBox18.Text = ds.Tables[0].Rows[0]["yatak"].ToString();
            textBox17.Text = ds.Tables[0].Rows[0]["sandalye"].ToString();

            baglanti.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else if ((int)e.KeyChar == 32) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((int)e.KeyChar >= 65 && (int)e.KeyChar <= 90) || ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)) e.Handled = false;
            else if ((int)e.KeyChar == 8) e.Handled = false;
            else e.Handled = true;
        }

        

    }
}
