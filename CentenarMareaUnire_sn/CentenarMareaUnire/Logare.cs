using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CentenarMareaUnire
{
    public partial class Logare : Form
    {
        public Logare()
        {
            InitializeComponent();
        }

        UTILIZATORI util = new UTILIZATORI();
        private void button_Anulare_Click(object sender, EventArgs e)
        {
            this.Hide();
            Centenar_Start f = new Centenar_Start();
            f.ShowDialog();
        }

        private void button_logare_Click(object sender, EventArgs e)
        {
            string eamil = this.textBox_email.Text;
            string pass = this.textBox_parola.Text;

            if (util.existsUser(eamil, pass))
            {

                GLOBAL.UtilizatorCurent = util.getUser(eamil, pass);
                this.Hide();
                Centenar_Start f = new Centenar_Start();
                f.toolStripButton_Creare_Lectie.Enabled = true;
                f.toolStripButton_Generare_Traseu.Enabled = true;
                f.toolStripButton_Ghiceste_Regiunea.Enabled = true;
                f.ShowDialog();
                //this.Close();
            }
            else
            {
                this.textBox_email.Clear();
                this.textBox_parola.Clear();
                MessageBox.Show("Eroare Autentificare!");
            }
        }

        private void button_uitat_Click(object sender, EventArgs e)
        {
            string email = this.textBox_email.Text;
            if (util.existsEmail(email))
            {
                //this.Hide();
                Am_Uitat_Parola f = new Am_Uitat_Parola();
                f.textBox_email.Text = email;
                f.ShowDialog();
            }
            else
            {
                this.textBox_email.Clear();
                this.textBox_parola.Clear();
                MessageBox.Show("Emailul invalid!");
            }
        }
    }
}
