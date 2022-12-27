using FicheDUE.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;

namespace FicheDUE.Controllers
{
    [Controller]
    public class LoginController : Controller
    {
		private readonly ILogger<LoginController> _logger;
		private readonly IConfiguration _config;
		private readonly HttpContextAccessor _context;
        private readonly HttpClient Client = new HttpClient();
		public LoginController(ILogger<LoginController> logger, IConfiguration config, HttpContextAccessor context)
		{
			_logger = logger;
			_config = config;
			_context = context;
		}
		private string UrlAuthApiBase => ConfigConstants.GetAuthApiURL(_config);
		private static string Token { get; set; }

        private void GetToKen()
        {
            var url = UrlAuthApiBase + $"Auth";
            var response = Client.GetAsync(url).Result;
            Token = response.Content.ReadAsStringAsync().Result;
		}
		public IActionResult Index()
        {
            ViewData["Title"] = "Login Page";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login()
        {
            var username = Request.Form["username"].ToString();
            var passwd = Request.Form["passwd"].ToString();
            var credential = $"email={username}&&password={passwd}";
            var url = UrlAuthApiBase + $"Auth";
            GetToKen();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

            var response = await Client.PostAsync(url, new StringContent(credential,
                Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode) 
            { 
                var token = await response.Content.ReadAsStringAsync();
                if(token is not null)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Login");
		}
    }
}
