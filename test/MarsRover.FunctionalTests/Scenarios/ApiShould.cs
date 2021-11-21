using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace MarsRover.Api.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class ApiShould
    {
        private readonly ServerFixture Given;

        public ApiShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_healthy()
        {
            var response = await Given
             .Server
             .CreateRequest("/")
             .GetAsync();
            await response.ShouldBe(StatusCodes.Status200OK);
            var result = await response.Content.ReadAsStringAsync();

            result.Should().Be("Welcome to Mars Rover api");
        }
    }
}
