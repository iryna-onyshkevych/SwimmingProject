using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;

namespace Swimming.ADO.BL.Services
{
    public class SwimStyleService
    {
        private readonly ISwimStyleManager<SwimStyle> _swimStyleManager;

        public SwimStyleService(ISwimStyleManager<SwimStyle> swimStyleManager)
        {
            _swimStyleManager = swimStyleManager;
        }

        public void SelectSwimStyles()
        {
            try
            {
                Console.Write("Swimming Styles:\n");
                Console.WriteLine("\tId \tStyle Name ");
                var coaches = _swimStyleManager.GetList();
                foreach (SwimStyle c in coaches)
                {
                    Console.WriteLine($"{c.Id,10} {c.StyleName,15}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
