using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WEB_API_App.Data.Models;

namespace WEB_API_App.Data
{
    public class DatabaseInitial
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Title = "1st book title",
                            Description = "some description 1st book",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-15),
                            Rate = 4,
                            Genre = "Historical",
                            CoverUrl = "http//someurl.com--",
                            DateAdded = DateTime.Now.AddDays(-100)
                        },
                        new Book
                        {
                            Title = "2st book title",
                            Description = "some description 2st book",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-35),
                            Rate = 4,
                            Genre = "Dystopian",
                            CoverUrl = "http//someurl.com--",
                            DateAdded = DateTime.Now.AddDays(-200)
                        },
                        new Book
                        {
                            Title = "3st book title",
                            Description = "some description 3st book",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-36),
                            Rate = 4,
                            Genre = "Romance",
                            CoverUrl = "http//someurl.com--",
                            DateAdded = DateTime.Now.AddDays(-255)
                        },
                        new Book
                        {
                            Title = "4st book title",
                            Description = "some description 4st book",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-90),
                            Rate = 4,
                            Genre = "Fantasy",
                            CoverUrl = "http//someurl.com--",
                            DateAdded = DateTime.Now.AddDays(-256)
                        }
                        );
                    context.SaveChanges();
                }
            }

        }
    }
}
