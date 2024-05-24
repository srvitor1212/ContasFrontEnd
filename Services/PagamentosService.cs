using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services;

public class PagamentosService : BaseService<Pagamentos>, IPagamentosService
{
    public PagamentosService(HttpClient httpClient) : base(httpClient, "api/Pagamentos")
    {
    }
}
