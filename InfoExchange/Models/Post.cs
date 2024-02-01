using System.ComponentModel.DataAnnotations;
namespace InfoExchange.Models
{
    public class Post
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(2000)]
        public string PostText { get; set; }
        [MaxLength(50)]
        public string Username {  get; set; }
        public DateTime Date {  get; set; }
        [MaxLength(50)]
        public int? Reply {  get; set; }

        [MaxLength(1000)]
        public string? PostTitle { get; set; }



    }
}
