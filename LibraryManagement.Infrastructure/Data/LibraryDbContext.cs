using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Entities.LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<ReadingProgress> ReadingProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.ISBN).IsUnique();
                entity.HasIndex(e => e.Title);
                entity.Property(e => e.Status)
                    .HasConversion<string>();
            });

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Role)
                    .HasConversion<string>();
            });

            // Configure Checkout entity
            modelBuilder.Entity<Checkout>(entity =>
            {
                entity.Property(e => e.Status)
                    .HasConversion<string>();

                entity.Property(e => e.LateFee)
                    .HasPrecision(10, 2);

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Checkouts)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Book)
                    .WithMany(b => b.Checkouts)
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure BookRating entity
            modelBuilder.Entity<BookRating>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.BookId }).IsUnique();

                entity.HasOne(e => e.User)
                    .WithMany(u => u.Ratings)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Book)
                    .WithMany(b => b.Ratings)
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure ReadingProgress entity
            modelBuilder.Entity<ReadingProgress>(entity =>
            {
                entity.HasOne(e => e.User)
                    .WithMany(u => u.ReadingProgress)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
        }
    }
}
