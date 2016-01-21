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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");
        
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sifre = "abcd";
                Int64 tc = 11111111111;
                if (string.Equals(textBox1.Text, tc.ToString()))
                {
                    if (string.Equals(textBox2.Text, sifre.ToString()))
                    {
                        Form1 formkapa = new Form1();
                        formkapa.Close();
                        Form2 form = new Form2();
                        form.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand ver = new OleDbCommand("delete * from ss ", baglanti);
            ver.ExecuteNonQuery();
            baglanti.Close();
            
            
            int k = 0;
            baglanti.Open(); // veritabanımızı açıyoruz işlem yapabılmek için 
            OleDbCommand komut = new OleDbCommand("Select * From mudur where kullaniciad='" + textBox3.Text.ToString() + "'", baglanti);// verıtabanında textbox gırılen kullanıcı adına gore tarama yapıyoruzz
            OleDbDataReader okuyucu = komut.ExecuteReader();// ve reader komutunu kullanarak gelen veriyi rdr adlı degıskenımıze atıyoruz
            while (okuyucu.Read()) // burda gelen veriyi okutmak amaçlı döngü kuruyoruz
            {
                if (textBox3.Text.ToString() == okuyucu["kullaniciad"].ToString())// Veritabanından gelen kullanıcı adı ıle textbox aynımı dıe kontrol edıyoruz dogruysa alttakı şartımıza geçiyor
                {
                    if (textBox4.Text.ToString() == okuyucu["kullanicisifre"].ToString())// kullanıcı sıfresıylede textbox2 de degerler eger aynı ise bu sefer altta yazan komutlarımız çalışıyor
                    {
                        k++;
                        baglanti.Close();
                        break;

                    }
                    else if (textBox4.Text.ToString() != okuyucu["kullanicisifre"].ToString() && textBox4.Text.ToString() == "")
                    // şifre eger yanlıs gırılmısse hata verdırıyoruz
                    {
                        MessageBox.Show("Bu kullanıcı adı şifresi yanlıstır");
                    }

                }


            }
            

            baglanti.Close();

            if (k == 1) {

                baglanti.Open();
                OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from mudur where kullaniciad Like '" + textBox3.Text.ToString() + "' and kullanicisifre Like '" + textBox4.Text.ToString() + "'", baglanti);
                DataSet ds = new DataSet();
                ds.Clear();
                komutt.Fill(ds);
                string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
                baglanti.Close();
                //string bosluk =" ";

                baglanti.Open();
                OleDbCommand o = new OleDbCommand("insert into ss(mudurID) values ('"+Int32.Parse(mudurID)+"')",baglanti);
                o.ExecuteNonQuery();
                baglanti.Close();

                Form6 yeniform = new Form6();// yeniform degıskenıne patron form atıyoruz 
                yeniform.Show();// daha sonra patron form gösterıyoruz 
                this.Hide();
            
            }
            
         
        }
    }
}