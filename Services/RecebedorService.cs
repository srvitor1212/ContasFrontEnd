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

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        try
        {
            response = await _httpClient.PostAsJsonAsync(_urlPath, recebedor);
            string responseText = response.Content.ReadAsStringAsync().Result;

        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }
        return response;
    }

    public async Task<HttpResponseMessage> Delete(int id)
    {
        HttpResponseMessage response = new HttpResponseMessage();

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));

        try
        {
            response = await _httpClient.DeleteAsync(_urlPath + "?id=" + id);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }

        return response;
    }

    public async Task<List<Recebedor>> GetAll()
    {
        List<Recebedor> recebedores = new List<Recebedor>();


        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlPath);
            string responseText = response.Content.ReadAsStringAsync().Result;
            var conversao = JsonConvert.DeserializeObject<List<Recebedor>>(responseText);
            if (conversao != null)
                recebedores = conversao;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }

        return recebedores;
    }

    public async Task<Recebedor> GetById(int id)
    {
        Recebedor recebedor = new Recebedor();

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlPath + "/" + id);
            string responseText = response.Content.ReadAsStringAsync().Result;
            var conversao = JsonConvert.DeserializeObject<Recebedor>(responseText);
            if (conversao != null)
                recebedor = conversao;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }

        return recebedor;
    }

}
