using Microsoft.EntityFrameworkCore;
using SEDC.WebApi.MovieManager.DataModels.Enums;
using SEDC.WebApi.MovieManager.DataModels.Models;
using System.Text;
using XSystem.Security.Cryptography;

namespace SEDC.WebApi.MovieManager.DataAccess
{
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .ToTable(nameof(User))
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<User>()
                .Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder
                .Entity<User>()
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder
                .Entity<User>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder
                .Entity<User>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);



            modelBuilder
                .Entity<Movie>()
                .ToTable(nameof(Movie))  
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Movie>()
                .HasOne(p => p.User)
                .WithMany(p => p.Movies)
                .HasForeignKey(p => p.UserId);

            modelBuilder
                .Entity<Movie>()
                .Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder
                .Entity<Movie>()
                .Property(p => p.Description)
                .HasMaxLength(1000);

            modelBuilder
                .Entity<Movie>()
                .Property(p => p.Year)
                .IsRequired();

            modelBuilder
                .Entity<Movie>()
                .Property(p => p.Genre)
                .IsRequired()
                .HasMaxLength(50);

            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes("aneta123"));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            modelBuilder
                .Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Aneta",
                    LastName = "Stankovska",
                    Username = "anetas",
                    Password = hashedPassword
                });

            modelBuilder
                .Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    Title = "Top Gun",
                    Description = "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.",
                    Year = 1986,
                    Genre = Genre.Action,
                    UserId = 1
                },
                new Movie
                {
                    Id = 6,
                    Title = "Gladiator",
                    Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                    Year = 2000,
                    Genre = Genre.Drama,
                    UserId = 1
                },
                new Movie
                {
                    Id = 8,
                    Title = "The Conjuring",
                    Description = "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse.",
                    Year = 1994,
                    Genre = Genre.Horror,
                    UserId = 1
                },
                new Movie
                {
                    Id = 16,
                    Title = "Iron Man",
                    Description = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                    Year = 2008,
                    Genre = Genre.Adventure
                });

        }
    } 
}
