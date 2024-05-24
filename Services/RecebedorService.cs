using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services;

public class RecebedorService : BaseService<Recebedor>, IRecebedorService
{
    public RecebedorService(HttpClient httpClient) : base(httpClient, "api/Recebedores")
    {
    }
}