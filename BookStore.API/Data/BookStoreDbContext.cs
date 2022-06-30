using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-VJR295T;Database=BookStoreDb;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA8EC41A6F")
                    .IsUnique();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Id = "a11d9354-185d-47c0-a6b9-e39ae042b338",
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Id = "0350d2b3-faa0-4c0a-96b6-b0b4575d544a",
                        Name = "User",
                        NormalizedName = "USER",
                    }
                );

            var hash = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData
            (
                new ApiUser
                {
                    Id = "a11d9354-185d-47c0-a6b9-e39ae042b338",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstore.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hash.HashPassword(null!, "P@ssw0rd")
                },
                new ApiUser
                {
                    Id = "0350d2b3-faa0-4c0a-96b6-b0b4575d544a",
                    Email = "admin@bookstore.com",
                    NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstore.com",
                    NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hash.HashPassword(null!, "P@ssw0rd")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "a11d9354-185d-47c0-a6b9-e39ae042b338",
                    UserId = "a11d9354-185d-47c0-a6b9-e39ae042b338"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "0350d2b3-faa0-4c0a-96b6-b0b4575d544a",
                    UserId = "0350d2b3-faa0-4c0a-96b6-b0b4575d544a"
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
