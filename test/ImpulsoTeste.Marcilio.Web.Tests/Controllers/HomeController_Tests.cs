using System.Threading.Tasks;
using ImpulsoTeste.Marcilio.Models.TokenAuth;
using ImpulsoTeste.Marcilio.Web.Controllers;
using Shouldly;
using Xunit;

namespace ImpulsoTeste.Marcilio.Web.Tests.Controllers
{
    public class HomeController_Tests: MarcilioWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}