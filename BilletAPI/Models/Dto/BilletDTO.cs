using System.ComponentModel.DataAnnotations;

namespace BilletAPI.Models.Dto
{
    public class BilletDTO

    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        [Required]
        public string CorrectAnswer { get; set; }
        public string? ImageUrl { get; set; }

    }

}
