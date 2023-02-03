using GetsToDoWithApi.Models.Entities;
using GetsToDoWithApi.Models.Repositories;
using System.Text.Json;

namespace GetsToDoWithApi.Models.Services
{
    public class ToDoService : IToDoRepository
    {
        private readonly IHttpClientFactory _factory;

        public ToDoService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<ToDo>? Get()
        {
            using(HttpClient httpClient = _factory.CreateClient("Api")) 
            {
                using(HttpResponseMessage httpResponseMessage = httpClient.GetAsync("todo").Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();

                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<ToDo[]>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
        }
    }
}
