using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using FluentAssertions;
using JustFakeIt;
using NUnit.Framework;
using APIClient;
using APIClient.Exceptions;
using FluentAssertions.Common;

namespace JETEST
{
    public class ApiClientTests
    {
        [Test]
        public void APiClientValidRequestReturnsListOfRestaurants()
        {
            using (var fakeServer = new FakeServer(12354))
            {
                var client = new ApiClient(GetConfig());
                string json = GetFakeResponse();
                fakeServer.Expect.Get("/LG5").Returns(json);
                fakeServer.Start();

                var result = client.GetFromApi("LG5");
                result.Restaurants.First().Name.Should().Be("restaurant1");
                result.Restaurants.First().RatingStars.Should().Be(4.5);
                result.Restaurants.First().CuisineTypes.First().Name.Should().Be("cuisine1");
                result.Restaurants.First().CuisineTypes.First().SeoName.Should().Be("Seo1");
                result.Restaurants.First().CuisineTypes[1].Name.Should().Be("cuisine2");
                result.Restaurants.First().CuisineTypes[1].SeoName.Should().Be("Seo2");

                result.Restaurants[1].Name.Should().Be("restaurant2");
                result.Restaurants[1].RatingStars.Should().Be(3.0);
                result.Restaurants[1].CuisineTypes.First().Name.Should().Be("cuisine3");
                result.Restaurants[1].CuisineTypes.First().SeoName.Should().Be("Seo3");
            }
        }

        [Test]
        public void APiClientInvalidPostCodeReturnsInvalidPostCodeException()
        {
            using (var fakeServer = new FakeServer(12354))
            {
                var client = new ApiClient(GetConfig());
                string json = GetFakeResponse();
                fakeServer.Expect.Get("/123").Returns(json);
                fakeServer.Start();

              Action a = () =>  client.GetFromApi("123");

                a.ShouldThrow<InvalidPostCodeException>();
            }
        }

        [Test]
        public void ApiClientFailedRequestReturnsWebException()
        {
            using (var fakeServer = new FakeServer(12354))
            {
                var client = new ApiClient(GetConfig());
                string json = GetFakeResponse();
                fakeServer.Expect.Get("LG5").Returns(HttpStatusCode.BadRequest);
                fakeServer.Start();

                Action a = () => client.GetFromApi("LG5");

                a.ShouldThrow<WebException>();
            }
        }

        public string GetFakeResponse()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = path.Combine("/FakeResponse.json");
            return File.ReadAllText(path.Combine("/FakeResponse.json"));
        }

        public IApiConfig GetConfig()
        {
            return new ApiConfig { BaseUri = "http://localhost:12354" };
        }
  

    }
}
