namespace DatabaseDevOps.Models.Data;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [StringLength(20)]
    [Required]
    public string Username { get; set; } = "";
    [StringLength(200)]
    [Required]
    public string Email { get; set; } = "";
    [StringLength(10)]
    public string? Title { get; set; }
    [StringLength(50)]
    [Required]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(50)]
    public string? Address1 { get; set; }
    [StringLength(50)]
    public string? City { get; set; }
    [StringLength(50)]
    public string? State { get; set; }
    [StringLength(20)]
    public string? Zip { get; set; }
    [StringLength(2)]
    public string? Country { get; set; }
    public DateTime CreateDate { get; set; }
    [StringLength(10)]
    public string? Gender { get; set; }
    [StringLength(50)]
    public string? Phone { get; set; }
    [StringLength(50)]
    public string? Cell { get; set; }
    [StringLength(120)]
    public string? ProfileLargeUrl { get; set; }
    [StringLength(120)]
    public string? ProfileMediumUrl { get; set; }
    [StringLength(120)]
    public string? ProfileThumbUrl { get; set; }
}
