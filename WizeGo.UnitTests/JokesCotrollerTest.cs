using Xunit;
using WizeGo.APi.Controllers;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;
using WizeGo.APi.Interfaces;
using WizeGo.APi.Models;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace WizeGo.UnitTests
{
    public class JokesControllerTest
    {
        private readonly Mock<ILogger<JokesController>> loggerStub = new();
        private readonly Mock<IJokesService> jokerStub = new();

        [Fact]
        public async Task GetJoke_NoAvailableJokes_ReturnsNotFound()
        {
            var resultJoke = new Jokes{
              Id = 0
            };
            jokerStub.Setup( j => j.GetJoke("")).ReturnsAsync(resultJoke);
            var controller = new JokesController(jokerStub.Object,loggerStub.Object);
            var result = await controller.GetJoke("");
            result.Result.Should().BeOfType<NotFoundResult>();
        }
        [Fact]
        public async Task GetJoke_ReceiveJoke_ReturnsAJoke()
        {
            var resultJoke = new Jokes{
              Id = 24,
              Setup = "Joke",
              Punchline = "End"
            };
            jokerStub.Setup( j => j.GetJoke("")).ReturnsAsync(resultJoke);
            var controller = new JokesController(jokerStub.Object,loggerStub.Object);
            var result = await controller.GetJoke("");   
            result.Result.Should().BeOfType<OkObjectResult>();       
        }
    }
}