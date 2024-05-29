using ContasFrontEnd.Model;
using ContasFrontEnd.Services.Interface;

namespace ContasFrontEnd.Services;

public class DividasService : BaseService<Dividas>, IDividasService
{
    public DividasService(HttpClient httpClient) : base(httpClient, "api/Dividas")
    {
    }
}
