using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()
                ))
                {
                    //look for any movies
                    if(context.Movie.Any())
                    {
                        return; //DB has been seeded not need to continue.
                    }

                    context.Movie.AddRange(
                        new Movie{
                            Title = "Wolf of Wallstreet",
                            ReleaseDate = DateTime.Parse("2008-1-12"),
                            Genre = "Action",
                            Price = 99.15M,
                            Rating = "R"
                        },
                        new Movie{
                            Title = "Django",
                            ReleaseDate = DateTime.Parse("2008-1-12"),
                            Genre = "Western",
                            Price = 5.00M,
                            Rating = "X"
                        },
                        new Movie{
                            Title = "Ace Ventura",
                            ReleaseDate = DateTime.Parse("2008-1-12"),
                            Genre = "Comedy",
                            Price = 1.99M,
                            Rating = "PG"
                        },
                        new Movie{
                            Title = "John Wick 3",
                            ReleaseDate = DateTime.Parse("2018-1-12"),
                            Genre = "Crime",
                            Price = 8.00M,
                            Rating = "X"
                        },
                        new Movie{
                            Title = "John Wick 2",
                            ReleaseDate = DateTime.Parse("2015-1-12"),
                            Genre = "Action",
                            Price = 8.00M,
                            Rating = "R"
                        },
                        new Movie{
                            Title = "John Wick",
                            ReleaseDate = DateTime.Parse("2014-1-12"),
                            Genre = "Action, Crime, Thriller",
                            Price = 8.00M,
                            Rating = "R"
                        }
                    );
                    context.SaveChanges();
                }
        }
    }
}