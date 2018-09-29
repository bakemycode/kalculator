using System;
namespace kalculrator3
{
    public class MenuSelect
    {
        public void MenuSlect_()
        {
            Console.WriteLine("This is the main menu");
            Console.WriteLine("You can change the menu by number.");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Check your goal");
            Console.WriteLine("2. Input what you ate");
            Console.WriteLine("3. Input new nutrition info");
            Console.WriteLine("4. List foods info");
            Console.WriteLine("5. Terminate the program");
            Console.WriteLine("----------------------------------");
            Console.Write("Type a number : ");

            int menu_select = Int32.Parse(Console.ReadLine());

            if (menu_select == 4)
            {
                
            }


        }
    }
}
