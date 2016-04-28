using System;
using System.IO;
using APIClient;

namespace ConsoleApp
{
    public class ResultFormatter
    {
        IApiClient _apiClient;
        public ResultFormatter(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public string CreateConsoleOutput(string postcode)
        {
            try
           {
          var result =  _apiClient.GetFromApi(postcode);
            var stringWriter = new StringWriter();
                foreach (var restaurant in result.Restaurants)
                {
                    stringWriter.WriteLine("Name: " + restaurant.Name);
                    stringWriter.WriteLine("Rating: " + restaurant.RatingStars);
                    stringWriter.WriteLine("Cuisines: ");
                    foreach (var cuisine in restaurant.CuisineTypes)
                    {
                        stringWriter.WriteLine(cuisine.Name);
                    }
                    stringWriter.WriteLine("---------------------------------------------------------");
                }

                return stringWriter.ToString();
            }
            catch (Exception ex)
            {
                return "something's gone wrong";
            }
        }
    }
}
