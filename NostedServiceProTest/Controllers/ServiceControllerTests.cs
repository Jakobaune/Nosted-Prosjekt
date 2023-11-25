using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NostedServicePro.Data;
using NUnit.Framework;


namespace NostedServiceProTest.Controllers
{

    [TestFixture]
    public class ServiceControllerTests
    {
        private readonly ServiceController _controller;
        private readonly ServiceProDbContex _dbContextMock;

        public ServiceControllerTests()
        {
            // Opprett en DbContextOptions for å konfigurere en in-memory database
            var options = new DbContextOptionsBuilder<ServiceProDbContex>()
                .UseInMemoryDatabase(databaseName: "ServiceProDbContexTest")
                .EnableSensitiveDataLogging()
                .Options;

            // Opprett en ekte instans av ServiceProDbContex med in-memory database
            _dbContextMock = new ServiceProDbContex(options);

            // Opprett en mock av IHttpContextAccessor for å tilfredsstille kontrollerens krav
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            // Opprett en ServiceController med den ekte DbContext-instansen
            _controller = new ServiceController(_dbContextMock)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContextAccessorMock.Object.HttpContext
                }
            };
        }

        [SetUp]
        public void Setup()
        {
            // Sett opp data som trengs for hver test her
            var serviceData = new List<ServiceOrdre>
    {
        new ServiceOrdre
        {
            OrdreID = 1,
            AvtaltKommentar = "Avtalt kommentar 1",
            InternKommentar = "Intern kommentar 1",
            Kundetlf = "12345678",
            Problembeskrivelse = "Problembeskrivelse 1",
            Produkttypevinsj = "Produkttypevinsj 1",
            Serienummervinsj = "Serienummervinsj 1",
            ServiceType = "ServiceType 1",
            Kundenavn = "Kunde1",
            Kundeepost = "kunde1@example.com",
            RegistreringFullførtAv = "Bruker1" // Legg til denne egenskapen
        },
        new ServiceOrdre
        {
            OrdreID = 2,
            AvtaltKommentar = "Avtalt kommentar 2",
            InternKommentar = "Intern kommentar 2",
            Kundetlf = "87654321",
            Problembeskrivelse = "Problembeskrivelse 2",
            Produkttypevinsj = "Produkttypevinsj 2",
            Serienummervinsj = "Serienummervinsj 2",
            ServiceType = "ServiceType 2",
            Kundenavn = "Kunde2",
            Kundeepost = "kunde2@example.com",
            RegistreringFullførtAv = "Bruker2" // Legg til denne egenskapen
        },
    };

            // Legg til testdata i in-memory databasen
            _dbContextMock.service.AddRange(serviceData);
            _dbContextMock.SaveChanges();
        }


        [Test]
        public void Edit_ShouldReturnViewWithModel()
        {
            // Arrange
            int ordreId = 2;

            // Act
            var result = _controller.Edit(ordreId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.IsNull(viewResult.ViewName); // Sjekk at riktig view returneres
            Assert.IsNotNull(viewResult.Model); // Sjekk at modellen er til stede
            Assert.IsInstanceOf<ServiceOrdre>(viewResult.Model); // Sjekk at modellen er av riktig type
        }






        [Test]
        public void RegistrerSjekkliste_ShouldReturnViewWithModel()
        {
            // Arrange
            int ordreId = 1;

            // Act
            var result = _controller.RegistrerSjekkliste(ordreId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.IsNull(viewResult.ViewName); // Sjekk at riktig view returneres
            Assert.IsNotNull(viewResult.Model); // Sjekk at modellen er til stede
            Assert.IsAssignableFrom<ServiceOrdre>(viewResult.Model); // Sjekk at modellen er av riktig type
        }








        [Test]
        public void Arkiv_ShouldReturnViewWithModel()
        {
            // Act
            var result = _controller.Arkiv(search: null, sortOrder: null);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.IsNull(viewResult.ViewName); // Sjekk at riktig view returneres
            Assert.IsNotNull(viewResult.Model); // Sjekk at modellen er til stede
            Assert.IsAssignableFrom<List<ServiceOrdre>>(viewResult.Model); // Sjekk at modellen er av riktig type
        }

        [Test]
        public void Print_ShouldReturnViewWithModel()
        {
            // Arrange
            int ordreId = 1;

            // Act
            var result = _controller.Print(ordreId);

            // Assert
            Assert.IsNotNull(result);

            if (result is ViewResult viewResult)
            {
                Assert.IsNull(viewResult.ViewName); // Sjekk at riktig view returneres
                Assert.IsNotNull(viewResult.Model); // Sjekk at modellen er til stede
                Assert.IsInstanceOf<ServiceOrdre>(viewResult.Model); // Sjekk at modellen er av riktig type
            }
            else if (result is NotFoundResult)
            {
                Assert.Fail("Serviceordre not found. Make sure ordreId is valid.");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType()}");
            }
        }


        [Test]
        public void Delete_ShouldReturnViewWithModel()
        {
            // Arrange
            int ordreId = 1;

            // Act
            var result = _controller.Delete(ordreId);

            // Assert
            Assert.IsNotNull(result);

            if (result is ViewResult viewResult)
            {
                Assert.IsNull(viewResult.ViewName); // Sjekk at riktig view returneres
                Assert.IsNotNull(viewResult.Model); // Sjekk at modellen er til stede
                Assert.IsInstanceOf<ServiceOrdre>(viewResult.Model); // Sjekk at modellen er av riktig type
            }
            else if (result is NotFoundResult)
            {
                Assert.Fail("Serviceordre not found. Make sure ordreId is valid.");
            }
            else
            {
                Assert.Fail($"Unexpected result type: {result.GetType()}");
            }
        }


        [Test]
        public void ServiceOversikt_ShouldReturnView()
        {
            // Act
            var result = _controller.ServiceOversikt();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void ServiceDetails_ShouldReturnView()
        {
            // Act
            var result = _controller.Details(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

            var viewResult = (ViewResult)result;
            Assert.IsNull(viewResult.ViewName); // Sjekk at riktig view returneres
            Assert.IsNotNull(viewResult.Model); // Sjekk at modellen er til stede

            var model = (ServiceOrdre)viewResult.Model;
        }

        [Test]
        public void Registrer_ShouldReturnView()
        {
            // Act
            var result = _controller.Registrer();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
