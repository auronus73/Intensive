using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Intensive
{
    class Methods
    {
        static string sPath = Path.Combine(Application.StartupPath, "Intensive.db");
        public static string ConnectionString = @"Data Source=" + sPath + ";New=False;Version=3";
        static public SQLiteConnection connect = new SQLiteConnection(ConnectionString);
        static public SQLiteCommand cmd;

        static public DataSet selectTable(String selectCommand)
        {
            connect.Open();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(selectCommand, connect);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            connect.Close();
            return ds;
        }

        static public void changeValue(String selectCommand)
        {
            connect.Open();
            SQLiteTransaction trans;
            trans = connect.BeginTransaction();
            cmd.Connection = connect;
            cmd.CommandText = selectCommand;
            cmd.ExecuteNonQuery();
            trans.Commit();
            connect.Close();
        }

        static public List<string> Insert_Title(string kind)
        {
            List<string> list = new List<string>();
            connect.Open();
            SQLiteCommand command = new SQLiteCommand(String.Format("select title from food where kind='{0}'", kind), connect);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            connect.Close();
            return list;
        }

        static public void ExecuteQuery(string txtQuery)
        {
            connect.Open();
            cmd = connect.CreateCommand();
            cmd.CommandText = txtQuery;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        static public string dateform(string date_temp) //формирование дат
        {
            string date = "";
            Char delimiter = '.';
            String[] substrings = date_temp.Split(delimiter);
            date += substrings[2] + "-";
            date += substrings[1] + "-";
            date += substrings[0];
            return date;
        }
    }
}
