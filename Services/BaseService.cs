using ContasFrontEnd.Services.Interface;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ContasFrontEnd.Services;

public class BaseService<Tipo> : ICommonService<Tipo>
{
    protected readonly HttpClient _httpClient;
    protected readonly string _urlPath;

    public BaseService(HttpClient httpClient, string urlPath)
    {
        _httpClient = httpClient;
        _urlPath = urlPath;
    }



    public async Task<List<Tipo>> GetAll()
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_urlPath);
            response.EnsureSuccessStatusCode();
            string responseText = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Tipo>>(responseText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO GetAll: {ex}");
            return new List<Tipo>();
        }
    }

    public async Task<HttpResponseMessage> Create(Tipo obj)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(_urlPath, obj);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO Create: {ex}");
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        }
    }

    public async Task<HttpResponseMessage> Delete(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(_urlPath + "?id=" + id);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO Delete: {ex}");
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        }
    }

    public async Task<Tipo> GetById(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync(_urlPath + "/" + id);
            string responseText = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Tipo>(responseText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO GetById: {ex}");
            throw;
        }
    }
}
