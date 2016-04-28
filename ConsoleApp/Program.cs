using System;
using System.Collections.Generic;
using System.Linq;
using APIClient;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter postCode: ");
            var apiClient = new ApiClient(new ApiConfig { BaseUri = "https://public.je-apis.com/restaurants?q=" });
            var formatter = new ResultFormatter(apiClient);
            Console.WriteLine(formatter.CreateConsoleOutput(Console.ReadLine()));
        }
    }
}
