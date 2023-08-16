using AspNetLesson01.Models;
using AspNetLesson01.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLesson01.Controllers
{
	[Route("/")]
	public class HomeController : Controller
	{
		private readonly AboutMeService _aboutMeService;

		public HomeController(AboutMeService aboutMeService)
		{
			Console.WriteLine("HomeController constructor");
			_aboutMeService = aboutMeService;
		}

		public IActionResult Index()
		{
			ViewData["Title"] = "About me page";
			return View(_aboutMeService.Model);
		}

		[HttpGet("/about-me")]
		public IActionResult AboutMe()
		{
			return Json(_aboutMeService.Model);
		}

		[HttpPost("/about-me/skills")]
		public IActionResult Skills([FromBody] SearchQuery query)
		{
			return Json(_aboutMeService.Model.Skills.Where(s => s.Title.ToLower().Contains(query.Query.ToLower())));
		}




		[HttpGet("/about-me/edit")]
		public IActionResult Edit()
		{
			var model = _aboutMeService.Model;
			return View(new AboutMeForm
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Age = model.Age,
				Description = model.Description,
			});
		}

		[HttpPost("/about-me/edit")]
		public IActionResult Update([FromForm] AboutMeForm form)
		{
			if (!ModelState.IsValid)
			{
				return View("Edit", form);
			}

			form.Update(_aboutMeService.Model);
            _aboutMeService.Save();

			return Redirect("/");
		}



	}
}