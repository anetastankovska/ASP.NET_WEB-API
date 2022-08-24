using Microsoft.EntityFrameworkCore;

using SEDC.WebApi.Workshop.Notes.DataModels.Models;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.WebApi.Workshop.Notes.DataAccess
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Note mappings
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
                .HasMaxLength(500);

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

            #endregion

            #region User mappings

            modelBuilder
                .Entity<Note>()
                .ToTable(nameof(Note))  //nameof(Note) == "Note"
                .HasKey(p => p.Id);

            //make relations
            modelBuilder
                .Entity<Note>()
                .HasOne(p => p.User)
                .WithMany(p => p.NoteList)
                .HasForeignKey(p => p.UserId);

            modelBuilder
                .Entity<Note>()
                .Property(p => p.Text)
                .IsRequired()
                .HasMaxLength(1000);

            modelBuilder
                .Entity<Note>()
                .Property(p => p.Color)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder
                .Entity<Note>()
                .Property(p => p.Tag)
                .HasDefaultValue(5); //5 is the value of Other in our enumeration

            #endregion

            #region Add initial data
            //salt password pepper
            //thisisasecredSEDC12345thisisanothersecret

            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            modelBuilder
                .Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                });

            modelBuilder
                .Entity<Note>()
                .HasData(new Note
                {
                    Id = 1,
                    Text = "Buy Juice",
                    Color = "Orange",
                    Tag = 1,
                    UserId = 1,
                },

                new Note
                {
                    Id = 2,
                    Text = "Learn ASP.Net Core Web Api",
                    Color = "Green",
                    Tag = 2,
                    UserId = 1,
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
