using Microsoft.AspNetCore.Identity;
using KABookstore.Data.Enums;
using KABookstore.Models;

namespace KABookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                
                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Name = "Life of Pi",
                            Description = "One boy, one boat, one tiger . . .After the tragic sinking of a cargo ship, a solitary lifeboat remains bobbing on the wild, blue Pacific. \n" +
                            "The only survivors from the wreck are a sixteen-year-old boy named Pi, a hyena, a zebra (with a broken leg), a female orang-utan - and a 450-pound Royal Bengal tiger.",
                            Author = "Yann Martel",
                            Price = 315.00,
                            ImageURL = "https://cdn.kobo.com/book-images/d62f50b9-3e56-4699-ada1-d60c62217bda/1200/1200/False/life-of-pi.jpg",
                            BookCategory = BookCategory.Fiction
                        },
                        new Book()
                        {
                            Name = "It Ends With Us",
                            Description = "Published in 2016, It Ends with Us is a romance novel, the first in a duology by Colleen Hoover. The novel tells the story of Lily Bloom,\n" +
                            " a young woman from an abusive home who struggles to find her way in the world without recreating the patterns of violence from her youth.",
                            Author = "Colleen Hover",
                            Price = 290.00,
                            ImageURL = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1688011813i/27362503.jpg",
                            BookCategory = BookCategory.Romance
                        },
                        new Book()
                        {
                            Name = "Family Upstairs",
                            Description = "T“The Family Upstairs” is a dark, gripping tale; one part thriller, one part family saga. It follows the Lamb family, \n" +
                            "and the series of strangers who move into their house and turn their lives into a living nightmare. ",
                            Author = "Lisa Jewell",
                            Price = 381.00,
                            ImageURL = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1564517337l/43822820.jpg",
                            BookCategory = BookCategory.Mystery
                        },
                         new Book()
                        {
                            Name = "Diary of a Wimpy Kid",
                            Description = "The launch of an exciting and innovatively illustrated new series narrated by an unforgettable kid every family can relate toIt’s a new school year, \n" +
                            "and Greg Heffley finds himself thrust into middle school, where undersized weaklings share the hallways with kids who are taller, meaner, and already shaving.",
                            Author = "Kinney",
                            Price = 317.00,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/8/84/Diary_of_a_Wimpy_Kid_book_cover.jpg",
                            BookCategory = BookCategory.Children
                        },
                        new Book()
                        {
                            Name = "Hunger Games",
                            Description = "Sixteen-year-old Katniss Everdeen regards it as a death sentence when she is forced to represent her district in the annual Hunger Games,\n" +
                            " a fight to the death on live TV. But Katniss has been close to death before - and survival, for her, is second nature. The Hunger Games is a searing \n" +
                            "novel set in a future with unsettling parallels to our present.",
                            Author = "Suzanne Collins",
                            Price = 409.00,
                            ImageURL = "https://m.media-amazon.com/images/I/71un2hI4mcL._AC_UF1000,1000_QL80_.jpg",
                            BookCategory = BookCategory.Fiction
                        },
                        new Book()
                        {
                            Name = "The Shining",
                            Description = "Danny, a five-year-old with psychic voltage, experiences heightened visions when his father takes care of the Overlook Hotel. As winter closes, \n" +
                            "the hotel appears to have a life of its own, with mysterious guests and hedges resembling animals. An evil force begins to shine in the hotel.",
                            Author = "Stephen King",
                            Price = 315.00,
                            ImageURL = "https://cdn.kobo.com/book-images/c6b01ca1-74fc-4986-b958-f3ea423a2da5/1200/1200/False/the-shining.jpg",
                            BookCategory = BookCategory.Horror
                        }
                    });
                    context.SaveChanges();
                }
            }

        }

        // Added Admin role for future use of project 
        // not neccessay for task 1
       
        }

    }

