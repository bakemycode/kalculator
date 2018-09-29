using System;
using MySql.Data.MySqlClient;

namespace kalculrator3
{
    public class WhatYouEat
    {
        public void _WhatYouEat()
        {
            // connect to the database.
            var dbDirect = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";
            MySqlConnection connecttoDB = new MySqlConnection(dbDirect);
            connecttoDB.Open();

            //ask user to choose if he wants to make new table.
            Console.WriteLine();
            Console.WriteLine("You can input the data of what you ate in the table whose is username.");
            Console.Write("Do you want to make a new table? (y/n) : ");
            var userInput = Console.ReadLine();

            if (userInput == "y")
            {
                Console.WriteLine("let's make a new table");
                Console.WriteLine("What's your name?");
                Console.Write(" : ");
                var newUserName = Console.ReadLine();

                string sql_newUser = $"CREATE TABLE {newUserName} (ITEM VARCHAR(45), UNIT INT(11), CALORIES INT(11), CARB INT(11), PROTEIN INT(11), FAT INT(11));";

                MySqlCommand cmd_newUser = new MySqlCommand(sql_newUser, connecttoDB);
                cmd_newUser.ExecuteNonQuery();

                Console.WriteLine("new data table has made.");

                //but here is a problem.
                //I cannot check if the command is implemented or not because there is no exception control.
                //and I can't get the error message here.
            }

            Console.WriteLine();
            Console.WriteLine("Give me your name to find your table");
            var userName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Hello, {0}", userName);

            Console.WriteLine("input the name of item you want to add in the table. IT HAS TO BE ON THE LIST.");
            Console.Write(" : ");
            var nameofitem = Console.ReadLine();

            //check if the item exists in the table.
            var findTheItem = new SelectUsingReader();

            var datasetFromWholeList = findTheItem.SelectUsingReader_(nameofitem);

            //datasetFromWholeList.Read();

            var temporal_ITEM = datasetFromWholeList.GetString(datasetFromWholeList.GetOrdinal("ITEM"));

            var temporal_UNIT = datasetFromWholeList.GetInt32(datasetFromWholeList.GetOrdinal("UNIT"));

            var temporal_CALORIES = datasetFromWholeList.GetInt32(datasetFromWholeList.GetOrdinal("CALORIES"));
            var temporal_CARB = datasetFromWholeList.GetInt32(datasetFromWholeList.GetOrdinal("CARB"));
            var temporal_PROTEIN = datasetFromWholeList.GetInt32(datasetFromWholeList.GetOrdinal("PROTEIN"));
            var temporal_FAT = datasetFromWholeList.GetInt32(datasetFromWholeList.GetOrdinal("FAT"));

            Console.WriteLine("so far so good?");


            string sql = $"INSERT INTO {userName} (ITEM, UNIT, CALORIES, CARB, PROTEIN, FAT) VALUE ('{temporal_ITEM}', {temporal_UNIT}, {temporal_CALORIES}, {temporal_CARB}, {temporal_PROTEIN}, {temporal_FAT});";

            MySqlCommand cmd = new MySqlCommand(sql, connecttoDB);
            cmd.ExecuteNonQuery();

            Console.WriteLine("so far so good 2");

            Console.WriteLine();



        }
    }
}
