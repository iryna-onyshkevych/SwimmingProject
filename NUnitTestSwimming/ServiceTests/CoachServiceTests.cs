using ADO.BL.Interfaces;
using ADO.BL.Services;
using DTO.Models;
using Moq;
using NUnit.Framework;
using Swimming.Abstractions.Interfaces;
using Swimming.Abstractions.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace NUnitTestSwimming.ServiceTests
{
    public class CoachServiceTests
    {
        [Test]
        public void CoachService_AddingCoach_ShouldNotNull()
        {
            //arrange

            CoachDTO coach = new CoachDTO()
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };
            var serviceMock = new Mock<ICoachService>();

            //act
            var result = serviceMock.Setup(a => a.AddCoach(coach));

            //assert 
            Assert.IsNotNull(result);
        }

        [Test]
        public void CoachService_DeletingCoach_ShouldNotNull()
        {
            //arrange
            int id = 1;
            var serviceMock = new Mock<ICoachService>();

            //act
            var result = serviceMock.Setup(a => a.DeleteCoach(id));

            //assert
            Assert.IsNotNull(result);
            //Assert.IsNull(result);
        }

        [Test]
        public void CoachService_AddingCoach_Once()
        {
            //arrange
            CoachDTO coach = new CoachDTO()
            {
                FirstName = "new",
                LastName = "coach",
                WorkExperience = 11

            };
            var serviceMock = new Mock<ICoachService>();

            //act
            serviceMock.Object.AddCoach(coach);

            //assert
            serviceMock.Verify(m => m.AddCoach(coach), Times.Once);
            //serviceMock.Verify(m => m.AddCoach(coach), Times.Exactly(3));
        }
        [Test]
        public void SelectCoaches_AreEqual()
        {
            // arrange
            var mock = new Mock<ICoachService>();
            IEnumerable<CoachDTO> coach = new List<CoachDTO>();

            // act
            var result = mock.Object.SelectCoaches();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, coach);
        }

        [Test]
        public void CoachDTO_Create_TypeCheck()
        {
            //arrange
            string typeName = "CoachDTO";
            // act
            CoachDTO coach = new CoachDTO();
            //assert
            Assert.AreEqual(typeName, coach.GetType().Name);
        }

        [Test]
        public void GetCoachesShouldReturnList()
        {
            //Arrange
            List<CoachDTO> list = new List<CoachDTO>();
            list.Add(new CoachDTO { Id = 1,  FirstName = "ff", LastName = "jj", WorkExperience =2});
            list.Add(new CoachDTO { Id = 2, FirstName = "ll", LastName = "kk", WorkExperience = 3 });
        

            string jsonString = JsonSerializer.Serialize(list);

            List<Coach> temp = new List<Coach>();
            temp.Add(new Coach { Id = 1, FirstName = "ff", LastName = "jj", WorkExperience = 2 });
            temp.Add(new Coach { Id = 2, FirstName = "ll", LastName = "kk", WorkExperience = 3 });

            var mock = new Mock<ICoachManager<Coach>>();
            var getCustomers = new CoachService(mock.Object);
            mock.Setup(x => x.GetList()).Returns(temp);


            //Act
            var result = getCustomers.SelectCoaches();
            string jsonString2 = JsonSerializer.Serialize(result);


            //Assert
            Assert.AreEqual(jsonString, jsonString2);
        }

        
    }
}
