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
    public partial class Ghiceste_Regiunea : Form
    {
        public Ghiceste_Regiunea()
        {
            InitializeComponent();
        }

        List<string> capitale = new List<string>();
        Point[] pointCapitale = new Point[100];
        List<string> regiune = new List<string>();
        Random rand = new Random();
        TextBox[] textBoxes;
        int[] pozitiiValide = new int[10];
        int intrebari, punctajtotal;
        int poz;
        private void Ghiceste_Regiunea_Load(object sender, EventArgs e)
        {
            intrebari = 0;
            punctajtotal = 0;
            for (int i = 0; i < 10; i++)
            {
                pozitiiValide[i] = 1;
            }
            textBoxes = new TextBox[] { this.textBox1, this.textBox2, this.textBox3, this.textBox4, this.textBox5, this.textBox6, this.textBox7, this.textBox8, this.textBox9, this.textBox10 };
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            desenareRomania();
        }

        public void desenareRomania()
        {
            int i = 0;
            Point[] points = new Point[1000];
            int x1, x2, y1, y2, inix, iniy;
            string fn = Application.StartupPath + @"\Resurse_C#\Harti\RomaniaMare.txt";
            StreamReader sr = new StreamReader(fn);
            Graphics graphics = this.panel1.CreateGraphics();
            Pen pen = new Pen(Color.Green, 5);
            string[] coordonate = new string[3];
            char split = '*';
            string sir;
            //----------------------------------------------------------
            sir = sr.ReadLine();
            coordonate = sir.Split(split);
            points[i].X = inix = x1  = Convert.ToInt32(coordonate[0]);
            points[i++].Y = iniy = y1 = Convert.ToInt32(coordonate[1]);

            while ((sir = sr.ReadLine()) != null)
            {
                coordonate = sir.Split(split);
                points[i].X = x2 = Convert.ToInt32(coordonate[0]);
                points[i++].Y = y2 = Convert.ToInt32(coordonate[1]);
                graphics.DrawLine(pen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }

            graphics.DrawLine(pen, x1, y1, inix, iniy);

            //----------------color Romania-----------------------
            //SolidBrush brush = new SolidBrush(Color.Red);
            //graphics.FillClosedCurve(brush, points);
            //----------------Capitale----------------------------
            string reg;
            int pozcap = 0;
            //--------------------------------------------------------
            fn = Application.StartupPath + @"\Resurse_C#\Harti\";
            int lungime = fn.Length;
            var files = Directory.EnumerateFiles(fn).ToArray();
            MessageBox.Show(files.Length.ToString() + "-regiuni");
            for (int j = 0; j < files.Length; j++)
            {

                //MessageBox.Show(files[j]);
                sr = new StreamReader(files[j]);
                reg = files[j];
                reg = reg.Remove(0, lungime);
                lungime = reg.Length;
                reg = reg.Remove(lungime - 4);
                MessageBox.Show(reg);
                lungime = fn.Length;
                //-----------------------------
                sir = sr.ReadLine();
                coordonate = sir.Split(split);
                if (coordonate.Length == 3)
                {
                    regiune.Add(reg);
                    capitale.Add(coordonate[2]);
                    pointCapitale[pozcap].X = Convert.ToInt32(coordonate[0]);
                    pointCapitale[pozcap++].Y = Convert.ToInt32(coordonate[1]);
                    //-----------------------------------------------------
                    sir = sr.ReadLine();
                    coordonate = sir.Split(split);
                    x1 = Convert.ToInt32(coordonate[0]);
                    y1 = Convert.ToInt32(coordonate[1]);

                    while ((sir = sr.ReadLine()) != null)
                    {
                        coordonate = sir.Split(split);
                        x2 = Convert.ToInt32(coordonate[0]);
                        y2 = Convert.ToInt32(coordonate[1]);
                        graphics.DrawLine(pen, x1, y1, x2, y2);
                        x1 = x2;
                        y1 = y2;
                    }
                }
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Capitale: "+capitale.Count.ToString());
            //MessageBox.Show("Regiuni: "+regiune.Count.ToString());
            //MessageBox.Show("Pozitii Captale: "+pointCapitale.Length.ToString());
            intrebari = 0;
            altaintrebare();
        }

        public void altaintrebare()
        {
            poz = rand.Next(0, 10);
          //  MessageBox.Show(poz.ToString());
            while (!valid(poz))
            {
                poz = rand.Next(0, 10);
            //    MessageBox.Show(poz.ToString());
            }
            //MessageBox.Show(poz.ToString());
            pozitiiValide[poz] = 0;
            textBoxes[intrebari].Location = new Point(pointCapitale[poz].X, pointCapitale[poz].Y);
            textBoxes[intrebari].Visible = true;
        }

        public bool valid(int poz)
        {
            if (pozitiiValide[poz] == 1)
            {
                return true;
            }
            return false;
        }

        private void button_Diploma_Click(object sender, EventArgs e)
        {
            Diploma f = new Diploma();
            f.ShowDialog();
        }

        private void button_Verifica_Click(object sender, EventArgs e)
        {
            string rasp = textBoxes[intrebari].Text;
            if (rasp == regiune[poz])
            {
                punctajtotal++;
                MessageBox.Show("Corect");
                textBoxes[intrebari].Enabled = false;
            }
            else
            {
                MessageBox.Show(regiune[poz]);
            }

            if (intrebari == 9)
            {
                GLOBAL.punctajTotal = punctajtotal;
                MessageBox.Show("Felicitari ati obtinut "+ punctajtotal.ToString());
            }
            else
            {
                intrebari++;
                altaintrebare();
            }
        }
    }
}
