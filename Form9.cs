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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");
        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Visible = true; //Daha fazla bilgi için : www.gorselprogramlama.com

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            int StartCol = 1;

            int StartRow = 1; //Daha fazla bilgi için : www.gorselprogramlama.com

            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {

                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];

                myRange.Value2 = dataGridView1.Columns[j].HeaderText;

            }

            StartRow++;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                { //Daha fazla bilgi için : www.gorselprogramlama.com

                    try
                    {

                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];

                        myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;

                    }

                    catch
                    {

                        ;

                    }

                } //Daha fazla bilgi için : www.gorselprogramlama.com

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 formkapa = new Form9();
            formkapa.Close();
            Form6 form = new Form6();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select yurt.yurtadi, (Oaded*odakapasitesi) as kapasite from yurt inner join mudur on yurt.yurtID=mudur.yurtID WHERE mudurID Like'" +mudurID + "' ", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
                DataSet ds = new DataSet();
                ds.Clear();
                komutt.Fill(ds);
                string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
                baglanti.Close();

                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select * from ogrenci WHERE fakulte LIKE'" + textBox1.Text.ToString() + "'  AND mudurID Like '" +Int32.Parse(mudurID) + "'", baglanti);
                yenial.Fill(tablo, "ogrenci");
                dataGridView1.DataSource = tablo.Tables["ogrenci"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("fakülte ismi giriniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select * from ogrenci WHERE bolum LIKE'" + textBox2.Text.ToString() + "'  AND mudurID Like '" + Int32.Parse(mudurID) + "'", baglanti);
            yenial.Fill(tablo, "ogrenci");
            dataGridView1.DataSource = tablo.Tables["ogrenci"];
            baglanti.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select * from ogrenci WHERE sinif LIKE'" + comboBox4.Text.ToString() + "'  AND mudurID Like '" + Int32.Parse(mudurID) + "'", baglanti);
            yenial.Fill(tablo, "ogrenci");
            dataGridView1.DataSource = tablo.Tables["ogrenci"];
            baglanti.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select personel.ad,personel.bolum from personel inner join mudur on personel.yurtID=mudur.yurtID where mudurID Like '" + Int32.Parse(mudurID) + "'", baglanti);
            yenial.Fill(tablo, "personel");
            dataGridView1.DataSource = tablo.Tables["personel"];
            baglanti.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            OleDbCommand veri = new OleDbCommand("SELECT odano FROM ogrenci", baglanti);
            OleDbDataReader oku;
            baglanti.Open();
            oku = veri.ExecuteReader();

            while (oku.Read())
            {
                comboBox1.Items.Add(oku["odano"].ToString());
            }
            oku.Close();
            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select odatip,kat1 as Kat ,masa,dolap,yatak,sandalye from ogrenci where mudurID Like '" + Int32.Parse(mudurID) + "'", baglanti);
            yenial.Fill(tablo, "ogrenci");
            dataGridView1.DataSource = tablo.Tables["ogrenci"];
            baglanti.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komutt = new OleDbDataAdapter("Select mudurID from ss ", baglanti);
            DataSet ds = new DataSet();
            ds.Clear();
            komutt.Fill(ds);
            string mudurID = ds.Tables[0].Rows[0]["mudurID"].ToString();
            baglanti.Close();

            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select ogrenciID,isim,soyisim from ogrenci where mudurID Like '" + Int32.Parse(mudurID) + "'", baglanti);
            yenial.Fill(tablo, "ogrenci");
            dataGridView1.DataSource = tablo.Tables["ogrenci"];
            baglanti.Close();
        }
    }
}