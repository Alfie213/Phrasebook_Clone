namespace Database.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Language
{
    public int Id { get; set; }

    [MaxLength(32)]
    public required string Name { get; set; }
    
    public int Order { get; set; }
    public bool Enabled { get; set; }

    public ICollection<Translation>? Translations { get; set; }
    public ICollection<Voice>? Voices { get; set; }
}
