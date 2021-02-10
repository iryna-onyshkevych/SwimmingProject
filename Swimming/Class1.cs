using ADO.BL.Services;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwimmingConsoleApp
{
    public class Class1
    {
        public void Update()
        {
            Console.Write("Enter date:");
            string date = Console.ReadLine();

            Console.Write("Enter distance:");
            string distance = Console.ReadLine();

            Console.Write("Enter swimmerid");
            string swimmerId = Console.ReadLine();
            Console.Write("Enter styleid:");
            string styleId = Console.ReadLine();
            TrainingService sr = new TrainingService();
            TrainingDTO training = new TrainingDTO();


            training.SwimmerId = Convert.ToInt32(swimmerId);
            training.SwimStyleId = Convert.ToInt32(styleId);
            training.Distance = Convert.ToInt32(distance);
            training.TrainingDate = Convert.ToDateTime(date);

            sr.AddTraining(training);
        }
    }
}
