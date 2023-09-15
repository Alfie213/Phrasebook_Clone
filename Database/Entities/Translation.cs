namespace Database.Entities;

public class Translation
{
    public int Id { get; set; }
    public int PhraseId { get; set; }
    public int LanguageId { get; set; }

    [MaxLength(128)]
    public required string Text { get; set; }

    public Phrase? Phrase { get; set; }
    public Language? Language { get; set; }
    public Audio? Audio { get; set; }
}
