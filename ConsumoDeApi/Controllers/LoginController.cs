using ConsumoDeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ConsumoDeApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController(IHttpClientFactory fact)
        {

            _httpClient = fact.CreateClient();
            _httpClient.BaseAddress = new Uri("https://api.tuservidor.com/"); 
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult VistaPosLog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(string username, string password)
        {
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> logout()
        {
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> Regitrar (User user)
        {
            string JsonUser = JsonSerializer.Serialize(user);
            var content = new StringContent(JsonUser, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);
            return null;
        }
    }
}
