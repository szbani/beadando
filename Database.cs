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
            sqlite_conn = new SQLiteConnection("Data Source=db.db;");
            sqlite_conn.Open();
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

        public List<List<string>> getAdminFoglaltak(int jarat)
        {
            List<List<String>> list = new List<List<string>>();
            
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT ules, nev, leszall, kupon FROM foglaltak WHERE jaratid = "+ jarat +"";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                List<string> eleme = new List<string>();
                eleme.Add(reader.GetInt32(0).ToString());
                eleme.Add(reader.GetString(1));
                eleme.Add(reader.GetString(2));
                eleme.Add(reader.GetDouble(3).ToString());
                list.Add(eleme);
            }
            return list;
        }

        public void vasarlas(int jarat,List<int>ulesek,string nev,string megallo,double kupon)
        {
            string values = "";
            foreach (int ules in ulesek)
            {
                if (values != "") values += ",";
                values += "('" + jarat + "','" + ules + "','" + nev + "','"+megallo+"',"+kupon+")";
            }
            query = sqlite_conn.CreateCommand();
            query.CommandText = "INSERT INTO foglaltak(jaratid,ules,nev,leszall,kupon) VALUES " + values;
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
        public List<string> getJaratMegallok(int jarat)
        {
            List<string> list = new List<string>();
            query = sqlite_conn.CreateCommand();
            query.CommandText = "SELECT megallo FROM megallok WHERE jaratid = '" + jarat + "' ORDER BY sorrend";
            reader = query.ExecuteReader();
            while (reader.Read())
            {
                string str = reader.GetString(0);
                list.Add(str);
            }
            return list;
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
                    return true;
                }
                return false;
            }
            return false;
            
        }

    }
}
