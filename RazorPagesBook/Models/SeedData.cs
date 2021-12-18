using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesBook.Data;
using System;
using System.Linq;

namespace RazorPagesBook.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesBookContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Find Waldo",
                        Category = "BooksFor Kids",
                        Author = "Mike Lennon",
                        Edition = "2nd Edition",
                        Publisher = "Kid's Book",
                        Description = "Book to find waldo",
                        Size = "289",
                        Rating = 2
                    },

                    new Book
                    {
                        Title = "Algebra for begginers",
                        Category = "Educational",
                        Author = "Big Mike",
                        Edition = "3nd Edition",
                        Publisher = "Edu Book",
                        Description = "Book with algebra",
                        Size = "589",
                        Rating = 3
                    },

                    new Book
                    {
                      
                        Title = "Rich ad Poor Dad",
                        Category = "Reflection",
                        Author = "Robert Kiyosaki",
                        Edition = "2nd Edition",
                        Publisher = "Reflexive Book",
                        Description = "Book to think about stuff",
                        Size = "190",
                        Rating = 4
                    },

                    new Book
                    {
                        Title = "Wonder",
                        Category = "BooksFor Teens",
                        Author = "Ed Frabricio",
                        Edition = "1st Edition",
                        Publisher = "Teens Book",
                        Description = "Book about drama",
                        Size = "120",
                        Rating = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
