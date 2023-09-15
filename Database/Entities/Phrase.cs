namespace Database.Entities;

[Index(nameof(Text), IsUnique = true)]
public class Phrase
{
    public int Id { get; set; }
    public int CategoryId { get; set; }

    [MaxLength(128)]
    public required string Text { get; set; }

    public int Order { get; set; }
    public bool Enabled { get; set; }

    public Category? Category { get; set; }
}
