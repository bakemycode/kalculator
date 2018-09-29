using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace kalculrator3

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the main menu");
            Console.WriteLine("You can move on the menu by number.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Check your goal");
            Console.WriteLine("2. Input what you ate");
            Console.WriteLine("3. Input new nutrition info");
            Console.WriteLine("4. see the list of foods info");
            Console.WriteLine("5. Terminate the program");
            Console.WriteLine("6. test for developer");
            Console.WriteLine("----------------------------------");
            Console.Write("Type a number : ");

            int menu_select = Int32.Parse(Console.ReadLine());

            if (menu_select == 2)
            {
                var inputFoodEaten = new WhatYouEat();
                inputFoodEaten._WhatYouEat();
                /*
                var inputFoodEaten = new whatyouate();
                inputFoodEaten.whatyouate_();
                */
            }
            else if (menu_select == 3)
            {
                var inputNewinfo = new ItemAddition();
                inputNewinfo.ItemAddition_();
                Console.WriteLine(inputNewinfo.Name);
                inputNewinfo.Add_Data_to_MySQL();
                Console.WriteLine(inputNewinfo.Name);
            }
            else if (menu_select == 4)
            {
                var reading = new SelectUsingReader();

                //if a parameter is input, it will show the details of it, otherwise all of items.
                Console.WriteLine("if you want to look up the information of the food, type the name of it. otherwise show whole list");
                Console.Write(" : ");
                var targetSearch = Console.ReadLine();

                if (targetSearch == null)
                {
                    reading.SelectUsingReader_();
                }
                reading.SelectUsingReader_(targetSearch);
            }

            else if (menu_select == 5)
            {

            }

            else if (menu_select == 6)
            {

                var numberTesting = new List<int>() { 1, 2, 3, 4, 5 };
                foreach (int a in numberTesting)
                {
                    Console.WriteLine(a);
                }

                for (int i = 0; i < 5; i++)
                {
                    numberTesting[i] = numberTesting[i] * 2;
                    Console.WriteLine(numberTesting[i]);
                }




                /*
                var dbDirect = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";

                using (MySqlConnection connecttoDB = new MySqlConnection(dbDirect))
                {
                    connecttoDB.Open();

                    string sql = "SELECT ITEM FROM FoodList";

                    MySqlCommand cmd = new MySqlCommand(sql, connecttoDB);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    var nameofItems = new List<string>();

                    while (rdr.Read())
                    {
                        nameofItems.Add(Convert.ToString(rdr["ITEM"]));
                    }

                    foreach (string prime in nameofItems)
                    {
                        Console.WriteLine(prime);
                    }

                    var a = nameofItems.IndexOf("tesajenfting");
                    Console.WriteLine(a);
                    /*
                    while (rdr.Read())
                    {
                        Console.WriteLine("ITEM : {0}", rdr["ITEM"]);
                    }
                    */

                /*
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
                */

            }

        }




    }
}



