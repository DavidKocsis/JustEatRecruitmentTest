using System.Collections.Generic;
using APIClient;
using APIClient.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;
using ConsoleApp;

namespace JETEST
{
    internal class ResultFormatterTests
    {
        [Test]
        public void ResultFormatterFormatsApiResultCorrectly()
        {
            var fakeApiClient = MockRepository.GenerateMock<IApiClient>();
            var resultFormatter = new ResultFormatter(fakeApiClient);
            fakeApiClient.Expect(x => x.GetFromApi(Arg<string>.Is.Anything)).Return(CreateResult());
            var result = resultFormatter.CreateConsoleOutput("LG5");
            result.Should().Be("Name: restaurant1\r\nRating: 4.5\r\nCuisines: \r\ncuisine 1\r\n---------------------------------------------------------\r\n");
        }

        [Test]
        public void ResultFormatterReturnsCorrectMessageWhenExceptionIsThrown()
        {
            var fakeApiClient = MockRepository.GenerateMock<IApiClient>();
            var resultFormatter = new ResultFormatter(fakeApiClient);
            fakeApiClient.Expect(x => x.GetFromApi(Arg<string>.Is.Anything)).Throw(new InvalidPostCodeException(""));
            var result = resultFormatter.CreateConsoleOutput("LG5");
            result.Should().Be("something's gone wrong");
        }

        public Result CreateResult()
        {
            return new Result{Restaurants = new List<Restaurant>{
                                                            new Restaurant
                                                            {
                                                                CuisineTypes = new List<Cusinies>{new Cusinies{Name = "cuisine 1"}},
                                                                Name = "restaurant1",
                                                                RatingStars = 4.5
                                                            }}};
        }
    }
}
