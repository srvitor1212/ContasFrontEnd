namespace ContasFrontEnd.Services
{
    public class BaseService
    {
        public string BaseURL { get; private set; } = "https://contaswebapi.azurewebsites.net/";

        // https://localhost:5001/
        // https://contaswebapi.azurewebsites.net/
    }
}
