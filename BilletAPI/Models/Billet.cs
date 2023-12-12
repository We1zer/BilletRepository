using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilletAPI.Models
{
    public class Billet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Answer1 { get; set; } 
        public string Answer2 { get; set; } 
        public string Answer3 { get; set; } 
        public string Answer4 { get; set; } 
        public string CorrectAnswer { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime UpdatedDate {  get; set; }
    }
}
