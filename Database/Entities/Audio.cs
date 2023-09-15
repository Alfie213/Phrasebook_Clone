using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

public class Audio
{
    [ForeignKey(nameof(Translation))]
    public int Id { get; set; }

    public int VoiceId { get; set; }

    [MaxLength(256)]
    public Uri? Source { get; set; }

    public Translation? Translation { get; set; }
    public Voice? Voice { get; set; }
}
