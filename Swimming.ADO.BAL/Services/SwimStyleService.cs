using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.ADO.DAL.Repositories;
using Swimming.ADO.DAL.Repositories.Connection;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Swimming.ADO.BL.Services
{
    public class SwimStyleService
    {
        private readonly IConnection _context;
        public SwimStyleService(IConnection context)
        {
            _context = context;
        }
        public void SelectSwimStyles()
        {
            try
            {
                Console.Write("Swimming Styles:\n");
                Console.WriteLine("\tId \tStyle Name ");

               
                    ISwimStyleManager<SwimStyle> coachManager = new SwimStyleRepository(_context);
                    var coaches = coachManager.GetList();
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
