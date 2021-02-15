using ADO.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SwimmingWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestSwimming.ControllerTests
{
    public class TrainingControllerTests
    {
        [Test]
        public void TrainingController_Result_NotNull()
        {
            //arrange

            var serviceMock = new Mock<ITrainingViewService>();
            serviceMock.Setup(a => a.SelectSwimmersTrainings());
            TrainingController controller = new TrainingController(serviceMock.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TrainingContoller_InstanceofViewResult()
        {
            //arrange
            var serviceMock = new Mock<ITrainingViewService>();
            serviceMock.Setup(a => a.SelectSwimmersTrainings());
            TrainingController controller = new TrainingController(serviceMock.Object);

            //act
            var result = controller.Index();
            var viewResult = Is.TypeOf<ViewResult>();

            //assert
            Assert.That(result, viewResult);

            //assert
            //Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
