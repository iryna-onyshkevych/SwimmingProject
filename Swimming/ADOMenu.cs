using Swimming.ADO.BL.Services;
using System;

namespace SwimmingConsoleApp
{
    public class ADOMenu
    {
        string menunumber = "";

        public void Menu()
        {
            CoachService coachService = new CoachService();
            SwimmerService swimmerService = new SwimmerService();
            TrainingService trainingService = new TrainingService();
            TrainingSwimmerSwimStyleService trainingSwimmerSwimStyleService = new TrainingSwimmerSwimStyleService();
            SwimmingMenu menu = new SwimmingMenu();

            do
            {
                Console.WriteLine("\nEnter 1 to delete coach\nEnter 2 to add coach\nEnter 3 to show coaches' list\n" +
                   "Enter 4 to update coach\nEnter 5 to show swimmers' list\nEnter 6 to add swimmer\nEnter 7 to delete swimmer\nEnter 8 to show all trainings" +
                   "\nEnter 9 to update distance\nEnter 10 to show swimmers who have age more than entered\nEnter 11 to add training\nEnter 12 to go back to Main menu\n");
                menunumber = Console.ReadLine();

                switch (menunumber)
                {
                    case "1":
                        coachService.DeleteCoach();
                        break;
                    case "2":
                        coachService.AddCoach();
                        break;
                    case "3":
                        coachService.SelectCoaches();
                        break;
                    case "4":
                        coachService.UpdateCoach();
                        break;
                    case "5":
                        swimmerService.SelectSwimmers();
                        break;
                    case "6":
                        swimmerService.AddSwimmwer();
                        break;
                    case "7":
                        swimmerService.DeleteSwimmer();
                        break;
                    case "8":
                        trainingSwimmerSwimStyleService.SelectTraining();
                        break;
                    case "9":
                        trainingService.UpdateDistance();
                        break;
                    case "10":
                        swimmerService.SelectSwimmersByAge();
                        break;
                    case "11":
                        trainingService.AddTraining();
                        break;
                    case "12":
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
