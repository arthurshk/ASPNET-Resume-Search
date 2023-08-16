using System.ComponentModel.DataAnnotations;

namespace AspNetLesson01.Models;

public class AboutMeForm
{
    [Required(ErrorMessage = "Name - Required field")]
    [MaxLength(50, ErrorMessage = "Maximum length - 50 symbols")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName - Required field")]
    [MaxLength(50, ErrorMessage = "Maximum length - 50 symbols")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Age - Required field")]
    [Range(1, 100, ErrorMessage = "Invalid age. Enter a number between 1 and 100")]
    public int Age { get; set; }
    public string Description { get; set; }

    public void Update(AboutMe model)
    {
        model.FirstName = FirstName;
        model.LastName = LastName;
        model.Age = Age;
        model.Description = Description;
    }
}
