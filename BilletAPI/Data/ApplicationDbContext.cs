using BilletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BilletAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        { 

        }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Billet> Billets { get; set; }
        public DbSet<BilletUser> BilletUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billet>().HasData(
                new Billet()
                {
                    Id = 1,
                    Name = "Billet1 ",
                    Description = "lorem ipsum",
                    Answer1 = "adads",
                    Answer2 = "adadsad",
                    Answer3 = "",
                    Answer4 = "",
                    CorrectAnswer = "",
                    ImageUrl ="",
                   
                },
                new Billet()
                {
                    Id = 2,
                    Name = "Billet2 ",
                    Description = "lorem ipsum",
                    Answer1 = "adads",
                    Answer2 = "adadsad",
                    Answer3 = "",
                    Answer4 = "",
                    CorrectAnswer = "",
                    ImageUrl = "",
                    CreatedDate= DateTime.Now,

                },
                new Billet()
                {
                    Id = 3,
                    Name = "Billet3 ",
                    Description = "lorem ipsum",
                    Answer1 = "adads",
                    Answer2 = "adadsad",
                    Answer3 = "",
                    Answer4 = "",
                    CorrectAnswer = "",
                    ImageUrl = "",
                    CreatedDate = DateTime.Now,
                },
                new Billet()
                {
                    Id = 4,
                    Name = "Billet4 ",
                    Description = "lorem ipsum",
                    Answer1 = "adads",
                    Answer2 = "adadsad",
                    Answer3 = "",
                    Answer4 = "",
                    CorrectAnswer = "",
                    ImageUrl = "",
                    CreatedDate = DateTime.Now,
                },
                new Billet()
                {
                    Id = 5,
                    Name = "Billet5 ",
                    Description = "lorem ipsum",
                    Answer1 = "adads",
                    Answer2 = "adadsad",
                    Answer3 = "",
                    Answer4 = "",
                    CorrectAnswer = "",
                    ImageUrl = "",
                    CreatedDate = DateTime.Now,
                }
                ) ;
        }
    }
}
