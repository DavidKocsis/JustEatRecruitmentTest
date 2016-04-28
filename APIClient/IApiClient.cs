namespace APIClient
{
    public interface IApiClient
    {
        Result GetFromApi(string postcode);
    }
}