using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NostedServiceProTest
{
    public class MockUserManager : UserManager<IdentityUser>
    {
        private readonly ILogger<UserManager<IdentityUser>> _logger;

        public MockUserManager(
            IUserStore<IdentityUser> store,
            IOptions<IdentityOptions> options,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<IdentityUser>> logger)
            : base(
                store,
                options,
                passwordHasher,
                userValidators,
                passwordValidators,
                keyNormalizer,
                errors,
                services,
                logger)
        {
            _logger = logger;
        }

        public override Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityResult> AddToRoleAsync(IdentityUser user, string role)
        {
            return Task.FromResult(IdentityResult.Success);
        }

        public void SetFindByNameAsync(IdentityUser user)
        {
            ((Mock<IUserStore<IdentityUser>>)Store).Setup(u => u.FindByNameAsync(user.UserName, default)).ReturnsAsync(user);
        }

        public void SetPasswordSignInAsync(IdentityUser user, string password, bool isPersistent, bool lockoutOnFailure, SignInResult signInResult)
        {
            var signInManagerMock = new Mock<SignInManager<IdentityUser>>(
                this,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                null,
                null,
                null,
                null,
                null,
                null);

            signInManagerMock.Setup(s => s.PasswordSignInAsync(user.UserName, password, isPersistent, lockoutOnFailure)).ReturnsAsync(signInResult);

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(x => x.GetService(typeof(SignInManager<IdentityUser>))).Returns(signInManagerMock.Object);

            var mock = new Mock<MockUserManager>();
            mock.As<IServiceProvider>().Setup(x => x.GetService(typeof(SignInManager<IdentityUser>))).Returns(signInManagerMock.Object);
        }

    }
}
