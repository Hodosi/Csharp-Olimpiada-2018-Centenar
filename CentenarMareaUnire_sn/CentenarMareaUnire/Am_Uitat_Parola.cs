using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CentenarMareaUnire
{
    public partial class Am_Uitat_Parola : Form
    {
        public Am_Uitat_Parola()
        {
            InitializeComponent();
        }
        UTILIZATORI util = new UTILIZATORI();
        Random rand = new Random();
        PictureBox[] boxes = new PictureBox[6];
        string[] boxesValues = new string[6];
        int[] selectedBox = new int[6];
        private void Am_Uitat_Parola_Load(object sender, EventArgs e)
        {
            selectedBox = new int[] { 0, 0, 0, 0, 0, 0 };
            boxes = new PictureBox[] { this.pictureBox1, this.pictureBox2, this.pictureBox3, this.pictureBox4, this.pictureBox5, this.pictureBox6 };
            string fn = "";
            int r;
            string picName = "";
            for (int i = 0; i < 6; i++)
            {
                fn = Application.StartupPath + @"\Resurse_C#\Captcha\";
                r = rand.Next(1, 20);
                picName = r.ToString() + ".jpg";
                boxesValues[i] = picName;
                fn = fn + picName;
                boxes[i].Image = Image.FromFile(fn);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (selectedBox[0] == 0)
            {
                selectedBox[0] = 1;
                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, this.pictureBox1.Location.Y - 15);
            }
            else
            {
                this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, this.pictureBox1.Location.Y + 15);
                selectedBox[0] = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (selectedBox[1] == 0)
            {
                selectedBox[1] = 1;
                this.pictureBox2.Location = new Point(this.pictureBox2.Location.X, this.pictureBox2.Location.Y - 15);
            }
            else
            {
                this.pictureBox2.Location = new Point(this.pictureBox2.Location.X, this.pictureBox2.Location.Y + 15);
                selectedBox[1] = 0;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (selectedBox[2] == 0)
            {
                selectedBox[2] = 1;
                this.pictureBox3.Location = new Point(this.pictureBox3.Location.X, this.pictureBox3.Location.Y - 15);
            }
            else
            {
                this.pictureBox3.Location = new Point(this.pictureBox3.Location.X, this.pictureBox3.Location.Y + 15);
                selectedBox[2] = 0;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (selectedBox[3] == 0)
            {
                selectedBox[3] = 1;
                this.pictureBox4.Location = new Point(this.pictureBox4.Location.X, this.pictureBox4.Location.Y - 15);
            }
            else
            {
                this.pictureBox4.Location = new Point(this.pictureBox4.Location.X, this.pictureBox4.Location.Y + 15);
                selectedBox[3] = 0;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (selectedBox[4] == 0)
            {
                selectedBox[4] = 1;
                this.pictureBox5.Location = new Point(this.pictureBox5.Location.X, this.pictureBox5.Location.Y - 15);
            }
            else
            {
                this.pictureBox5.Location = new Point(this.pictureBox5.Location.X, this.pictureBox5.Location.Y + 15);
                selectedBox[4] = 0;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (selectedBox[5] == 0)
            {
                selectedBox[5] = 1;
                this.pictureBox6.Location = new Point(this.pictureBox6.Location.X, this.pictureBox6.Location.Y - 15);
            }
            else
            {
                this.pictureBox6.Location = new Point(this.pictureBox6.Location.X, this.pictureBox6.Location.Y + 15);
                selectedBox[5] = 0;
            }
        }

        private void button_verifica_Click(object sender, EventArgs e)
        {
            if (verific())
            {
                MessageBox.Show("Raspuns Corect");
                this.groupBox1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Raspuns Gresit");
            }
        }

        public bool verific()
        {
            string img,om;
            string fn = Application.StartupPath + @"\Resurse_C#\oameni.txt";
            StreamReader sr;
            for (int i = 0; i < 6; i++)
            {
                sr = new StreamReader(fn);
                img = boxesValues[i];
                while ((om = sr.ReadLine()) != null)
                {
                    if (om == img)
                    {
                        if(selectedBox[i] == 0)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if(om == null && selectedBox[i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (this.textBox_parola.Text == this.textBox_parola_confirm.Text)
            {
                string email = this.textBox_email.Text;
                string pass = this.textBox_parola.Text;
                if (util.changePass(email, pass))
                {
                    MessageBox.Show("Parole schimbata");
                }
                else
                {
                    MessageBox.Show("Parole nu s-a putut schimba");
                }

            }
            else
            {
                MessageBox.Show("Parole diferite");
            }
        }

        private void button_anulare_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logare f = new Logare();
            f.ShowDialog();
        }
    }
}
