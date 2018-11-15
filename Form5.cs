using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class FormArızaÇıkış : Form
    {
        SqlConnection condatabase = new SqlConnection("data source=DURSUN-DURSUN\\SQLEXPRESS;initial catalog=TeknikServisOtamasyon;Integrated security=true ");
        //SqlCommand cmddatabase = new SqlCommand();
        DataTable dbdataset = new DataTable();
        public FormArızaÇıkış()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormAnaSayfa frm2 = new FormAnaSayfa();
            frm2.Show();
            this.Hide();
        }

        private void FormArızaÇıkış_Load(object sender, EventArgs e)
        {
            
           
           condatabase.Open();
            SqlCommand cek = new SqlCommand("select * from Personel", condatabase);
            SqlDataReader oku = cek.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.ValueMember = oku["PersonelNo"].ToString();
                string adsoyad = oku["Ad"].ToString() + " " + oku["Soyad"].ToString();
                comboBox1.Items.Add(adsoyad);
            }
           
            SqlCommand getir = new SqlCommand("select * from ArızaGir", condatabase);
            SqlDataReader göster = getir.ExecuteReader();
            while (göster.Read())
            {
                comboBox2.ValueMember = göster["Arızano"].ToString();
                string arızano = göster["Arızano"].ToString();
                comboBox2.Items.Add(arızano);
            }
           condatabase.Close();
          
           
            SqlCommand cmddatabase = new SqlCommand("Select * from ArızaCık ;", condatabase);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmddatabase;         
           // sda.Fill(dbdataset);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbdataset;
            dataGridView1.DataSource = bsource;
            sda.Update(dbdataset);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            condatabase.Open();
            SqlCommand ekle = new SqlCommand("insert into ArızaCık (Yapılanİşlem,Arızano,CıkTarih,PersonelNo,İşlemÜcreti) values('" + textBox1.Text + "', '" + comboBox2.ValueMember + "', '" + textBox3.Text + "', '" + comboBox1.ValueMember + "','"+textBox5.Text+"')", condatabase);
            ekle.ExecuteNonQuery();
            condatabase.Close();
      
             DataSet liste = new DataSet();
             SqlDataAdapter tut = new SqlDataAdapter("Select * from ArızaCık ", condatabase);

             tut.Fill(liste, "tablo1");
             dataGridView1.DataSource = liste.Tables["tablo1"];
            
            textBox1.Clear();
            
            textBox3.Clear();
            
            textBox5.Clear();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            condatabase.Open();
            string ArızaNo= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SqlCommand sil = new SqlCommand("delete from ArızaCık where Arızano='" + ArızaNo + "'", condatabase);
            sil.ExecuteNonQuery();
  condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from ArızaCık ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
          
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&& e.KeyChar !=8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           //comboBox2.Text=dataGridView1.Rows.[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            condatabase.Open();
            SqlCommand guncelle = new SqlCommand("update ArızaCık set Yapılanİşlem = '" + textBox1.Text + "', CıkTarih = '" + textBox3.Text + "', PersonelNo = '" + comboBox1.Text + "' ,İşlemÜcreti='"+textBox5.Text+"'where Arızano = '" + secilensatır + "'", condatabase);
            guncelle.ExecuteNonQuery();

            condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from ArızaCık ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
        }
        int secilensatır;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            secilensatır = Convert.ToInt32(dbdataset.Rows[e.RowIndex]["Arızano"]);


            comboBox2.Text = secilensatır.ToString();
            textBox1.Text = dbdataset.Rows[e.RowIndex]["Yapılanİşlem"].ToString();
            textBox3.Text = dbdataset.Rows[e.RowIndex]["CıkTarih"].ToString();
            comboBox1.Text = dbdataset.Rows[e.RowIndex]["PersonelNo"].ToString();
            textBox5.Text = dbdataset.Rows[e.RowIndex]["İşlemÜcreti"].ToString();
           
        }

        

       

        }
    }

