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
    public partial class Creare_Lectii : Form
    {
        public Creare_Lectii()
        {
            InitializeComponent();
        }

        int col, lin;

        private void Creare_Lectii_Load(object sender, EventArgs e)
        {
            col = 1;
            lin = 1;
        }
        private void button_Rand_Nou_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            // this.tableLayoutPanel1.Controls.Add(new Label() { Text = "Altceva" }, 1, 2);
        }

        private void button_Sterge_Rand_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount - 1;
        }

        private void button_Coloana_Noua_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount = tableLayoutPanel1.ColumnCount + 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        }

        private void button_Sterge_Coloana_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount = tableLayoutPanel1.ColumnCount - 1;
        }

        private void button_Latime_Coloana_Plus_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = tableLayoutPanel1.Width + 10;
        }

        private void button_Latime_Coloana_minus_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Width = tableLayoutPanel1.Width - 10;
        }

        private void button_Inaltime_Rand_Plus_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Height = tableLayoutPanel1.Height + 10;
        }

        private void button_Inaltime_Rand_minus_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Height = tableLayoutPanel1.Height - 10;
        }

        private void button_Text_Nou_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Add(new TextBox(), col++, lin++);
        }

        private void button_Sterge_Text_Click(object sender, EventArgs e)
        {
        }
    }
}
