namespace Database.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    public int Id { get; set; }

    [MaxLength(64)]
    public required string Name { get; set; }
    
    public int Order { get; set; }
    public bool Enabled { get; set; }

    public ICollection<Phrase>? Phrases { get; set; }
}
