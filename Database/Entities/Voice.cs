using Database.Enums;

namespace Database.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Voice
{
    public int Id { get; set; }
    public int LanguageId { get; set; }

    [MaxLength(32)]
    public required string Name { get; set; }

    public Gender Gender { get; set; }

    public Language? Language { get; set; }
    public ICollection<Audio>? Audios { get; set; }
}
