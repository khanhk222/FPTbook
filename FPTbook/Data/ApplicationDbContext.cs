using FPTBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FPTBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Note: add dữ liệu cho bảng chứa PK trước (University)
            //rồi add dữ liệu cho bảng chứa FK sau (Student)
            //add dữ liệu khởi tạo cho bảng University
            Category(builder);
            //add dữ liệu khởi tạo (initial data) cho bảng Student
            Book(builder);           
        }

        private void Book(ModelBuilder builder)
        {
            //var book = new Book
            //{
            //    Id = 1,
            //    Name = "Clgt",
            //    Price = 100000,
            //    Author = "Duc Anh",
            //    Publisher = "Xuan Cong",
            //    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIf6PwXo8SiU3N3bZbfnNx7XCAKt9hLyZMXg&usqp=CAU",
            //    CategoryId = 10,
            //};
            //var book1 = new Book1
            //{
            //    Id = 2,
            //    Name = "Clgt1",
            //    Price = 100000,
            //    Author = "Duc Anh",
            //    Publisher = "Xuan Cong",
            //    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIf6PwXo8SiU3N3bZbfnNx7XCAKt9hLyZMXg&usqp=CAU",
            //    CategoryId = 10,
            //};
            //var book2 = new Book
            //{
            //    Id = 3,
            //    Name = "Clgt2",
            //    Price = 100000,
            //    Author = "Duc Anh",
            //    Publisher = "Xuan Cong",
            //    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIf6PwXo8SiU3N3bZbfnNx7XCAKt9hLyZMXg&usqp=CAU",
            //    CategoryId = 30
            //};
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Clgt",
                    Price = 100000,
                    Author = "Duc Anh",
                    Publisher = "Xuan Cong",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIf6PwXo8SiU3N3bZbfnNx7XCAKt9hLyZMXg&usqp=CAU",
                    CategoryId = 10,
                    CategoryName = "Manga",
                    Quantity = 20,
                },
                new Book
                {
                    Id = 2,
                    Name = "Clgt1",
                    Price = 100000,
                    Author = "Duc Anh",
                    Publisher = "Xuan Cong",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIf6PwXo8SiU3N3bZbfnNx7XCAKt9hLyZMXg&usqp=CAU",
                    CategoryId = 10,
                    CategoryName = "Manga",
                    Quantity= 20,
                },
                new Book
                {
                    Id = 3,
                    Name = "Clgt2",
                    Price = 100000,
                    Author = "Duc Anh",
                    Publisher = "Xuan Cong",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSIf6PwXo8SiU3N3bZbfnNx7XCAKt9hLyZMXg&usqp=CAU",
                    CategoryId = 30,
                    CategoryName = "Novel",
                    Quantity = 20,
                }
                );
        }

        private void Category(ModelBuilder builder)
        {
            var manga = new Category
            {
                Id = 10,
                Name = "Manga",
                Description = "Pham Van Bach",
            };
            var novel = new Category
            {
                Id = 30,
                Name = "Novel",
                Description = "Duy Tan",
            };
            builder.Entity<Category>().HasData(manga, novel);
        }
    }
}
