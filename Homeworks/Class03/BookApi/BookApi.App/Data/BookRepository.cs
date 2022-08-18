using BookApi.App.Models;

namespace BookApi.App.Data
{
    public static class BookRepository
    {
        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Harry Potter",
                Author = "J. K. Rowling"
            },
            new Book
            {
                Id = 2,
                Title = "The Lord of the Rings",
                Author = "J. R. R. Toliken"
            },
            new Book
            {
                Id = 3,
                Title = "1984",
                Author = "George Orwell"

            },
            new Book
            {
                Id = 4,
                Title = "War and Peace",
                Author = "Leo Tolstoy"
            },
            new Book
            {
                Id = 5,
                Title = "Gulliver's Travels",
                Author = "Johnatan Swift"
            },
            new Book
            {
                Id = 6,
                Title = "The Idiot",
                Author = "Fyodor Dostoyevsky"
            },
            new Book
            {
                Id = 7,
                Title = "Les Miserales",
                Author = "Victor Hugo"
            },
            new Book
            {
                Id = 8,
                Title = "The Old Man and the Sea",
                Author = "Ernest Hemingway"
            }
        };
        
    }
}
