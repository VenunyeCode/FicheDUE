﻿using FicheDUE.Constants;
using FicheDUE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace FicheDUE.Controllers
{
	[Controller]
	public class AdminController : Controller
	{
		private readonly ILogger<LoginController> _logger;
		private readonly IConfiguration _config;
		private readonly HttpContextAccessor _context;
		private readonly HttpClient Client = new HttpClient();

		public AdminController(ILogger<LoginController> logger, IConfiguration config, HttpContextAccessor context)
		{
			_logger = logger;
			_config = config;
			_context = context;
		}
		private string UrlAuthApiBase => ConfigConstants.GetAuthApiURL(_config);
		private string UrlFicheApiBase => ConfigConstants.GetUEApiUrl(_config);
		private static string Token { get; set; }

		private void GetToKen()
		{
			var url = UrlAuthApiBase + "Auth";
			var response = Client.GetAsync(url).Result;
			Token = response.Content.ReadAsStringAsync().Result;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Encodage()
		{
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> Professeurs() 
		{
			var url = "https://localhost:7274/api/FicheUEGestion/FicheUEApiGestion/Enseigants";
			var response = Client.GetAsync(url).Result;

			if (response.IsSuccessStatusCode)
			{
				var value = await(response.Content.ReadFromJsonAsync<IEnumerable<Enseignant>>());
				ViewBag.enseignants = value;
			}
			return View();
		}

		[HttpGet]
		public async Task<ActionResult> UE() //Vue Liste des UE
		{
			var url = "https://localhost:7274/api/FicheUEGestion/FicheUEApiGestion/UE";
			var response = Client.GetAsync(url).Result;

			if (response.IsSuccessStatusCode)
			{
				ViewBag.UEs = (await response.Content.
					ReadFromJsonAsync<IEnumerable<UE>>());
			}
			return View();
		}

		public IActionResult UEAddForm()
		{
			return View();
		}

		public async Task<ActionResult> UEAddAction()
		{
			var code = Request.Form["codeUE"].ToString();
			var nom = Request.Form["nomUE"].ToString();
			var note = float.Parse(Request.Form["note"].ToString());
			var url = "https://localhost:7274/api/FicheUEGestion/FicheUEApiGestion/UE/Add";
			var Ue = new UE(code, nom, note);

			var response = Client.PostAsync(url, new StringContent(JsonConvert.);
		}

		[HttpGet]
		public async Task<ActionResult> Competence()
		{
			return View();
		}
		[HttpGet]
			
		public async Task<ActionResult> Capacite()
		{
			return View();
		}


		public async Task<ActionResult> Cours()
		{
			return View();
		}
		public IActionResult UpdateProf()
		{
			var a = int.Parse(Request.Form["idProf"].ToString());

			return RedirectToAction("UpdateProfesseur", "Admin", new { id = a });
		}

		[HttpPatch]
		public async Task<ActionResult> UpdateProfesseur(int Id)
		{
			var nom = Request.Form["nomProf"].ToString();
			var prenoms = Request.Form["prenomProf"].ToString();
			Enseignant e = new Enseignant(Id, nom, prenoms);
			var url = UrlFicheApiBase + "FicheUEApiGestion/Enseigants/Update";

			var response = await Client.PatchAsJsonAsync(url, e);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Professeurs", "Admin");
			}

			return RedirectToAction("UpdateProf", "Admin");
		}

		public IActionResult ModeEvaluation()
		{
			return View();
		}
		public IActionResult TypeEvaluation()
		{
			return View();
		}
		public IActionResult UpdateTypeEvaluation()
		{
			return View();
		}
		public IActionResult UpdateModEvaluation()
		{
			return View();
		}

		public IActionResult UpdateCompetence()
		{
			return View();
		}

		public IActionResult UpdateCapacite()
		{
			return View();
		}

	}
}
