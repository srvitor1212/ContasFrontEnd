namespace ContasFrontEnd.Services
{
    public class BaseService
    {
        public string BaseURL()
        {
            var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (ambiente.Equals("Production", StringComparison.OrdinalIgnoreCase))
                return "https://contaswebapi.azurewebsites.net/";
            else
                return "https://localhost:5001/";
        }
    }
}
