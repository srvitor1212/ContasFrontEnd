namespace ContasFrontEnd.Services.Interface;

public interface ICommonService<Tipo>
{
    Task<List<Tipo>> GetAll();

    Task<HttpResponseMessage> Create(Tipo obj);

    Task<HttpResponseMessage> Delete(int id);

    Task<Tipo> GetById(int id);
}
