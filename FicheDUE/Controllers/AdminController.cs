using Microsoft.AspNetCore.Mvc;

namespace FicheDUE.Controllers
{
	[Controller]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Encodage()
		{
			return View();
		}
		public IActionResult Professeurs()
		{
			return View();
		}
		public IActionResult Competence()
		{
			return View();
		}

		public IActionResult Capacite()
		{
			return View();
		}

		public IActionResult Cours()
		{
			return View();
		}

		public IActionResult UpdateProf(int? Id)
		{
			return View();
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
