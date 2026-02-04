namespace DatabaseDevOps.Models.Data;

public class Setting
{
    [Key]
    [StringLength(30)]
    [Required]
    public string Name { get; set; } = "";
    [StringLength(200)]
    [Required]
    public string Secret { get; set; } = "";
}
