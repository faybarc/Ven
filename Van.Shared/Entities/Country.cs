using System.ComponentModel.DataAnnotations;

namespace Van.Shared.Entities;

public class Country
{
    [Key]
    public int IdCountry { get; set; }

    [Required]
    [MaxLength(100)]
    public string CountryName { get; set; } = null!;

}
