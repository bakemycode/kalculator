using System;
using MySql.Data.MySqlClient;

namespace kalculrator3
{
    public class ItemAddition
    {
        public string Name;
        public int Unit;
        public int Calories;
        public int Carb;
        public int Protein;
        public int Fat;

        public void ItemAddition_()
        {
            Console.WriteLine("You can input more items here");
            Console.WriteLine("if you don't know the number, just hit the enter");

            // I think there might be simpler way to do this
            Console.Write("Name of the item? : ");
            this.Name = Console.ReadLine();

            Console.Write("Unit of the item? : ");
            this.Unit = Int32.Parse(Console.ReadLine());

            Console.Write("total calories of the item? : ");
            this.Calories = Int32.Parse(Console.ReadLine());

            Console.Write("Carb of the item? : ");
            this.Carb = Int32.Parse(Console.ReadLine());

            Console.Write("Protein of the item? : ");
            this.Protein = Int32.Parse(Console.ReadLine());

            Console.Write("Fat of the item? : ");
            this.Fat = Int32.Parse(Console.ReadLine());
        }
        //(string namefromuser, Int32 unitfromuser, string calroliesfromuser, string carbfromuser, string proteinfromuser, string fatfromuser)
        public void Add_Data_to_MySQL()
        {
            var dbDirect = "Server=localhost;Database=Kalculator3;Uid=root;Pwd=theBigBang!23;";

            using (MySqlConnection connecttoDB = new MySqlConnection(dbDirect))
            {
                connecttoDB.Open();

                string sql = $"INSERT INTO FoodList (ITEM, UNIT, CALORIES, CARB, PROTEIN, FAT) VALUE ('{this.Name}', {this.Unit}, {this.Calories}, {this.Carb}, {this.Protein}, {this.Fat});";
                MySqlCommand cmd = new MySqlCommand(sql, connecttoDB);
                cmd.ExecuteNonQuery();

                Console.WriteLine("The data has been stored!");
            }
        }
    }
}