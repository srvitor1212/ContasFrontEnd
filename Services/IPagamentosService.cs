using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IPagamentosService
    {
        Task<List<Pagamentos>> GetAll();

        Task<HttpResponseMessage> Create(Pagamentos obj);

        Task<HttpResponseMessage> Delete(int id);

        Task<Pagamentos> GetById(int id);
    }
}

