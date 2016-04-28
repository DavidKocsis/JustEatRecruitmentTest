using System.Collections.Generic;

namespace APIClient
{
    public class Restaurant
    {
        public string Name { get; set; }
        public double RatingStars { get; set; } 
        public List<Cusinies> CuisineTypes {get; set; } 
    }

    public class Cusinies
    {
        public string Name { get; set; }
        public string SeoName { get; set; }
    }

    public class Result
    {
        public List<Restaurant> Restaurants { get; set; } 
    }
}

