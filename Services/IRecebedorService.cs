using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IRecebedorService
    {
        Task<List<Recebedor>> GetAll();
        Task<HttpResponseMessage> Create(Recebedor recebedor);
        Task<Recebedor> GetById(int id);
        Task<HttpResponseMessage> Delete(int id);
    }
}
