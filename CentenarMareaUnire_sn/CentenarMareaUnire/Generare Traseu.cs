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
    public partial class Generare_Traseu : Form
    {
        public Generare_Traseu()
        {
            InitializeComponent();
        }
        List<string> capitale = new List<string>();
        Point[] pointCapitale = new Point[100];
        List<string> regiune = new List<string>();
        int[] pozitiiValide = new int[10];
        Label[] labels;
        int x1t, x2t, y1t, y2t, xstart, ystart;
        int linii;
        private void Generare_Traseu_Load(object sender, EventArgs e)
        {
            linii = 0;
            for (int i = 0; i < 10; i++)
            {
                pozitiiValide[i] = 1;
            }
            labels = new Label[] { this.label1, this.label2, this.label3, this.label4, this.label5, this.label6, this.label7, this.label8, this.label9, this.label10 };
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
            Pen pen1 = new Pen(Color.Black, 3);
            string[] coordonate = new string[3];
            char split = '*';
            string sir;
            //----------------------------------------------------------
            sir = sr.ReadLine();
            coordonate = sir.Split(split);
            points[i].X = inix = x1 = Convert.ToInt32(coordonate[0]);
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
               // MessageBox.Show(reg);
                lungime = fn.Length;
                //-----------------------------
                sir = sr.ReadLine();
                coordonate = sir.Split(split);
                if (coordonate.Length == 3)
                {

                    regiune.Add(reg);
                    capitale.Add(coordonate[2]);
                    this.listBox1.Items.Add(coordonate[2]);
                    pointCapitale[pozcap].X = Convert.ToInt32(coordonate[0]);
                    pointCapitale[pozcap++].Y = Convert.ToInt32(coordonate[1]);
                    graphics.DrawEllipse(pen1, Convert.ToInt32(coordonate[0]), Convert.ToInt32(coordonate[1]), 3, 3);
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

        public void adaugacapitale()
        {
            for (int i = 0; i < 10; i++)
            {
                labels[i].Location = new Point(pointCapitale[i].X + 10, pointCapitale[i].Y);
                labels[i].Visible = true;
                labels[i].Text = capitale[i];
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            int poz;
            this.listBox1.Enabled = false;
            adaugacapitale();
            xstart=x1t = pointCapitale[this.listBox1.SelectedIndex].X;
            ystart=y1t = pointCapitale[this.listBox1.SelectedIndex].Y;
            poz = this.listBox1.SelectedIndex;
            pozitiiValide[poz] = 0;
            timer1.Enabled = true;

        }

        public void desenareTraseu()
        {
            Graphics graphics = this.panel1.CreateGraphics();
            Pen penAnime = new Pen(Color.Red, 5);
            int distantamin, distanta;
            distantamin = 0;
            int x2, y2,poz=0;
            for (int i = 0; i < 10; i++)
            {
                if (pozitiiValide[i] == 1)
                {
                    x2t = pointCapitale[i].X;
                    y2t = pointCapitale[i].Y;
                    distantamin = (x2t - x1t) * (x2t - x1t) + (y2t - y1t) * (y2t - y1t);
                    break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (pozitiiValide[i] == 1)
                {
                    x2 = pointCapitale[i].X;
                    y2 = pointCapitale[i].Y;
                    distanta = (x2 - x1t) * (x2 - x1t) + (y2 - y1t) * (y2 - y1t);
                    if (distanta < distantamin)
                    {
                        poz = i;
                        x2t = x2;
                        y2t = y2;
                        distantamin = distanta;
                    }

                }
            }
            pozitiiValide[poz] = 0;
            graphics.DrawLine(penAnime, x1t, y1t, x2t, y2t);
            x1t = x2t;
            y1t = y2t;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (linii == 12)
            {
                Graphics graphics = this.panel1.CreateGraphics();
                Pen penAnime = new Pen(Color.Red, 5);
                graphics.DrawLine(penAnime, x1t, y1t, xstart, ystart);
                desenareTraseu();
                timer1.Enabled = false;
                MessageBox.Show("I finished");
            }
            else
            {
                linii++;
                desenareTraseu();
            }
        }
    }
}
