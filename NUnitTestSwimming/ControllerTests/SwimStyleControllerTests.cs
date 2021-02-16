using ADO.BL.Interfaces;
using DTO.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SwimmingWebApp.Controllers;

namespace NUnitTestSwimming.ControllerTests
{
    public class SwimStyleControllerTests
    {
        [Test]
        public void SwimStyleController_Result_NotNull()
        {
            //arrange

            var serviceMock = new Mock<ISwimStyleService>();
            serviceMock.Setup(a => a.SelectSwimStyles());
            SwimStyleController controller = new SwimStyleController(serviceMock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void SwimStyleController_Verify_AddingCalledOnce()
        {
            //arrange
            SwimStyleDTO swimStyle = new SwimStyleDTO()
            {
                StyleName = "newStyle"
            };

            var serviceMock = new Mock<ISwimStyleService>();
            serviceMock.Setup(a => a.AddSwimStyle(swimStyle));
            SwimStyleController controller = new SwimStyleController(serviceMock.Object);

            //act
            var result = controller.Create(swimStyle);

            //assert
            serviceMock.Verify(m => m.AddSwimStyle(swimStyle), Times.Once);
        }

        [Test]
        public void SwimStyleController_Verify_Delete()
        {
            // arrange
            int id = 250;
            var serviceMock = new Mock<ISwimStyleService>();
            serviceMock.Setup(a => a.DeleteSwimStyle(id));
            SwimStyleController controller = new SwimStyleController(serviceMock.Object);

            // act
            IActionResult result = controller.Delete(id) as IActionResult;

            // assert
            serviceMock.Verify(a => a.DeleteSwimStyle(id));
        }

        [Test]
        public void SwimStyleContoller_InstanceofViewResult()
        {
            //arrange
            var serviceMock = new Mock<ISwimStyleService>();
            serviceMock.Setup(a => a.SelectSwimStyles());
            SwimStyleController controller = new SwimStyleController(serviceMock.Object);

            //act
            var result = controller.Index();
            var viewResult = Is.TypeOf<ViewResult>();

            //assert
            Assert.That(result, viewResult);
        }
    }
}
