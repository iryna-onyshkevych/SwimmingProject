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
            //arrange
            var serviceMock = new Mock<ISwimmerService>();
            serviceMock.Setup(a => a.SelectSwimmers());
            SwimmersController controller = new SwimmersController(serviceMock.Object);
            //act
            var result = controller.Index();
            var viewResult = Is.TypeOf<ViewResult>();
            //assert
            Assert.IsInstanceOf<ViewResult>(result);

        }

        [Test]
        public void SwimmerController_Result_NotNull()
        {
            //arrange

            var serviceMock = new Mock<ISwimmerService>();
            serviceMock.Setup(a => a.SelectSwimmers());
            SwimmersController controller = new SwimmersController(serviceMock.Object);

            var result = controller.Index();

            Assert.IsNotNull(result);
        }
        [Test]
        public void CoachController_Result_NotNull()
        {
            //arrange

            var serviceMock = new Mock<ICoachService>();
            serviceMock.Setup(a => a.SelectCoaches());
            CoachesController controller = new CoachesController(serviceMock.Object);

            var result = controller.Index();

            Assert.IsNotNull(result);
        }
        [Test]
      
        public void CoachController_Verifying_WorkExperience()
        {
            //arrange

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

            serviceMock.Verify(t => t.AddCoach(It.Is<CoachDTO>(t => (t.WorkExperience < 80) && (t.WorkExperience>=0))));
        }
        [Test]
        public void  CoachController_Verify_AddingCalledOnce()
        {
            //arrange

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
        [Test]
        public void SwimmerController_Verify_Delete()
        {
            //arrange

            int id = 1;
            var serviceMock = new Mock<ISwimmerService>();

            SwimmersController controller = new SwimmersController(serviceMock.Object);
            // act
            IActionResult result = controller.Delete(id) as IActionResult;
            // assert
            serviceMock.Verify(a => a.DeleteSwimmer(id));



        }
        
    }
}
