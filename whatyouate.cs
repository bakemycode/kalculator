using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace kalculrator3
{
    public class whatyouate
    {
        public void whatyouate_()
        {
            Console.WriteLine("type the name of what you ate.");
            string inputOfItemFromUser = Console.ReadLine();

            var dbDirect = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";

            using (MySqlConnection connecttoDB = new MySqlConnection(dbDirect))
            {
                connecttoDB.Open();

                string sql = "SELECT ITEM FROM FoodList";

                MySqlCommand cmd = new MySqlCommand(sql, connecttoDB);
                MySqlDataReader rdr = cmd.ExecuteReader();

                //operator != can't be applied to a string
                //so i'm gonna make a list to save ITEMs
                var nameofItems = new List<string>();
                Console.WriteLine(connecttoDB.State);
                while(rdr.Read())
                {
                    nameofItems.Add(Convert.ToString(rdr["ITEM"]));
                }
                connecttoDB.Close();

                //now check if inputOfItemFromUser exists or not
                //by index '-1'

                // if not
                if(nameofItems.IndexOf(inputOfItemFromUser) == -1)
                {
                    Console.WriteLine("Item {0} doesn't exist in the list", inputOfItemFromUser);
                    Console.WriteLine("would you like to make a new record?");
                }

                //if exists
                else
                {
                    var sql_ofuserinput = $"SELECT * FROM FoodList where item like '{inputOfItemFromUser}'";
                    Console.WriteLine(connecttoDB.State);
                    connecttoDB.Open();

                    MySqlCommand cmd_ofuserinput = new MySqlCommand(sql_ofuserinput,connecttoDB);
                    MySqlDataReader rdr_ofuserinput = cmd_ofuserinput.ExecuteReader();


                    Console.WriteLine("Details of {0}", inputOfItemFromUser);

                    //to save details of target item
                    var detailsOfItem = new List<int>();
                    rdr_ofuserinput.Read();

                    //is it ok to parse like this? I'm not sure
                    detailsOfItem.Add((Int32)rdr_ofuserinput["UNIT"]);
                    detailsOfItem.Add((Int32)rdr_ofuserinput["CALORIES"]);
                    detailsOfItem.Add((Int32)rdr_ofuserinput["CARB"]);
                    detailsOfItem.Add((Int32)rdr_ofuserinput["PROTEIN"]);
                    detailsOfItem.Add((Int32)rdr_ofuserinput["FAT"]);
                
                    Console.WriteLine();

                    Console.WriteLine("how much did you eat?");
                    var howMuchAte = Int32.Parse(Console.ReadLine());
                    //if howMuchAte is as same as the data in the list
                    if (howMuchAte == detailsOfItem[1])
                    {
                        //just add
                        
                    }

                    //if not
                    else
                    {
                        //multiply the data to howMuchAte and save it
                        for (int i = 1; i < 5; i++)
                        {
                            detailsOfItem[i] *= howMuchAte;
                        }

                    }




                }
            }
        }
    }
}
