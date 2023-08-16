using AspNetLesson01.Models;
using AspNetLesson01.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetLesson01.Controllers
{
	[Route("/skill")]
	public class SkillController : Controller
	{
		private readonly AboutMeService _aboutMeService;

		public SkillController(AboutMeService aboutMeService)
		{
			Console.WriteLine("SkillController constructor");
			_aboutMeService = aboutMeService;
		}
	
        [HttpGet("/skill/create")]
        public IActionResult Create()
        {
          
            return View(new SkillForm
            {
                Title = "",
                Experience = 0,
            });
        }
        [HttpPost("/skill/create")]
        public IActionResult Create([FromForm] SkillForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            var model = new Skill { Id = _aboutMeService.NextSkillId };
            form.Update(model);
            _aboutMeService.Model.Skills.Add(model);
            _aboutMeService.Save();
            return Redirect("/");
        }
        [HttpGet("/skill/edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            var model = _aboutMeService.Model.Skills.First(x => x.Id == Id);
            return View(new SkillForm
            {
                Id = model.Id,
                Title = model.Title,
                Experience = model.Experience,
            });
        }
        [HttpPost("/skill/edit/{Id}")]
		public IActionResult Edit(int Id, [FromForm] SkillForm form)
		{
			if (!ModelState.IsValid)
			{
				return View(form);
			}
			var model = _aboutMeService.Model.Skills.First(x => x.Id == Id);
			form.Update(model);
			_aboutMeService.Save();
			return Redirect("/");
		}

        [HttpPost("/skill/delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            _aboutMeService.Model.Skills.Remove(_aboutMeService.Model.Skills.First(x => x.Id == Id));
            _aboutMeService.Save();
            return Redirect("/");

        }



    }
}