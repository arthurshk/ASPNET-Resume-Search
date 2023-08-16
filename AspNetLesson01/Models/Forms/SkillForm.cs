using System.ComponentModel.DataAnnotations;

namespace AspNetLesson01.Models;

public class SkillForm
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "Name - Required Field")]
    [MaxLength(50, ErrorMessage = "Max length - 50 symbols")]
    public string Title { get; set; }
    [Range(0, 100, ErrorMessage = "Enter a number from 0 to 100")]
    public int Experience { get; set; }

    public void Update(Skill model)
    {
        model.Title = Title;
        model.Experience = Experience;
    }
}
