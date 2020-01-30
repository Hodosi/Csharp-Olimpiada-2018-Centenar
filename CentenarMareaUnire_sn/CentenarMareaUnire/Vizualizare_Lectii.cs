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
    public partial class Vizualizare_Lectii : Form
    {
        public Vizualizare_Lectii()
        {
            InitializeComponent();
        }

        LECTII lectii = new LECTII();
        private void Vizualizare_Lectii_Load(object sender, EventArgs e)
        {
            this.listBox1.DataSource = lectii.getLectii();
            this.listBox1.DisplayMember = "NumeImagine";
            this.listBox1.ValueMember = "NumeImagine";

            upImg();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            upImg();
        }

        public void upImg()
        {
            int idImg = Convert.ToInt32(this.listBox1.SelectedIndex.ToString());
            idImg++;
            string nmImg = "lectia" + idImg.ToString() + ".bmp";
            string fn = Application.StartupPath + @"\Resurse_C#\ContinutLectii\" + nmImg;
            this.pictureBox1.Image = Image.FromFile(fn);

            DataTable table = lectii.getUserData(nmImg);

            string info="";
            for(int i = 0; i < 4; i++)
            {
                //info = info
            }
        }

        public void upUserData()
        {

        }
    }
}
