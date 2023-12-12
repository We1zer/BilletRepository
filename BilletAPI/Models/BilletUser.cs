using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilletAPI.Models
{
    public class BilletUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BilletNo {  get; set; }
        [ForeignKey("Billet")]
        public int BilletId { get; set; }
        public Billet Billet { get; set; }
        public string User {  get; set; }
        public string UserAnswer {  get; set; }
        public string CorrectAnswer { get; set; }
        public DateTime Date { get; set; }  
    }
}
