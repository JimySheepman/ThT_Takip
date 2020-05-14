using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakipSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataAdapter da;
        void KisiEkle()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=THT.accdb;Persist Security Info=False;");
            baglanti.Open();
            da = new OleDbDataAdapter("SELECT *FROM THT_Takip", baglanti);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglanti.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox2.Enabled = true;
                groupBox2.Visible = true;

            }
            else
            {
                groupBox2.Enabled = false;
                groupBox2.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                groupBox3.Enabled = true;
                groupBox3.Visible = true;

            }
            else
            {
                groupBox3.Enabled = false;
                groupBox3.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                groupBox4.Enabled = true;
                groupBox4.Visible = true;

            }
            else
            {
                groupBox4.Enabled = false;
                groupBox4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "INSERT INTO THT_Takip(yonetici_isim) values(@isim)";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@isim", textBox1.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KisiEkle();
            MessageBox.Show("Kişi Başarılı Bir Şekilde Eklendi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KisiEkle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM THT_Takip WHERE id=@id ";
            komut = new OleDbCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            KisiEkle();
            MessageBox.Show("Kişi Başarılı Bir Şekilde Silindi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
                string sorgu = "UPDATE THT_Takip Set toplam_deger=@toplam+toplam_deger WHERE id=@id";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@toplam", textBox3.Text);
                komut.Parameters.AddWithValue("@id", Convert.ToString(textBox2.Text));
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                KisiEkle();
                textBox2.Clear();
                textBox3.Clear();
        }
    }
}
