using System.Collections.Generic;

namespace APIClient
{
    public interface IApiConfig
    {
        string BaseUri { get; set; }
        Dictionary<string, string> headerValues { get;}
    }
}