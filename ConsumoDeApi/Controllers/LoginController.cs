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
            _httpClient.BaseAddress = new Uri("https://localhost:7274/"); 
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
        public async Task<IActionResult> Login(string email, string password)
        {
            var body = new { email, password };
            var content = new StringContent(JsonSerializer.Serialize(body),Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("User/Login", content);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Email o contraseña incorrectos.";
                return View("Index");
            }
            var json = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(json,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            HttpContext.Session.SetString("Nombre", user!.Nombre);
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("Apellido", user.Apellido);
            HttpContext.Session.SetString("Identificacion", user.Identificacion);
            return RedirectToAction("VistaPosLog");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(User user)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.PostAsync("User/Register", content);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Error al registrar el usuario.";
                return View("Register");
            }
            return RedirectToAction("Index"); 
        }
    }
}

