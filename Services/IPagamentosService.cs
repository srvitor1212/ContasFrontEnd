using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IPagamentosService
    {
        Task<List<Pagamentos>> GetAll();
    }
}

