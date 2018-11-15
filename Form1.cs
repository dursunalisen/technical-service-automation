using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string kullanıcıadı, sifre;
            kullanıcıadı = textBox1.Text;
            sifre = textBox2.Text;
            if (kullanıcıadı=="admin" && sifre=="123456")
            {
                FormAnaSayfa  frm2 = new FormAnaSayfa();
                 
                frm2.Show();
                this.Hide();
              
            }
            
            else if (kullanıcıadı=="" || sifre=="")
	    {
        MessageBox.Show("Kaçak Giriş Yok..");
	  }
            else
            {
                MessageBox.Show("Kullanıcıadı veya şifre yanlış....");
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

       

       

      
    }
}
