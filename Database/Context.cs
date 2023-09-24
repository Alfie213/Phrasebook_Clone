using Database.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Database;

/// <summary>
/// Контекст базы данных.
/// </summary>
public sealed class Context : IdentityDbContext<IdentityUser>
{
    /// <summary>
    /// Создаёт экземпляр класса.
    /// </summary>
    /// <param name="options">Настройки для создания <see cref="Context"/>.</param>
    public Context(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Таблица с категориями.
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Таблица с языками для изучения.
    /// </summary>
    public DbSet<Language> Languages { get; set; }

    /// <summary>
    /// Таблица с голосами.
    /// </summary>
    public DbSet<Voice> Voices { get; set; }

    /// <summary>
    /// Таблица с фразами.
    /// </summary>
    public DbSet<Phrase> Phrases { get; set; }

    /// <summary>
    /// Таблица с переводами.
    /// </summary>
    public DbSet<Translation> Translations { get; set; }

    /// <summary>
    /// Таблица с аудиофайлами.
    /// </summary>
    public DbSet<Audio> Audios { get; set; }

    /// <summary>
    /// Таблица с настройками.
    /// </summary>
    public DbSet<Setting> Settings { get; set; }

    /// <summary>
    /// Таблица с флагами, которые пользователь может применить к переводу.
    /// </summary>
    public DbSet<UserTranslation> UserTranslations { get; set; }
}
