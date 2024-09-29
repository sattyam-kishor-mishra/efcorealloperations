using System.ComponentModel.DataAnnotations;

namespace efcorealloperations.Models;

public class BookPrice
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int BookId { get; set; }
    [Required]
    public decimal Amount { get; set; } =0.0M;
    public int CurrencyId { get; set; }



    public Book? Books { get; set; }
    public Currency? Currency {get; set;}
}
