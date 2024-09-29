using System.ComponentModel.DataAnnotations;

namespace efcorealloperations.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? NoOfPages { get; set; }
    [Required]
    public bool IsActive { get; set; } = false;
    [Required]
    public int LanguageId { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public Language? Language { get; set; }
    public ICollection<BookPrice>? BookPrices { get; set; }
}
