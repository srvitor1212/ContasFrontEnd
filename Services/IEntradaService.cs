using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IEntradaService
    {
        Task<List<Entrada>> GetAll();
        Task<Entrada> Create(Entrada entrada);
    }
}
