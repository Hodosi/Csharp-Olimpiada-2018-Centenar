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
    public partial class Diploma : Form
    {
        public Diploma()
        {
            InitializeComponent();
        }

        private void Diploma_Load(object sender, EventArgs e)
        {
            string sms = "Se acorda elevului " + GLOBAL.UtilizatorCurent;
            string premiu = "";
            if (GLOBAL.punctajTotal == 10)
            {
                premiu = "Premiul 1";
            }
            else if (GLOBAL.punctajTotal == 9)
            {
                premiu = "Premiul 2";
            }
            else if (GLOBAL.punctajTotal == 8)
            {
                premiu = "Premiul 3";
            }
            else if (GLOBAL.punctajTotal >= 5)
            {
                premiu = "Menitiune";
            }
            else
            {
                premiu = "Diploma de participare!";
            }

            sms = sms + premiu;
            this.label1.Text = sms;
        }
    }
}
