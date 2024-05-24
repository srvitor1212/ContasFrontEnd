using ContasFrontEnd.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ContasFrontEnd.Services;

public class RecebedorService : BaseService, IRecebedorService
{
    private readonly string _urlPath = "api/Recebedores";

    public RecebedorService(HttpClient httpClient) : base(httpClient) { }



    public async Task<HttpResponseMessage> Create(Recebedor recebedor)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        using (var api = _httpClient)
        {
            api.DefaultRequestHeaders.Accept.Clear();
            try
            {
                response = await api.PostAsJsonAsync(_urlPath, recebedor);
                string responseText = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR api: {e}");
            }
        }
        return response;
    }

    public async Task<HttpResponseMessage> Delete(int id)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        using (var api = _httpClient)
        {
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            try
            {
                response = await api.DeleteAsync(_urlPath + "?id=" + id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR api: {e}");
            }
        }

        return response;
    }

    public async Task<List<Recebedor>> GetAll()
    {
        List<Recebedor> recebedores = new List<Recebedor>();

        using (var api = _httpClient)
        {
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            try
            {
                HttpResponseMessage response = await api.GetAsync(_urlPath);
                string responseText = response.Content.ReadAsStringAsync().Result;
                var conversao = JsonConvert.DeserializeObject<List<Recebedor>>(responseText);
                if (conversao != null)
                    recebedores = conversao;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR api: {e}");
            }
        }

        return recebedores;

    }

    public async Task<Recebedor> GetById(int id)
    {
        {
            Recebedor recebedor = new Recebedor();

            using (var api = _httpClient)
            {
                api.DefaultRequestHeaders.Accept.Clear();
                api.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("text/plain"));

                try
                {
                    HttpResponseMessage response = await api.GetAsync(_urlPath + "/" + id);
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    var conversao = JsonConvert.DeserializeObject<Recebedor>(responseText);
                    if (conversao != null)
                        recebedor = conversao;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR api: {e}");
                }
            }

            return recebedor;
        }
    }

}
