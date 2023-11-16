using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using NostedServicePro.Controllers;
using NostedServicePro.Models.Account;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using NostedServiceProTest;


[TestFixture]
public class AccountControllerTests
{
    [Test]
    public async Task Login_InvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var userManagerMock = new Mock<UserManager<IdentityUser>>(
            new Mock<IUserStore<IdentityUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<IdentityUser>>().Object,
            new IUserValidator<IdentityUser>[0],
            new IPasswordValidator<IdentityUser>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<IdentityUser>>>().Object);

        var signInManagerMock = new Mock<SignInManager<IdentityUser>>(
            userManagerMock.Object,
            new Mock<IHttpContextAccessor>().Object,
            new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
            new Mock<IAuthenticationSchemeProvider>().Object,
            new Mock<IUserConfirmation<IdentityUser>>().Object
        );

        var emailSenderMock = new Mock<IEmailSender>();
        var loggerFactoryMock = new Mock<ILoggerFactory>();

        var controller = new AccountController(userManagerMock.Object, signInManagerMock.Object, emailSenderMock.Object, loggerFactoryMock.Object);
        var loginViewModel = new LoginViewModel { UserName = "invalidUser", Password = "invalidPassword", RememberMe = false };
        controller.ModelState.AddModelError("key", "error message");

        // Act
        var result = await controller.Login(loginViewModel, "returnUrl");

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        Assert.AreEqual(loginViewModel, ((ViewResult)result).Model);
    }


}

