using System.ComponentModel.DataAnnotations;

namespace efcorealloperations.Models;

public class Currency
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? CurrencyName { get; set; }


    public ICollection<BookPrice>? BookPrices { get; set; }
}
