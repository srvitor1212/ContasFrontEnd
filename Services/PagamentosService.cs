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

        using (var api = _httpClient)
        {
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            try
            {
                HttpResponseMessage response = await api.GetAsync(_urlPath);
                string responseText = response.Content.ReadAsStringAsync().Result;
                var conversao = JsonConvert.DeserializeObject<List<Pagamentos>>(responseText);
                if (conversao != null)
                    pagamentos = conversao;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR api: {e}");
            }
        }
        return pagamentos;
    }
}
