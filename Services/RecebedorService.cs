using ContasFrontEnd.Model;

namespace ContasFrontEnd.Services
{
    public class RecebedorService : BaseService, IEntradaService
    {
        public Task<HttpResponseMessage> Create(Entrada entrada)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Entrada>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entrada> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
