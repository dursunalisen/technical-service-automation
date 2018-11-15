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
    public partial class FormAnaSayfa : Form
    {
        public FormAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnMüşteriler_Click(object sender, EventArgs e)
        {
            FormMüşteriler frm3 = new FormMüşteriler();
            frm3.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnArızaGiriş_Click(object sender, EventArgs e)
        {
            FormArızaGiriş frm4 = new FormArızaGiriş();
            frm4.Show();
            this.Hide();
        }

        private void btnArızaÇıkış_Click(object sender, EventArgs e)
        {
            FormArızaÇıkış frm5 = new FormArızaÇıkış();
            frm5.Show();
            this.Hide();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            FormPersonel frm6 = new FormPersonel();
            frm6.Show();
            this.Hide();
        }
    }
}
