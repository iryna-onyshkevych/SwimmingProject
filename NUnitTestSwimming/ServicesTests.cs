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
            var serviceMock = new Mock<ISwimmerService>();

            var result = serviceMock.Setup(a => a.SelectSwimmers());


            Assert.IsNotNull(result);
        }
        [Test]
        public void CoachService_AddingCoach_NotNull()
        {
            CoachDTO coach = new CoachDTO()
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

    }
}
