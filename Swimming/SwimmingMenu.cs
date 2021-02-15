using Swimming.ADO.DAL.Repositories.Connection;
using System;

namespace SwimmingConsoleApp
{
    public class SwimmingMenu
    {
        private readonly IConnection _context;
        public SwimmingMenu(IConnection context)
        {
            _context = context;
        }
        public void Menu()
        {
            string menunumber = "";

            do
            {
                Console.WriteLine("\nEnter '1' to show EF Menu\nEnter '2' to show ADO Menu");
                menunumber = Console.ReadLine();

                switch (menunumber)
                {
                    case "1":
                        EFMenu efMenu = new EFMenu();
                        efMenu.Menu();
                        break;
                    case "2":
                        ADOMenu adoMenu = new ADOMenu(_context);
                        adoMenu.Menu();
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
