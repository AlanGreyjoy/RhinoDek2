using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace RhinoDek2.Classes
{
    class SQLHelper
    {
        private string connection = Classes.StaticData.SQL_ConnectionString;

        //Fill a DataTable with the results from the SQL server\\
        public static DataTable GetTable(string command)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(command, Classes.StaticData.SQL_ConnectionString);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Server Error";
                alert.ContentText = "There was a problem with the server." + Environment.NewLine +
                    ex.Message;
                alert.Show();
                alert.PlaySound = true;
            }

            return dt;
        }

        //Save To Database\\
        public void Save(string table_name, string column_name, string save_value)
        {
            SqlConnection conn = new SqlConnection(StaticData.SQL_ConnectionString);
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = string.Format("INSERT INTO {0} ({1}) VALUES ('{2}');", table_name, column_name, save_value);
            command.Connection = conn;
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                RadDesktopAlert alert = new RadDesktopAlert();
                alert.CaptionText = "RhinoDek Error";
                alert.ContentText = "There was a problem with the SQL Helper" + Environment.NewLine + ex.Message +
                    Environment.NewLine + command.CommandText;
                alert.Show();
            }
        }



    }
}
