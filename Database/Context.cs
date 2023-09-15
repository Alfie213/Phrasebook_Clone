using Database.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Database;

public class Context : IdentityDbContext<IdentityUser>
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Voice> Voices { get; set; }
    public DbSet<Phrase> Phrases { get; set; }
    public DbSet<Translation> Translations { get; set; }
    public DbSet<Audio> Audios { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<UserTranslation> UserTranslations { get; set; }
}
