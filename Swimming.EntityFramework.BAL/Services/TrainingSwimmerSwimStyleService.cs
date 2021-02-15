using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using Swimming.EntityFramework.DAL.Repositories;
using System;

namespace Swimming.EntityFramework.BL.Services
{
    public class TrainingSwimmerSwimStyleService
    {
        public void SelectTraining()
        {
            try
            {
                using (swimmingContext db = new swimmingContext())
                {
                    ITrainingsSwimmersSwimStyleManager<TrainingsSwimmersSwimStyle> swimStyleManager = new TrainingSwimmerSwimStyleRepository(db);
                    var traininings = swimStyleManager.GetView();
                    Console.WriteLine("TrainingId\tName\t\tSurname\t\tDate\t\t\tDistance\t\tStyle");
                    foreach (var t in traininings)
                        Console.WriteLine("{0,10} {1,15} {2,15} {3,20} {4,15} {5,15}", t.TrainingId, t.FirstName, t.LastName, t.TrainingDate, t.Style, t.Distance);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
