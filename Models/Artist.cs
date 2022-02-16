using System.ComponentModel.DataAnnotations;

namespace Artists_API.Models
{
  public class Artist
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int YearOfBirth { get; set; }
    public int? YearOfDeath { get; set; }
    // NOTE only for bools we can create a 'null' instead of the default false by adding ? to the bool in the model
    public bool? IsDead { get; set; }
  }
}