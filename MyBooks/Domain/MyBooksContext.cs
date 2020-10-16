using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBooks.Areas.Identity.Data;
using MyBooks.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MyBooks.Domain
{
    public class MyBooksContext : IdentityDbContext<IdentityUser>
    {

        public MyBooksContext(DbContextOptions<MyBooksContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<MyLibrary> MyLibraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

         
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                ImagePath = "photo1.jpg",
                
            }); 
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                ImagePath = "photo2.jpg",
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                ImagePath = "photo3.jpg",
            });

            modelBuilder.Entity<MyLibrary>().HasData(new MyLibrary
            {
                Id = new Guid("3b62472e-4f66-49fa-a20f-e7685b9565d1"),

                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8",

                BookId = "63dc8fa6-07ae-4391-8916-e057f71239ce"
            });

            modelBuilder.Entity<MyLibrary>().HasData(new MyLibrary
            {
                Id = new Guid("3b64372e-4f66-49fa-a20f-e7685b3465d8"),

                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8",

                BookId = "4aa76a4c-c59d-409a-84c1-06e6487a137a"
            });
        }

    }
}
