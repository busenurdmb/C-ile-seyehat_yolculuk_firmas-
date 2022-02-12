using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sefer_Yolculuk_Firması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-493DFJA\SQLEXPRESS;Initial Catalog=TestYolcuBilet;Integrated Security=True");

        void seferliste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLSEFERBILGI", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        
       private void Form1_Load(object sender, EventArgs e)
        {
            seferliste();
            
        }
        
        public string tc;
        bool durum;
        void MUKERREKAYIT ()
        {
            con.Open();
            SqlCommand komut = new SqlCommand("select * from TblYolcuBilgi where TC=@p4", con);
            komut.Parameters.AddWithValue("@p4", maskedTextBoxYOLCUTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;

            }
            else
            {
                durum = true;
            }
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MUKERREKAYIT();
             if(durum == false )
            {
                MessageBox.Show("bu tc kayıtlı");
            }
           else
            {


                con.Open();
                    SqlCommand kmt1 = new SqlCommand("insert into TblYolcuBilgi (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6)", con);
                    kmt1.Parameters.AddWithValue("@p1", textBoxYOLCUAD.Text);
                    kmt1.Parameters.AddWithValue("@p2", textBoxYOLCUSOYAD.Text);
                    kmt1.Parameters.AddWithValue("@p3", maskedTextBoxYOLCUTEL.Text);
                    kmt1.Parameters.AddWithValue("@p4", maskedTextBoxYOLCUTC.Text);
                    kmt1.Parameters.AddWithValue("@p5", comboBox1YOLCUCİNSİYET.Text);
                    kmt1.Parameters.AddWithValue("@p6", textBoxYOLCUMAİL.Text);
                    kmt1.ExecuteNonQuery();
                con.Close();
                    
                    MessageBox.Show("YOLCU KAYDI YAPILDI", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
              
            }
                
            



            
            
                
            
            
            
        }

        private void btnKAPTAN_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLKAPTAN (KAPTANNO,ADSOYAD,TELEFON) values (@p1,@p2,@p3)", con);
            kmt.Parameters.AddWithValue("@p1", maskedTextBox1KAPTANNO.Text);
            kmt.Parameters.AddWithValue("@p2", textBoxKAPTANADSOYAD.Text);
            kmt.Parameters.AddWithValue("@p3", maskedTextBoxKAPTANTEL.Text);
            kmt.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("KAPTAN KAYDI YAPILDI", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand kmt = new SqlCommand("insert into TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FİYAT) values (@p2,@p3,@p4,@p5,@p6,@p7)", con);
            kmt.Parameters.AddWithValue("@p2", textBoxKALKIŞ.Text);
            kmt.Parameters.AddWithValue("@p3", textBoxVARIŞ.Text);
            kmt.Parameters.AddWithValue("@p4", maskedTextBoxTARİH.Text);
            kmt.Parameters.AddWithValue("@p5", maskedTextBoxSAAT.Text);
            kmt.Parameters.AddWithValue("@p6", maskedTextBoxKAPTAN.Text);
            kmt.Parameters.AddWithValue("@p7", textBoxFİYAT.Text);
            kmt.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("SEFER OLUŞTURULDU ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            seferliste();
        
    }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBoxREZEERVASYONSEFERNO.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }

     

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "3";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "7";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "9";
        }
        void MUKERREKAYIT2()
        {
            con.Open();
            SqlCommand komut = new SqlCommand("select * from TblYolcuBilgi where TC=@p4", con);
            komut.Parameters.AddWithValue("@p4", maskedTextBoxREZERVASYONTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;

            }
            else
            {
                durum = true;
            }
            con.Close();
        }
        private void buttonREZERVASYONYAP_Click(object sender, EventArgs e)
        {
            MUKERREKAYIT2();
            if (durum == false)
            {
                con.Open();
                SqlCommand kmt = new SqlCommand("insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values (@p1,@p2,@p3)", con);
                kmt.Parameters.AddWithValue("@p1", textBoxREZEERVASYONSEFERNO.Text);
                kmt.Parameters.AddWithValue("@p2", maskedTextBoxREZERVASYONTC.Text);
                kmt.Parameters.AddWithValue("@p3", textBoxKOLTUKNO.Text);
                kmt.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("REZERVASYON YAPILDI İYİ YOLCULUKLAR DİLERİZ ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("SİSTEMDE BÖYLE BİRİ YOK");
            }
         

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "1";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBoxKOLTUKNO.Text = "2";
        }
    }
}
