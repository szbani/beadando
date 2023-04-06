using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Beadando
{
    class Database
    {
        SQLiteConnection sqlite_conn;
        SQLiteDataReader reader;
        SQLiteCommand query;
        public Database() {
            sqlite_conn = CreateConnection();
        }

        private SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source=db.db;");
            try
            {
                sqlite_conn.Open();
            }catch (Exception ex)
            {
                
            }
            return sqlite_conn;
        }

        public bool isAdmin(string user)
        {
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT type FROM fiokok WHERE username = '" + user + "'";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                int type = reader.GetInt32(0);
                if (type == 0) return true;
                else return false;
            }
            return false;
        }

        public List<int> getFoglaltak(int jarat)
        {
            List<int> list = new List<int>();
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT ules FROM foglaltak WHERE jaratid = '" + jarat + "'";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetInt32(0));
            }
            return list;
        }

        public void vasarlas(int jarat,List<int>ulesek,string nev)
        {
            string values = "";
            foreach (int ules in ulesek)
            {
                if (values != "") values += ",";
                values += "('" + jarat + "','" + ules + "','" + nev + "')";
            }
            query = sqlite_conn.CreateCommand();
            query.CommandText = "INSERT INTO foglaltak(jaratid,ules,nev) VALUES " + values;
            query.ExecuteNonQuery();
        }

        public int getJaratId(string jaratNev,string tipus)
        {
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT id FROM jaratok WHERE nev = '" + jaratNev + "' AND tipus = '" + tipus + "'";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                int type = reader.GetInt32(0);
                return type;
            }
            return 0;
        }

        public List<string> getJaratok()
        {
            List<string> jaratok = new List<string>();
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT nev FROM jaratok GROUP BY nev";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                string type = reader.GetString(0);
                jaratok.Add(type);
            }
            return jaratok;
        }

        public bool Login(string user,string pass)
        {
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT count(*) FROM fiokok WHERE username = '"+user+"' AND password = '"+ pass + "'";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                int count = reader.GetInt32(0);
                if (count == 1)
                {
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }

            return false;
        }

    }
}
