using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NostedServicePro.Models;
using NUnit.Framework;

namespace NostedServiceProTest.Controllers
{
    [TestFixture]
    public class BrukerControllerTests
    {
        private Mock<ILogger<BrukerController>> loggerMock;
        private Mock<UserManager<IdentityUser>> userManagerMock;
        private Mock<RoleManager<IdentityRole>> roleManagerMock;

        [SetUp]
        public void Setup()
        {
            loggerMock = new Mock<ILogger<BrukerController>>();
            userManagerMock = new Mock<UserManager<IdentityUser>>(
                new Mock<IUserStore<IdentityUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<IdentityUser>>().Object,
                new IUserValidator<IdentityUser>[0],
                new IPasswordValidator<IdentityUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<IdentityUser>>>().Object);

            roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                new Mock<IRoleStore<IdentityRole>>().Object,
                new IRoleValidator<IdentityRole>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<ILogger<RoleManager<IdentityRole>>>().Object);
        }

        [Test]
        public async Task VisAlleBrukere_ShouldReturnViewWithBrugerMedRollerList()
        {
            // Arrange
            var brukere = new List<IdentityUser>
            {
                new IdentityUser { Id = "1", UserName = "user1", Email = "user1@example.com" },
                new IdentityUser { Id = "2", UserName = "user2", Email = "user2@example.com" }
            };

            var rollerForUser1 = new List<string> { "Role1", "Role2" };
            var rollerForUser2 = new List<string> { "Role3", "Role4" };

            userManagerMock.Setup(m => m.Users).Returns(brukere.AsQueryable());

            userManagerMock.Setup(m => m.GetRolesAsync(It.Is<IdentityUser>(u => u.Id == "1")))
                           .ReturnsAsync(rollerForUser1);

            userManagerMock.Setup(m => m.GetRolesAsync(It.Is<IdentityUser>(u => u.Id == "2")))
                           .ReturnsAsync(rollerForUser2);

            var brukerController = new BrukerController(userManagerMock.Object, loggerMock.Object, roleManagerMock.Object);

            // Act
            var result = await brukerController.VisAlleBrukere();

            // Assert
            Assert.IsTrue(result is ViewResult);

            var viewResult = result as ViewResult;
            Assert.IsInstanceOf<List<BrukerMedRollerViewModel>>(viewResult.Model);

            var model = viewResult.Model as List<BrukerMedRollerViewModel>;
            Assert.AreEqual(2, model.Count);

            // Add additional assertions based on your expected model values
            Assert.AreEqual("1", model[0].UserId);
            Assert.AreEqual("user1", model[0].UserName);
            Assert.AreEqual("user1@example.com", model[0].Email);
            Assert.AreEqual(rollerForUser1, model[0].Roller);

            Assert.AreEqual("2", model[1].UserId);
            Assert.AreEqual("user2", model[1].UserName);
            Assert.AreEqual("user2@example.com", model[1].Email);
            Assert.AreEqual(rollerForUser2, model[1].Roller);
        }
    }
}
