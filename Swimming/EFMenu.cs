using Swimming.EntityFramework.BAL.Services;
using System;


namespace Swimming
{
    public class EFMenu
    {
        string menunumber = "";
        public void Menu()
        {
            Add add = new Add();
            Delete delete = new Delete();
            Select select = new Select();
            Update update = new Update();
            SwimmingMenu menu = new SwimmingMenu();

            do
            {
                Console.WriteLine("\nEnter 1 to delete coach\nEnter 2 to insert coach\nEnter 3 to show coaches' list\n" +
                    "Enter 4 to update coach\nEnter 5 to show swimmers' list\nEnter 6 to add swimmer\nEnter 7 to delete swimmer\nEnter 8 to show all trainings" +
                    "\nEnter 9 to update distance\nEnter 10 to show swimmers who have age more than entered\nEnter 11 to go back to Main menu\n");
                menunumber = Console.ReadLine();
                switch (menunumber)
                {
                    case "1":
                        delete.DeleteCoach();
                        break;
                    case "2":
                        add.AddCoach();
                        break;
                    case "3":
                        select.SelectCoaches();
                        break;
                    case "4":
                        update.UpdateCoach();
                        break;
                    case "5":
                        select.SelectSwimmers();
                        break;
                    case "6":
                        add.AddSwimmwer();
                        break;
                    case "7":
                        delete.DeleteSwimmer();
                        break;
                    case "8":
                        select.SelectTraining();
                        break;
                    case "9":
                        update.UpdateDistance();
                        break;
                    case "10":
                        select.SelectSwimmersByAge();
                        break;
                    case "11":
                        menu.Menu();
                        break;
                    default:
                        menunumber = "default";
                        Console.WriteLine("Default case");
                        break;

                }

            }


            while (menunumber != "default");
        }


    }
}
