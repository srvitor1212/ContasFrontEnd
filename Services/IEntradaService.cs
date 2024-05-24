using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IEntradaService
    {
        Task<List<Entrada>> GetAll();

        Task<HttpResponseMessage> Create(Entrada obj);

        Task<HttpResponseMessage> Delete(int id);

        Task<Entrada> GetById(int id);
    }
}
