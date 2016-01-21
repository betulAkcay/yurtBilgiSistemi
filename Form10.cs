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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\ybs.accdb");



        private void button1_Click(object sender, EventArgs e)
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
            Form10 formkapa = new Form10();
            formkapa.Close();
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select COUNT(yurtID) as yurtsayisi from yurt", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select il,COUNT(*) AS yurtsayisi from yurt group by il", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select yurtadi,(Oaded*odakapasitesi)as kapasite,Oaded as [oda sayısı]  from yurt", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();

        }


        private void button7_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select universite,COUNT(*) AS [öğrenci sayısı] from ogrenci group by universite", baglanti);
            yenial.Fill(tablo, "ogrenci");
            dataGridView1.DataSource = tablo.Tables["ogrenci"];
            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select COUNT(mudurID) as [müdür sayisi] from mudur", baglanti);
            yenial.Fill(tablo, "mudur");
            dataGridView1.DataSource = tablo.Tables["mudur"];
            baglanti.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select bolum,COUNT(*) AS [personel sayısı] from personel group by bolum", baglanti);
            yenial.Fill(tablo, "personel");
            dataGridView1.DataSource = tablo.Tables["personel"];
            baglanti.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
             if (comboBox1.Text != "")
            {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select COUNT(yurtID) as yurtsayisi from yurt WHERE  il LIKE  '%" + comboBox1.Text + "%'", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();
            }
             else
             {
                 MessageBox.Show("lütfen şehir seçiniz");
             }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
            DataSet tablo = new DataSet();
            baglanti.Open();
            OleDbDataAdapter yenial = new OleDbDataAdapter("select yurtadi,(Oaded*odakapasitesi)as kapasite,Oaded as [oda sayısı] from yurt WHERE  il LIKE  '%" + comboBox1.Text + "%'", baglanti);
            yenial.Fill(tablo, "yurt");
            dataGridView1.DataSource = tablo.Tables["yurt"];
            baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen şehir seçiniz");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select universite,  COUNT(*) AS [öğrenci sayısı] from ogrenci,yurt  WHERE yurt.yurtID=ogrenci.ogrenciID AND il LIKE  '%" + comboBox1.Text + "%'  group by universite ", baglanti);
                yenial.Fill(tablo, "ogrenci");
                dataGridView1.DataSource = tablo.Tables["ogrenci"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen şehir seçiniz");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select bolum,COUNT(*) AS [personel sayısı] from personel,yurt WHERE personel.personelID=yurt.yurtID AND il LIKE  '%" + comboBox1.Text + "%' group by bolum", baglanti);
                yenial.Fill(tablo, "personel");
                dataGridView1.DataSource = tablo.Tables["personel"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen şehir seçiniz");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select COUNT(mudurID) as [müdür sayisi] from mudur,yurt  WHERE mudur.mudurID=yurt.yurtID AND il LIKE  '%" + comboBox1.Text + "%'   ", baglanti);
                yenial.Fill(tablo, "mudur");
                dataGridView1.DataSource = tablo.Tables["mudur"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen şehir seçiniz");
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {

            OleDbCommand veri = new OleDbCommand("SELECT yurtadi FROM yurt", baglanti);
            OleDbDataReader oku;
            baglanti.Open();
            oku = veri.ExecuteReader();

            while (oku.Read())
            {
                comboBox2.Items.Add(oku["yurtadi"].ToString());
            }
            oku.Close();
            baglanti.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select bolum,COUNT(*) AS [personel sayısı] from personel  WHERE  yurtadi LIKE  '%" + comboBox2.Text + "%'  group by bolum", baglanti);
                yenial.Fill(tablo, "personel");
                dataGridView1.DataSource = tablo.Tables["personel"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen yurt seçiniz");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
             if (comboBox2.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select yurtadi,(Oaded*odakapasitesi)as kapasite,Oaded as [oda sayısı] from yurt WHERE yurtadi LIKE  '%" + comboBox2.Text + "%'", baglanti);
                yenial.Fill(tablo, "yurt");
                dataGridView1.DataSource = tablo.Tables["yurt"];
                baglanti.Close();
            }
             else
             {
                 MessageBox.Show("lütfen yurt seçiniz");
             }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
            }
            else
            {
                MessageBox.Show("lütfen yurt seçiniz");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select fakulte,COUNT(*) as [ögrenci sayisi] from mudur,ogrenci  WHERE mudur.mudurID=ogrenci.mudurID AND yurtadi LIKE  '%" + comboBox2.Text + "%' group by fakulte  ", baglanti);
                yenial.Fill(tablo, "mudur");
                dataGridView1.DataSource = tablo.Tables["mudur"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen yurt seçiniz");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select bolum,COUNT(*) as [ögrenci sayisi] from mudur,ogrenci  WHERE mudur.mudurID=ogrenci.mudurID AND yurtadi LIKE  '%" + comboBox2.Text + "%' group by bolum  ", baglanti);
                yenial.Fill(tablo, "mudur");
                dataGridView1.DataSource = tablo.Tables["mudur"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen yurt seçiniz");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {

                DataSet tablo = new DataSet();
                baglanti.Open();
                OleDbDataAdapter yenial = new OleDbDataAdapter("select sinif,COUNT(*) as [ögrenci sayisi] from mudur,ogrenci  WHERE mudur.mudurID=ogrenci.mudurID AND yurtadi LIKE  '%" + comboBox2.Text + "%' group by sinif  ", baglanti);
                yenial.Fill(tablo, "mudur");
                dataGridView1.DataSource = tablo.Tables["mudur"];
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("lütfen yurt seçiniz");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

    }
}
