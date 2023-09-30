using ContasFrontEnd.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ContasFrontEnd.Services
{
    public class EntradaService : BaseService, IEntradaService
    {
        private readonly string _urlPath = "api/Entradas";
        public async Task<List<Entrada>> GetAll()
        {
            List<Entrada> entradas = new List<Entrada>();

            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri(BaseURL);
                api.DefaultRequestHeaders.Accept.Clear();
                api.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("text/plain"));

                try
                {
                    HttpResponseMessage response = await api.GetAsync(_urlPath);
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

        public async Task<HttpResponseMessage> Create(Entrada entrada)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri(BaseURL);
                api.DefaultRequestHeaders.Accept.Clear();                
                try
                {
                    response = await api.PostAsJsonAsync(_urlPath, entrada);
                    string responseText = response.Content.ReadAsStringAsync().Result;

                } catch (Exception e) {
                    Console.WriteLine($"ERROR api: {e}");
                }
            }
            return response;
        }

        public async Task<Entrada> GetById(int id)
        {
            Entrada entrada = new Entrada();

            using (var api = new HttpClient())
            {
                api.BaseAddress = new Uri(BaseURL);
                api.DefaultRequestHeaders.Accept.Clear();
                api.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("text/plain"));

                try
                {
                    HttpResponseMessage response = await api.GetAsync(_urlPath + "/" + id); 
                    string responseText = response.Content.ReadAsStringAsync().Result;
                    var conversao = JsonConvert.DeserializeObject<Entrada>(responseText);
                    if (conversao != null)
                        entrada = conversao;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR api: {e}");
                }
            }

            return entrada;
        }
    }
}
