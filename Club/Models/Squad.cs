using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Club.Models
{
    public class Squad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Player")]
        public string Name { get; set; }

        [Required]
        [Range(1,99,ErrorMessage ="Player number must be between 1 & 100")]
        public int Number { get; set; }

        [Required]
        [Range(17,40,ErrorMessage ="Player's age must be between 17 & 40")]
        public int Age { get; set; }

        [Required]
        public string Position { get; set; }
    }
}