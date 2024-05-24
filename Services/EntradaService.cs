using ContasFrontEnd.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ContasFrontEnd.Services;

public class EntradaService : BaseService, IEntradaService
{
    private readonly string _urlPath = "api/Entradas";

    public EntradaService(HttpClient httpClient) : base(httpClient) { }



    public async Task<List<Entrada>> GetAll()
    {
        List<Entrada> entradas = new List<Entrada>();

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlPath);
            response.EnsureSuccessStatusCode();
            string responseText = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Entrada>>(responseText);
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }

        return entradas;
    }

    public async Task<HttpResponseMessage> Create(Entrada entrada)
    {
        HttpResponseMessage response = new HttpResponseMessage();

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        try
        {
            response = await _httpClient.PostAsJsonAsync(_urlPath, entrada);
            string responseText = response.Content.ReadAsStringAsync().Result;

        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }
        return response;
    }

    public async Task<Entrada> GetById(int id)
    {
        Entrada entrada = new Entrada();

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlPath + "/" + id);
            string responseText = response.Content.ReadAsStringAsync().Result;
            var conversao = JsonConvert.DeserializeObject<Entrada>(responseText);
            if (conversao != null)
                entrada = conversao;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }

        return entrada;
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
}
