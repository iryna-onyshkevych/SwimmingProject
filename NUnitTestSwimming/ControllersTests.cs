using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SwimmingWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestSwimming
{
    public class ControllersTests
    {

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void SwimmerContoller_Instanceof()
        {

            var serviceMock = new Mock<ISwimmerService>();
            serviceMock.Setup(a => a.SelectSwimmers());
            SwimmersController controller = new SwimmersController(serviceMock.Object);
            var result = controller.Index();
            var viewResult = Is.TypeOf<ViewResult>();
            Assert.IsInstanceOf<ViewResult>(result);



        }

        [Test]
        public void SwimmerController_Result_NotNull()
        {
            var serviceMock = new Mock<ISwimmerService>();
            serviceMock.Setup(a => a.SelectSwimmers());
            SwimmersController controller = new SwimmersController(serviceMock.Object);
            var result = controller.Index();

            Assert.IsNotNull(result);
        }
        [Test]
        public void CoachController_Verifying_WorkExperience()
        {
            CoachDTO coach = new CoachDTO()
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 75

            };


            var serviceMock = new Mock<ICoachService>();
            serviceMock.Setup(a => a.AddCoach(coach));
            CoachesController controller = new CoachesController(serviceMock.Object);
            var result = controller.Create(coach);
            serviceMock.Verify(t => t.AddCoach(It.Is<CoachDTO>(t => t.WorkExperience < 80)));
        }
        [Test]
        public void  CoachController_AddingCoache_Once()
        {
            CoachDTO coach = new CoachDTO()
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };

            var serviceMock = new Mock<ICoachService>();
            serviceMock.Setup(a => a.AddCoach(coach));
            CoachesController controller = new CoachesController(serviceMock.Object);
            var result = controller.Create(coach);

            serviceMock.Verify(m => m.AddCoach(coach), Times.Once);

        }
    }
}
