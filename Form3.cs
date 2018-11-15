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
    public partial class FormMüşteriler : Form
    {
        SqlConnection condatabase = new SqlConnection("data source=DURSUN-DURSUN\\SQLEXPRESS;initial catalog=TeknikServisOtamasyon;Integrated security=true ");
        //SqlCommand cmddatabase = new SqlCommand();
        DataTable dbdataset = new DataTable();

        public FormMüşteriler()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  
           

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FormAnaSayfa frm2 = new FormAnaSayfa();
            frm2.Show();
            this.Hide();
        }
       
        private void Form3_Load(object sender, EventArgs e)
        { 
            
            
            SqlCommand cmddatabase = new SqlCommand("Select * from Müsteriler ", condatabase);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmddatabase;
           
            sda.Fill(dbdataset);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = dbdataset;
            dataGridView1.DataSource = bsource;
            sda.Update(dbdataset);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            condatabase.Open();
            
                
            
            if (radioButton1.Checked==true)
            {
                SqlCommand ekle = new SqlCommand("insert into Müsteriler (MüsteriNo, Ad, Soyad,EvTel,CepTel,Cinsiyet,Adres) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox6.Text + "','"+radioButton1.Text+"' ,'"+textBox5.Text+"')", condatabase);
            ekle.ExecuteNonQuery();
            }
            else if (radioButton2.Checked==true)
            {
  SqlCommand ekle = new SqlCommand("insert into Müsteriler (MüsteriNo, Ad, Soyad,EvTel,CepTel,Cinsiyet,Adres) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox6.Text + "','"+radioButton2.Text+"','"+textBox5.Text+"' )", condatabase);
            ekle.ExecuteNonQuery();
            }
          
            SqlCommand cmddatabase = new SqlCommand("Select * from Müsteriler ", condatabase);
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
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            condatabase.Open();
            string müsterino = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand sil = new SqlCommand("delete from Müsteriler  where Müsterino='" + müsterino + "'", condatabase);
            sil.ExecuteNonQuery();
            condatabase.Close();
          
           
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from Müsteriler ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
            
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
   
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            condatabase.Open();



            SqlCommand guncelle = new SqlCommand("update Müsteriler set Ad = '" + textBox2.Text + "', Soyad = '" + textBox3.Text + "', EvTel = '" + textBox4.Text + "',CepTel = '" + textBox6.Text + "',Adres ='"+textBox5.Text+ "' where Müsterino = '" + secilensatır + "'", condatabase);
            guncelle.ExecuteNonQuery();

            condatabase.Close();
            DataSet liste = new DataSet();
            SqlDataAdapter tut = new SqlDataAdapter("Select * from Müsteriler ", condatabase);

            tut.Fill(liste, "tablo1");
            dataGridView1.DataSource = liste.Tables["tablo1"];
            

        }
        int secilensatır;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            secilensatır = Convert.ToInt32(dbdataset.Rows[e.RowIndex]["Müsterino"]);


            textBox1.Text = secilensatır.ToString();
            textBox2.Text = dbdataset.Rows[e.RowIndex]["Ad"].ToString();
            textBox3.Text = dbdataset.Rows[e.RowIndex]["Soyad"].ToString();
            textBox4.Text = dbdataset.Rows[e.RowIndex]["EvTel"].ToString();
            textBox6.Text = dbdataset.Rows[e.RowIndex]["CepTel"].ToString();
            textBox5.Text = dbdataset.Rows[e.RowIndex]["Adres"].ToString();
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       

    

       
     
        
       
       
    }
}   
