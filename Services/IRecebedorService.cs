using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public interface IRecebedorService
    {
        Task<List<Recebedor>> GetAll();

        Task<HttpResponseMessage> Create(Recebedor obj);

        Task<HttpResponseMessage> Delete(int id);

        Task<Recebedor> GetById(int id);
    }
}
