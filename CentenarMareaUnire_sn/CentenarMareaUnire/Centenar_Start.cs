using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CentenarMareaUnire
{
    public partial class Centenar_Start : Form
    {
        public Centenar_Start()
        {
            InitializeComponent();
        }

        CONNECT conn = new CONNECT();
        private void Centenar_Start_Load(object sender, EventArgs e)
        {
            stergere();
            initializare();
        }

        public void stergere()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Delete From Lectii";
            command.Connection = conn.getConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();

            command = new SqlCommand();
            command.CommandText = "Delete From Utilizatori";
            command.Connection = conn.getConnection();

            conn.openConnection();
            command.ExecuteNonQuery();
            conn.closeConnection();
        }

        public void initializare()
        {

            string sir;
            string[] siruri;
            char split = '*';
            string fn;
            StreamReader sr;
            SqlCommand command;
            fn = Application.StartupPath + @"\Resurse_C#\utilizatori.txt";
            sr = new StreamReader(fn);


            while ((sir = sr.ReadLine()) != null)
            {
                siruri = sir.Split(split);
                command = new SqlCommand();
                command.CommandText = "Insert Into Utilizatori(Nume,Parola,Email) Values(@nm,@pass,@eamil)";
                command.Connection = conn.getConnection();

                //@nm,@pass,@eamil

                command.Parameters.Add("nm", SqlDbType.VarChar).Value = siruri[0];
                command.Parameters.Add("pass", SqlDbType.VarChar).Value = siruri[1];
                command.Parameters.Add("eamil", SqlDbType.VarChar).Value = siruri[2];

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();
            }

            fn = Application.StartupPath + @"\Resurse_C#\lectii.txt";
            sr = new StreamReader(fn);

            string nameIMG = "";
            int idIMG = 0;
            while ((sir = sr.ReadLine()) != null)
            {
                idIMG++;
                nameIMG = "lectia" + idIMG.ToString() + ".bmp";

                siruri = sir.Split(split);
                command = new SqlCommand();
                command.CommandText = "Insert Into Lectii(IdUtilizator,TitluLectie,Regiune,DataCreare,NumeImagine) Values(@id,@titlu,@regiune,@data,@nmimg)";
                command.Connection = conn.getConnection();

                //@id,@titlu,@regiune,@data,@nmimg

                command.Parameters.Add("id", SqlDbType.Int).Value = Convert.ToInt32(siruri[0]);
                command.Parameters.Add("titlu", SqlDbType.VarChar).Value = siruri[1];
                command.Parameters.Add("regiune", SqlDbType.VarChar).Value = siruri[2];
                command.Parameters.Add("data", SqlDbType.DateTime).Value = Convert.ToDateTime(siruri[3]);
                command.Parameters.Add("nmimg", SqlDbType.VarChar).Value = nameIMG;

                conn.openConnection();
                command.ExecuteNonQuery();
                conn.closeConnection();
            }



        }

        private void toolStripButton_Vizualizare_lectii_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vizualizare_Lectii f = new Vizualizare_Lectii();
            f.ShowDialog();
        }

        private void toolStripButton_Logare_Utilizator_Click(object sender, EventArgs e)
        {
            this.Hide();
            Logare f = new Logare();
            f.ShowDialog();
        }

        private void toolStripButton_Creare_Lectie_Click(object sender, EventArgs e)
        {
            this.Hide();
            Creare_Lectii f = new Creare_Lectii();
            f.ShowDialog();
        }

        private void toolStripButton_Ghiceste_Regiunea_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ghiceste_Regiunea f = new Ghiceste_Regiunea();
            f.ShowDialog();
        }

        private void toolStripButton_Generare_Traseu_Click(object sender, EventArgs e)
        {
            Generare_Traseu f = new Generare_Traseu();
            f.ShowDialog();
        }
    }
}
