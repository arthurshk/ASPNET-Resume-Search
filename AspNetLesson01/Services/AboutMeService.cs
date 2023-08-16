using AspNetLesson01.Models;
using System.Text.Json;

namespace AspNetLesson01.Services;

public class AboutMeService
{
	public AboutMeService(string dataFile)
	{
		Console.WriteLine("AboutMeService constructor");
		_dataFile = dataFile;
		Load();
	}

	private string _dataFile;

	private AboutMe Default()
	{
		return new AboutMe()
		{
			LastName = "Arthur",
			FirstName = "Shkryabiy",
			Age = 22,
			Description = "Senior web developer",
			Skills = new() {
						new Skill
						{
							Id = 1,
							Title = "C",
							Experience = 50,
						},
						new Skill{
							Id = 2,
							Title = "C++",
							Experience = 70,
						},
						new Skill{
							Id = 3,
							Title = "C#",
							Experience = 80,
						},
						new Skill{
							Id = 4,
							Title = "ADO.Net",
							Experience = 90,
						},
						new Skill{
							Id = 5,
							Title = "ASP.NET Core",
							Experience = 100,
						},


						//"C", "C++", "C#", "ADO.Net", "ASP.NET Core",
      //                  "SQL", "MSSQL", "MySQL", "PostgreSQL", "MongoDB",
      //                  "JavaScript", "NodeJS", "Vue 2,3", "HTML", "CSS", "SCSS",
      //                  "Python", "PHP", "Yii2 framework", "Symfony", "Laravel",
}
		};
	}

	public AboutMe Model { get; set; } = null!;

	public void Load()
	{
		Console.WriteLine("AboutMeService Load");
		if (!File.Exists(_dataFile))
		{
			Model = Default();
		}
		else
		{
			Model = JsonSerializer.Deserialize<AboutMe>(File.ReadAllText(_dataFile));
		}
	}

	public void Save()
	{
		Console.WriteLine("AboutMeService Save");
		File.WriteAllText(_dataFile, JsonSerializer.Serialize(Model));
	}
	public int NextSkillId => 1 + Model.Skills.Max(x => x.Id);
}
