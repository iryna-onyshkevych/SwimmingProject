using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SwimmingWebApp.Controllers;

namespace NUnitTestSwimming.ControllerTests
{
    public class CoachControllerTests
    {
        //[Test]
        //public void CoachController_Result_NotNull()
        //{
        //    //arrange

        //    var serviceMock = new Mock<ICoachService>();
        //    serviceMock.Setup(a => a.SelectCoaches());
        //    CoachController controller = new CoachController(serviceMock.Object);

        //    var result = controller.Index();

        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void CoachController_Verify_AddingCalledOnce()
        //{
        //    //arrange
        //    CoachDTO coach = new CoachDTO()
        //    {
        //        FirstName = "new",
        //        LastName = "coach",
        //        WorkExperience = 11

        //    };
        //    var serviceMock = new Mock<ICoachService>();
        //    serviceMock.Setup(a => a.AddCoach(coach));
        //    CoachController controller = new CoachController(serviceMock.Object);

        //    //act
        //    var result = controller.Create(coach);

        //    //assert
        //    serviceMock.Verify(m => m.AddCoach(coach), Times.Once);
        //}

        //[Test]
        //public void CoachController_Verify_Delete()
        //{
        //    // arrange
        //    int id = 1;
        //    var serviceMock = new Mock<ICoachService>();
        //    CoachController controller = new CoachController(serviceMock.Object);

        //    // act
        //    IActionResult result = controller.Delete(id) as IActionResult;

        //    // assert
        //    serviceMock.Verify(a => a.DeleteCoach(id));
        //}

        //[Test]
        //public void CoachContoller_InstanceofViewResult()
        //{
        //    //arrange
        //    var serviceMock = new Mock<ICoachService>();
        //    serviceMock.Setup(a => a.SelectCoaches());
        //    CoachController controller = new CoachController(serviceMock.Object);

        //    //act
        //    var result = controller.Index();
        //    var viewResult = Is.TypeOf<ViewResult>();

        //    //assert
        //    Assert.That(result, viewResult);

        //    //assert
        //    //Assert.IsInstanceOf<ViewResult>(result);
        //}
    }
}
