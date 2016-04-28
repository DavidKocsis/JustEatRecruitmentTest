using System;
using System.Net;
using System.Text.RegularExpressions;
using APIClient.Exceptions;
using Newtonsoft.Json;

namespace APIClient
{
    public class ApiClient : IApiClient
    {
        private readonly WebClient _client = new WebClient();
        private string _baseUri;

        public ApiClient(IApiConfig config)
        {
            _baseUri = config.BaseUri;
            foreach (var header in config.headerValues)
            {
                _client.Headers.Add(header.Key,header.Value);
            }
        }


        public  Result GetFromApi(string postCode)
        {
            if (ValidatePostCode(postCode))
            {
                var result = _client.DownloadString(new Uri(_baseUri + "/" + postCode));

                
                return JsonConvert.DeserializeObject<Result>(result);
            }
            throw new InvalidPostCodeException("Invalid Postcode");
        }

        private bool ValidatePostCode(string postCode)
        {
            var postcodePattern = "^([A-Z]{1,2})([0-9][0-9A-Z]?)";

            var preg = new Regex(postcodePattern, RegexOptions.IgnoreCase);

           return preg.IsMatch(postCode);
        }

    }

 
    }
