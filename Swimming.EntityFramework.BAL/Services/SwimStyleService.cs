using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.EntityFramework.DAL.Repositories;
using System;

namespace Swimming.EntityFramework.BL.Services
{
    public class SwimStyleService
    {
        public void SelectSwimStyles()
        {
            try
            {
                Console.Write("Swimming Styles:\n");
                Console.WriteLine("\tId \tStyle Name ");

                using (swimmingContext swimdb = new swimmingContext())
                {
                    ISwimStyleManager<SwimStyle> swimStyleManager = new SwimStyleRepository(swimdb);
                    var swimStyles = swimStyleManager.GetList();
                    foreach (SwimStyle c in swimStyles)
                    {
                        Console.WriteLine($"{c.Id,10} {c.StyleName,15}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
