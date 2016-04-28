using System.Collections.Generic;

namespace APIClient
{
   public class ApiConfig : IApiConfig
   {
        public string BaseUri { get; set;}
        public Dictionary<string, string> headerValues {
             get{ return new Dictionary<string, string>{  
                    {"Accept-Tenant", "uk"},
                    {"Accept-Language", "en-GB"},
                    {"Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI="},
                    {"Host", "public.je-apis.com"}
             };
        }
        }

    }
}
