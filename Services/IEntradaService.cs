using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IEntradaService
    {
        Task<List<Entrada>> GetAll();
        Task<HttpResponseMessage> Create(Entrada entrada);
        Task<Entrada> GetById(int id);
    }
}
