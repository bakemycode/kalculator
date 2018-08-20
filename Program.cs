﻿using System;
using MySql.Data.MySqlClient;


namespace kalculrator3

{
    class Program
    {
        /*
        private static void SelectUsingReader()
        {
            var direct = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";

            using (MySqlConnection conn = new MySqlConnection(direct))
            {
                conn.Open();

                string sql = "SELECT * FROM FoodList";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("NAME : {0}",rdr["NAME"]);
                    Console.WriteLine("CALORIES : {0}", rdr["CALORIES"]);
                    Console.WriteLine("CARB : {0}", rdr["CARB"]);
                    Console.WriteLine("PROTEIN : {0}", rdr["PROTEIN"]);
                    Console.WriteLine("FAT : {0}", rdr["FAT"]);
                    Console.WriteLine();

                }
                rdr.Close();
            }
        }
*/
        static void Main(string[] args)
        {
            var strConn = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";
            MySqlConnection connection = new MySqlConnection(strConn);
        

            connection.Open();
            Console.WriteLine(connection.State);


            var reading = new SelectUsing_Reader();
            reading.SelectUsingReader();
        }
    }


}