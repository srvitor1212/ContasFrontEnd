using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services;

public class EntradaService : BaseService<Entrada>, IEntradaService
{
    public EntradaService(HttpClient httpClient) : base(httpClient, "api/Entradas") 
    { 
    }
}
