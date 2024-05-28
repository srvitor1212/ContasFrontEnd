using ContasFrontEnd.Model;
using ContasFrontEnd.Services.Interface;

namespace ContasFrontEnd.Services;

public class RecebedorService : BaseService<Recebedor>, IRecebedorService
{
    public RecebedorService(HttpClient httpClient) : base(httpClient, "api/Recebedores")
    {
    }
}