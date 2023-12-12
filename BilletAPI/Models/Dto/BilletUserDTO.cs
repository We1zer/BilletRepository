using System.ComponentModel.DataAnnotations;

namespace BilletAPI.Models.Dto
{
    public class BilletUserDTO

    {
        [Required]
        public int BilletNo { get; set; }
        [Required]
        public int BilletId { get; set; }
        public string User { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public BilletDTO Billet { get; set; }

    }

}
