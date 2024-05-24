namespace ContasFrontEnd.Services
{
    public class BaseService
    {

        public string BaseURL { 
            get {
                var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                if (ambiente != null && ambiente.Equals("Production", StringComparison.OrdinalIgnoreCase))
                    return "https://contaswebapi.azurewebsites.net/";
                else
                    return "https://localhost:5001/";
            } 
            private set { } 
        }
    }
}
