using ContasFrontEnd.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ContasFrontEnd.Services
{
    public class EntradaService : BaseService, IEntradaService
    {
        public async Task<List<Entrada>> GetAll() //todo: fazer melhor :)
        {
            List<Entrada> entradas = new List<Entrada>();

            using (var api = new HttpClient())
            {
                api.BaseAddress = new System.Uri(BaseURL);
                api.DefaultRequestHeaders.Accept.Clear();
                api.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("text/plain"));

                try
                {
                    HttpResponseMessage response = await api.GetAsync("api/Entradas");
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    var conversao = JsonConvert.DeserializeObject<List<Entrada>>(responseText);
                    if (conversao != null)
                        entradas = conversao;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR api: {e}");
                }
            }

            return entradas;
        }
    }
}
