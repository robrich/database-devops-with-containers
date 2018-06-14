using System.ComponentModel.DataAnnotations;

namespace WebApp.DataAccess
{
    public class Setting
    {
        [Key]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        [Required]
        public string Secret { get; set; }
    }
}
