namespace ContasFrontEnd.Services;

public interface ICommonService<Tipo>
{
    Task<List<Tipo>> GetAll();

    Task<HttpResponseMessage> Create(Tipo obj);

    Task<HttpResponseMessage> Delete(int id);

    Task<Tipo> GetById(int id);
}
