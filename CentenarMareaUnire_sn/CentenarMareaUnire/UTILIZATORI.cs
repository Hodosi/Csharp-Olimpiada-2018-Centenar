using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CentenarMareaUnire
{
    class UTILIZATORI
    {
        CONNECT conn = new CONNECT();

        public bool existsUser(string email, string pass)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * From Utilizatori WHERE Email=@em and Parola=@pass";
            command.Connection = conn.getConnection();

            command.Parameters.Add("em", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existsEmail(string email)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * From Utilizatori WHERE Email=@em";
            command.Connection = conn.getConnection();

            command.Parameters.Add("em", SqlDbType.VarChar).Value = email;

            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool changePass(string email, string pass)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Update Utilizatori Set Parola=@pass WHERE Email=@em";
            command.Connection = conn.getConnection();

            command.Parameters.Add("em", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;

            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
    }
}
