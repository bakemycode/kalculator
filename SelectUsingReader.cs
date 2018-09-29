using System;
using MySql.Data.MySqlClient;


namespace kalculrator3
{
    public class SelectUsingReader
    {
        // i think I can make this simpler with constructor.

        public void SelectUsingReader_()
        {
            var dbDirect = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";

            using (MySqlConnection connecttoDB = new MySqlConnection(dbDirect))
            {
                connecttoDB.Open();

                string sql = "SELECT * FROM FoodList";

                MySqlCommand cmd = new MySqlCommand(sql, connecttoDB);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("ITEM : {0}", rdr["ITEM"]);
                    Console.WriteLine("UNIT : {0}", rdr["UNIT"]);
                    Console.WriteLine("CALORIES : {0}", rdr["CALORIES"]);
                    Console.WriteLine("CARB : {0}", rdr["CARB"]);
                    Console.WriteLine("PROTEIN : {0}", rdr["PROTEIN"]);
                    Console.WriteLine("FAT : {0}", rdr["FAT"]);
                    Console.WriteLine();
                }
                rdr.Close();
            }
        }
        //do i have to repeat same code here?
        public MySqlDataReader SelectUsingReader_(string search_target)
        {
            var dbDirect = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";
            MySqlConnection connecttoDB = new MySqlConnection(dbDirect);

            connecttoDB.Open();

            string sql = $"SELECT * FROM FoodList where ITEM like '{search_target}'";

            MySqlCommand cmd = new MySqlCommand(sql, connecttoDB);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("ITEM : {0}", rdr["ITEM"]);
                Console.WriteLine("UNIT : {0}", rdr["UNIT"]);
                Console.WriteLine("CALORIES : {0}", rdr["CALORIES"]);
                Console.WriteLine("CARB : {0}", rdr["CARB"]);
                Console.WriteLine("PROTEIN : {0}", rdr["PROTEIN"]);
                Console.WriteLine("FAT : {0}", rdr["FAT"]);
                Console.WriteLine();
            }

            return rdr;

        }
    }

}