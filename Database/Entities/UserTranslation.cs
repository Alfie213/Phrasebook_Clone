using Microsoft.AspNetCore.Identity;

namespace Database.Entities;

public class UserTranslation
{
    public required string UserId { get; set; }
    public int TranslationId { get; set; }
    public bool Learned { get; set; }
    public bool Hidden { get; set; }

    public IdentityUser? User { get; set; }
    public Translation? Translation { get; set; }
}
