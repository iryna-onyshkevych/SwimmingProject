
using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Swimming.Abstractions.Interfaces;
using SwimmingWebApp.Controllers;
using System;
using System.Collections.Generic;

namespace NUnitTestSwimming
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //TrainingViewService trainingService = new TrainingViewService();

            //var trainings = trainingService.SelectSwimmersTrainings();
            //IActionResult result = tc.Index() as IActionResult;
            //-------------------------------------------
            //// Assert
            //Assert.That (trainings, Is.EqualTo(result));
            //CoachesController controller = new CoachesController( );

            //// Act
            //IActionResult result = controller.Create() as IActionResult;
            

            //// Assert
            //Assert.IsNotNull(result);
            //-------------------------------



            //Assert.That(result,Is.Not.Null);
            //TrainingsController cr = new TrainingsController();

            //var actResult = cr.Index() as ViewResult;

            //Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }
        [Test]
        public void Test2()
        {

            var serviceMock = new Mock<ISwimmerService>();
            serviceMock.Setup(a => a.SelectSwimmers());
            SwimmersController controller = new SwimmersController(serviceMock.Object);
            var result = controller.Index();
            var viewResult = Is.TypeOf<ViewResult>();
            Assert.IsInstanceOf<ViewResult>(result);



            //Assert.That(viewResult,result);
            //Act
            //ContentResult result = controller.Index() as ContentResult;
            //serviceMock.Verify(m => m.SelectCoaches(), Times.Once);
            //CoachesController controller = new CoachesController();
            //ViewResult result = controller.Update() as ViewResult;
            //Assert.That("Update", Is.EqualTo(result?.ViewName));

            //    var mock = new Mock<TrainingViewService>();
            //    mock.Setup(repo => repo.SelectSwimmersTrainings()).Returns(GetTestUsers());
            //    var controller = new TrainingsController(mock.Object);

            //    // Act
            //    var result = controller.Index();

            //    // Assert
            //    Assert.IsInstanceOf<ViewResult>(result);
            //    var model = Assert.IsAssignableFrom<IEnumerable<TrainingsSwimmersSwimStyleDTO>>(viewResult.Model);
            //    Assert.That(GetTestUsers().Count,Is.EqualTo( model.Count()));
            //}
            //private List<TrainingsSwimmersSwimStyleDTO> GetTestUsers()
            //{
            //    var users = new List<TrainingsSwimmersSwimStyleDTO>
            //    {
            //        new TrainingsSwimmersSwimStyleDTO { TrainingId=141, FirstName ="dsd", LastName = "dvcd", TrainingDate = Convert.ToDateTime("2020-01-02"), Distance = 400, Style = "freestyle" },
            //        new TrainingsSwimmersSwimStyleDTO { TrainingId=181, FirstName ="dgfs", LastName = "ddffd", TrainingDate = Convert.ToDateTime("2010-01-02"), Distance = 800, Style = "freestyle" },

            //    };
            //    return users;
            //}
            //    //Arrange  
            //    var mock = new Mock<TrainingViewService>();
            //mock.Setup(repo => repo.SelectSwimmersTrainings()).Returns(GetTestUsers());
            //var controller = new CoachesController();
            //var coach = new CoachDTO() { FirstName = "dscx",LastName = "csc", WorkExperience = 13 };

            ////Act  
            //var data =  controller.Create(coach);

            ////Assert  
            //Assert.IsInstanceOf<OkObjectResult>(data);
        }
        [Test]
        public void Test3()
        {
            var serviceMock = new Mock<ISwimmerService>();
            serviceMock.Setup(a => a.SelectSwimmers());
            SwimmersController controller = new SwimmersController(serviceMock.Object);
            var result = controller.Index();
            
            Assert.IsNotNull(result);
        }
        [Test]
        public void Test4()
        {
            var serviceMock = new Mock<ISwimmerService>();
            var result = serviceMock.Setup(a => a.SelectSwimmers());
            

            Assert.IsNotNull(result);
        }
        [Test]
        public void Test5()
        {
            CoachDTO coach = new CoachDTO
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };
            var serviceMock = new Mock<ICoachService>();
            var result = serviceMock.Setup(a => a.AddCoach(coach));
            Assert.IsNotNull(result);

            //SwimmersController controller = new SwimmersController(serviceMock.Object);
            //SwimmerDTO swimmer = new SwimmerDTO();
            //var result = controller.Create(swimmer);

            //var ex = Assert.Throws<InvalidOperationException>(() => result.());

            //Program program = new Program();
            //var ex = Assert.ThrowsException<Exception>(() => program.StringAppend("Michael", "Jackson"));
            //Assert.AreSame(ex.Message, "Test Exception");
        }
        [Test]
        public void Test6()
        {
            CoachDTO coach = new CoachDTO
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };
            
            var serviceMock = new Mock<ICoachService>();
            serviceMock.Setup(a => a.AddCoach(coach));
            CoachesController controller = new CoachesController(serviceMock.Object);
            var result = controller.Create(coach);
            //var result = serviceMock.Setup(a => a.AddCoach(coach));
            //Assert.Throws<InvalidOperationException>(() => serviceMock.Setup(a => a.AddCoach(coach)));
            serviceMock.Verify(m => m.AddCoach(coach), Times.Once);

        }
    }
    
}