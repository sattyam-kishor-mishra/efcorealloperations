using System.ComponentModel.DataAnnotations;

namespace efcorealloperations.Models;

public class Language
{
    [Key]
    public int Id { get; set; }
    public string? LanguageDescription { get; set; }


    public ICollection<Book>? Books { get; set; }
}
