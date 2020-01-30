using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CentenarMareaUnire
{
    class LECTII
    {
        CONNECT conn = new CONNECT();

        public DataTable getLectii()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select NumeImagine From Lectii";
            command.Connection = conn.getConnection();

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        public DataTable getUserData(string nm)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT Utilizatori.Nume,Utilizatori.Email,Lectii.Regiune,Lectii.DataCreare FROM Lectii INNER JOIN Utilizatori ON Lectii.IdUtilizator=Utilizatori.IdUtilizator WHERE Lectii.NumeImagine=@nm";
            command.Connection = conn.getConnection();

            command.Parameters.Add("nm", SqlDbType.VarChar).Value = nm;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }


    }
}
