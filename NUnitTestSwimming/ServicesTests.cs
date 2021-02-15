using ADO.BL.Interfaces;
using DTO.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestSwimming
{
    public class ServicesTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void SwimmerService_Result_NotNull()
        {
            //arrange

            var serviceMock = new Mock<ISwimmerService>();

            var result = serviceMock.Setup(a => a.SelectSwimmers());


            Assert.IsNotNull(result);
        }
        [Test]
        public void CoachService_AddingCoach_NotNull()
        {
            //arrange

            CoachDTO coach = new CoachDTO()
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };
            var serviceMock = new Mock<ICoachService>();
            var result = serviceMock.Setup(a => a.AddCoach(coach));
            Assert.IsNotNull(result);


        }
        [Test]
        public void CoachService_SelectCoach_NotNull()
        {
            //arrange

            //var coach = new CoachDTO();

            //var serviceMock = new Mock<ICoachService>();
            //serviceMock.Setup(a => a.SelectCoaches());

            ////var viewResult = Is.TypeOf<CoachDTO>();
            ////Assert.That(result, viewResult);
            ////assert
            ////Assert.IsInstanceOf<CoachDTO>(result);
            //var result = controller.Index();
            //var viewResult = Is.TypeOf<ViewResult>();
            //Assert.That(result, viewResult);


            ////act
            //var result = controller.Index();
            //var viewResult = Is.TypeOf<ViewResult>();
            //Assert.That(result, viewResult);
            CoachDTO coach = new CoachDTO()
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };
            var serviceMock = new Mock<ICoachService>();
            var result = serviceMock.Setup(a => a.AddCoach(coach));

            //act
            //var viewResult = Is.TypeOf<CoachDTO>();
            //Assert.That(result, viewResult);

            //var viewResult = Is.TypeOf<ViewResult>();
            //Assert.That(result, viewResult);
            //assert
            Assert.IsInstanceOf<CoachDTO>(result);

        }

    }
}
