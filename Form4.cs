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
    public partial class FormArızaGiriş : Form
    {
        SqlConnection condatabase = new SqlConnection("data source=DURSUN-DURSUN\\SQLEXPRESS;initial catalog=TeknikServisOtamasyon;Integrated security=true ");
        DataTable dbdataset = new DataTable();
        public FormArızaGiriş()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormAnaSayfa frm2 = new FormAnaSayfa();
            frm2.Show();
            this.Hide();
        }
    
         /* SqlCommand cmddatabase = new SqlCommand("Select * from Personel ", condatabase);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmddatabase;*/
        private void FormArızaGiriş_Load(object sender, EventArgs e)
        {
            
               SqlCommand cmddatabase = new SqlCommand("Select * from ArızaGir ;", condatabase);

               SqlDataAdapter sda = new SqlDataAdapter();
               sda.SelectCommand = cmddatabase;
               sda.Fill(dbdataset);
               BindingSource bsource = new BindingSource();
               bsource.DataSource = dbdataset;
               dataGridView1.DataSource = bsource;
               sda.Update(dbdataset);
            

            condatabase.Open();
            SqlCommand cek = new SqlCommand("select * from Müsteriler", condatabase);
            SqlDataReader oku = cek.ExecuteReader();
            while (oku.Read())
            {
                comboBox4.ValueMember = oku["Müsterino"].ToString();
                string adsoyad = oku["Ad"].ToString() + " " + oku["Soyad"].ToString();
                comboBox4.Items.Add(adsoyad);
            }
            condatabase.Close();



        }

          private void btnKaydet_Click(object sender, EventArgs e)
          {
              condatabase.Open();
              SqlCommand  kaydet= new SqlCommand("insert into ArızaGir (ArızaNo,MüsteriNo,Sorun,Girtarih,BilgisayarTürü,Marka,Parça) values('" + textBox1.Text + "', '" + comboBox4.ValueMember + "', '" + textBox3.Text + "', '" + textBox4.Text + "','"+comboBox1.Text+"','"+comboBox2.Text+"','"+comboBox3.Text+"')", condatabase);
              kaydet.ExecuteNonQuery();
             
              SqlCommand cmddatabase = new SqlCommand("Select * from ArızaGir ", condatabase);
              SqlDataAdapter sda = new SqlDataAdapter();
              sda.SelectCommand = cmddatabase;
              DataTable dbdataset = new DataTable();
              sda.Fill(dbdataset);
              BindingSource bsource = new BindingSource();
              bsource.DataSource = dbdataset;
              dataGridView1.DataSource = bsource;
              sda.Update(dbdataset);
              condatabase.Close();
              textBox1.Clear();             
              textBox3.Clear();
              textBox4.Clear();
          }

          private void btnSil_Click(object sender, EventArgs e)
          {
              condatabase.Open();
              string ArızaNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
              SqlCommand sil = new SqlCommand("delete from ArızaGir where ArızaNo='" + ArızaNo + "'", condatabase);
              sil.ExecuteNonQuery();  
            condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from ArızaGir ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
          
          }
    private void btnGüncelle_Click(object sender, EventArgs e)
        {
                   
      condatabase.Open();



      SqlCommand guncelle = new SqlCommand("update ArızaGir set  Müsterino= '" + comboBox4.Text+ "', Girtarih = '" + textBox4.Text + "', BilgisayarTürü = '" + comboBox1.Text + "',Marka ='" + comboBox2.Text + "',Parça='"+comboBox3.Text+"',Sorun= '" + textBox3.Text + "' where ArızaNo = '" + secilensatır + "'", condatabase);
            guncelle.ExecuteNonQuery();

            condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from ArızaGir ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];

     
    }
          private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
          {
              if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) 
              {
                  e.Handled = true;
              }
          }

          private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
          {
              if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
              {
                  e.Handled = true;
              }
          }

          private void textBox2_TextChanged(object sender, EventArgs e)
          {
             



          }

          private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
          {
              textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
              comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
              textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
              textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
              comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
              comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
              comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
          }
          int secilensatır;

          private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
          {
              secilensatır = Convert.ToInt32(dbdataset.Rows[e.RowIndex]["ArızaNo"]);


              textBox1.Text = secilensatır.ToString();
              comboBox1.Text = dbdataset.Rows[e.RowIndex]["BilgisayarTürü"].ToString();
              comboBox2.Text = dbdataset.Rows[e.RowIndex]["Marka"].ToString();
              comboBox3.Text= dbdataset.Rows[e.RowIndex]["Parça"].ToString();
              comboBox4.Text = dbdataset.Rows[e.RowIndex]["Müsterino"].ToString();
              textBox3.Text = dbdataset.Rows[e.RowIndex]["Sorun"].ToString();
              textBox4.Text = dbdataset.Rows[e.RowIndex]["Girtarih"].ToString();
          }

      
             
         
         

         

          
    }
}
