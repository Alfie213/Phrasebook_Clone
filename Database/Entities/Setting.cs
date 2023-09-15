namespace Database.Entities;

public class Setting
{
    [Key]
    [MaxLength(128)]
    public required string Key { get; set; }

    [MaxLength(32)]
    public required string Value { get; set; }
}
