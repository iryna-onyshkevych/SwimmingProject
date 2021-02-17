using ADO.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SwimmingWebApp.Controllers;

namespace NUnitTestSwimming.ControllerTests
{
    public class TrainingControllerTests
    {
        [Test]
        public void TrainingController_Result_NotNull()
        {
            //arrange
            int page = 1;
            var serviceMock = new Mock<ITrainingViewService>();
            serviceMock.Setup(a => a.SelectSwimmersTrainings());
            TrainingController controller = new TrainingController(serviceMock.Object);

            //act
            var result = controller.Index(page);

            //assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void TrainingContoller_InstanceofViewResult()
        {
            //arrange
            int page = 1;
            var serviceMock = new Mock<ITrainingViewService>();
            serviceMock.Setup(a => a.SelectSwimmersTrainings());
            TrainingController controller = new TrainingController(serviceMock.Object);

            //act
            var result = controller.Index(page);
            var viewResult = Is.TypeOf<ViewResult>();

            //assert
            Assert.That(result, viewResult);
        }
    }
}
