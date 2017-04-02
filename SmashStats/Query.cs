using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SmashStats
{
    class Query
    {
        public Query ()
        {

        }

        public List<Tuple<string, string>> LoadData ()
        {
            List <Tuple<string, string>> dataList = new List<Tuple<string, string>>();
            SQLiteConnection connection = new SQLiteConnection("Data Source=Resources/melee.sqlite;Version=3;");
            connection.Open();

            string sql = "SELECT tournament_name, tournament_date FROM Tournament";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tuple<string, string> data = new Tuple<string, string> ((string)reader["tournament_name"], reader["tournament_date"].ToString());
                dataList.Add(data);
            }
            connection.Close();
            return dataList;
        }

        public List<Tuple<string, string>> LoadTournamentsByDate (int year)
        {
            List<Tuple<string, string>> dataList = new List<Tuple<string, string>>();
            Console.WriteLine(year);
            SQLiteConnection connection = new SQLiteConnection("Data Source=Resources/melee.sqlite;Version=3;");
            connection.Open();

            // string sql = String.Format("SELECT tournament_name, tournament_date FROM Tournament WHERE strftime('%y', tournament_date) = {0};", year);
            string sql = String.Format("SELECT tournament_name, tournament_date FROM TOURNAMENT WHERE CAST(strftime('%Y', tournament_date) AS integer) = {0}", year);
            //string sql = String.Format("SELECT tournament_name, strftime('%Y', tournament_date) as date");
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tuple<string, string> data = new Tuple<string, string>((string)reader["tournament_name"], reader["tournament_date"].ToString());
                dataList.Add(data);
            }
            connection.Close();
            return dataList;
        }
    }
}
