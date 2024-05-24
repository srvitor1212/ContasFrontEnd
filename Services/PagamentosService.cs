using ContasFrontEnd.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ContasFrontEnd.Services;

public class PagamentosService : BaseService, IPagamentosService
{
    private readonly string _urlPath = "api/Pagamentos";

    public PagamentosService(HttpClient httpClient) : base(httpClient) { }



    public async Task<List<Pagamentos>> GetAll()
    {
        List<Pagamentos> pagamentos = new List<Pagamentos>();


        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("text/plain"));

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlPath);
            string responseText = response.Content.ReadAsStringAsync().Result;
            var conversao = JsonConvert.DeserializeObject<List<Pagamentos>>(responseText);
            if (conversao != null)
                pagamentos = conversao;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR api: {e}");
        }

        return pagamentos;
    }
}
