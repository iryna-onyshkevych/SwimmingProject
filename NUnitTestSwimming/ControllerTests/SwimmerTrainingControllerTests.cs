using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SwimmingWebApp.Controllers;
using System;

namespace NUnitTestSwimming.ControllerTests
{
    public class SwimmerTrainingControllerTests
    {
        [Test]
        public void SwimmerTrainingController_Verify_AddingCalledOnce()
        {
            TrainingDTO training = new TrainingDTO()
            {
                SwimmerId = 1,
                SwimStyleId = 1,
                TrainingDate = Convert.ToDateTime("2018-02-02"),
                Distance = 800
            };

            var serviceMock = new Mock<ITrainingService>();
            serviceMock.Setup(a => a.AddTraining(training));
            SwimmerTrainingController controller = new SwimmerTrainingController(serviceMock.Object);

            //act
            var result = controller.Create(training);

            //assert
            serviceMock.Verify(m => m.AddTraining(training), Times.Once);
        }

        [Test]
        public void SwimmerTrainingController_Verify_Delete()
        {
            // arrange
            int id = 250;
            var serviceMock = new Mock<ITrainingService>();
            serviceMock.Setup(a => a.DeleteTraining(id));
            SwimmerTrainingController controller = new SwimmerTrainingController(serviceMock.Object);

            // act
            IActionResult result = controller.Delete(id) as IActionResult;

            // assert
            serviceMock.Verify(a => a.DeleteTraining(id));
        }
    }
}
