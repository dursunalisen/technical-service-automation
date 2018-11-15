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
    public partial class FormPersonel : Form
    {
       
        SqlConnection condatabase = new SqlConnection("data source=DURSUN-DURSUN\\SQLEXPRESS;initial catalog=TeknikServisOtamasyon;Integrated security=true ");

        SqlCommand cmddatabase = new SqlCommand(); 
        DataTable dbdataset = new DataTable();
        public FormPersonel()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormAnaSayfa frm2 = new FormAnaSayfa();
            frm2.Show();
            this.Hide();
        }

        private void FormPersonel_Load(object sender, EventArgs e)
        {
           
            SqlCommand cmddatabase = new SqlCommand("Select * from Personel ", condatabase);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmddatabase;
         
            /*sda.Fill(dbdataset);
            dataGridView1.DataSource = dbdataset;*/
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            condatabase.Open();
           
            if (radioButton1.Checked == true)
            {
                SqlCommand ekle = new SqlCommand("insert into Personel (PersonelNo, Ad, Soyad, TelNo,Cinsiyet) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + radioButton1.Text + "')", condatabase);
                ekle.ExecuteNonQuery();
            }
            else if (radioButton2.Checked == true)
            {
                SqlCommand ekle = new SqlCommand("insert into Personel (PersonelNo, Ad, Soyad, TelNo,Cinsiyet) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + radioButton2.Text + "')", condatabase);
                ekle.ExecuteNonQuery();
            }
         
            condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from Personel ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
           textBox1.Clear();
           textBox2.Clear();
           textBox3.Clear();
           textBox4.Clear();
           
            
        }

     

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            condatabase.Open();
            string personelno = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand sil = new SqlCommand("delete from Personel where PersonelNo='"+personelno+"'",condatabase);
            sil.ExecuteNonQuery();
           
                  condatabase.Close();
                  DataSet liste = new DataSet();
                  SqlDataAdapter tut = new SqlDataAdapter("Select * from Personel ", condatabase);

                  tut.Fill(liste, "tablo1");
                  dataGridView1.DataSource = liste.Tables["tablo1"];
          
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
         
      condatabase.Open();   
      


            SqlCommand guncelle = new SqlCommand("update Personel set Ad = '"+textBox2.Text+"', Soyad = '"+textBox3.Text+"', TelNo = '"+textBox4.Text+"' where PersonelNo = '"+secilensatır+"'",condatabase);
            guncelle.ExecuteNonQuery();

            condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from Personel ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
            

        }

       

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellConnectClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           


        }

        

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {

        }
        int secilensatır;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            secilensatır = Convert.ToInt32(dbdataset.Rows[e.RowIndex]["PersonelNo"]);


            textBox1.Text = secilensatır.ToString();
            textBox2.Text = dbdataset.Rows[e.RowIndex]["Ad"].ToString();
            textBox3.Text = dbdataset.Rows[e.RowIndex]["Soyad"].ToString();
            textBox4.Text = dbdataset.Rows[e.RowIndex]["TelNo"].ToString();
           
        }

  
      

       

      
        }
    }

