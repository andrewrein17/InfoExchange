using System.ComponentModel.DataAnnotations;
namespace InfoExchange.Models

{
    public class User
    {
        [Key]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Pass { get; set; }
    }
}
