using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using My_Scripture_Journal.Data;


namespace My_Scripture_Journal.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new My_Scripture_JournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<My_Scripture_JournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(

                    new Scripture
                    {
                        Book = "Alma",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Chapter = 4,
                        Verse = 1,
                        Note = "we love you",
                       
                    },

                    new Scripture
                    {
                        Book = "Nephi",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Chapter = 2,
                        Verse = 8,
                        Note = "ask",

                    },
                     new Scripture
                     {
                         Book = "Jacob",
                         ReleaseDate = DateTime.Parse("1989-2-12"),
                         Chapter = 1,
                         Verse = 8,
                         Note = "all in you",

                     },
                      new Scripture
                      {
                          Book = "Moroni",
                          ReleaseDate = DateTime.Parse("1989-2-12"),
                          Chapter = 7,
                          Verse = 41,
                          Note = "one for you",

                      }



                );
                context.SaveChanges();
            }
        }


    }
}
