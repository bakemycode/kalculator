//I don't think this class is needed because it can be replaceable to selectusingreader

using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace kalculrator3

{
    public class SearchFromDB
    {
        public SearchFromDB(string foodname)
        {
            var direct = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";

            using (var connectToMysql = new MySqlConnection(direct))
            {
                connectToMysql.Open();
                Console.WriteLine("DB is available in Search Mode");

                string sql = $"SELECT * FROM FoodList where NAME like '%{foodname}%'";
                Console.WriteLine("Search {0}",foodname);

                DataSet ds = new DataSet();



                var mysqlCmd = new MySqlCommand(sql, connectToMysql);

                var adapter = new MySqlDataAdapter();

                //i don't understand from here
                adapter.SelectCommand = mysqlCmd;
                // to here

                adapter.Fill(ds);

                Console.WriteLine(ds.GetType());
                if(ds.Tables.Count == 0)
                {
                    Console.WriteLine("can't find the data");
                }
                else
                {
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(r["CARB"]);
                    }
                    /*
                    Console.WriteLine("NAME : {0}", ds.Tables[0].Rows);
                    Console.WriteLine("CALORIES : {0}", ds.Tables[1].Rows);
                    Console.WriteLine("CARB : {0}", ds.Tables[2].Rows);
                    Console.WriteLine("PROTEIN : {0}", ds.Tables[3].Rows);
                    Console.WriteLine("FAT : {0}", ds.Tables[4].Rows);
                    Console.WriteLine();                
                    */
                }


            }
        }
    }
}

/*
            using (MySqlConnection conn = new MySqlConnection(direct))
            {
                conn.Open();

                string sql = "SELECT * FROM FoodList";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("NAME : {0}", rdr["NAME"]);
                    Console.WriteLine("CALORIES : {0}", rdr["CALORIES"]);
                    Console.WriteLine("CARB : {0}", rdr["CARB"]);
                    Console.WriteLine("PROTEIN : {0}", rdr["PROTEIN"]);
                    Console.WriteLine("FAT : {0}", rdr["FAT"]);
                    Console.WriteLine();
                }
                rdr.Close();
            }
        }
    }
}
*/