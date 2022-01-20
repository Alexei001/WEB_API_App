using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WEB_API_App.Data.Models;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Data.Services
{
    public class BookServices
    {
        protected readonly ApplicationDbContext _context;
        public BookServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookViewModel model)
        {
            var newBook = new Book
            {
                Title = model.Title,
                Description = model.Description,
                IsRead = model.IsRead,
                DateRead = model.IsRead ? model.DateRead.Value : null,
                Rate = model.IsRead ? model.Rate.Value : null,
                Genre = model.Genre,
                CoverUrl = model.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = model.PublisherId
            };
            _context.Add(newBook);
            _context.SaveChanges();

            foreach (var authorId in model.AuthorsIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = newBook.Id,
                    AuthorId = authorId
                };
                _context.Books_Authors.Add(book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            return allBooks;
        }
        public BookViewModelWithAuthors GetBookById(int id)
        {
            var bookbyId = _context.Books.Where(b => b.Id == id).Select(model => new BookViewModelWithAuthors()
            {
                Title = model.Title,
                Description = model.Description,
                IsRead = model.IsRead,
                DateRead = model.IsRead ? model.DateRead.Value : null,
                Rate = model.IsRead ? model.Rate.Value : null,
                Genre = model.Genre,
                CoverUrl = model.CoverUrl,
                PublisherName = model.Publisher.Name,
                AuthorsName = model.Books_Authors.Select(ba => ba.Author.Name).ToList()
            }).FirstOrDefault();
            return bookbyId;
        }

        public Book UpdateBookById(int id, BookViewModel model)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Title = model.Title;
                book.Description = model.Description;
                book.IsRead = model.IsRead;
                book.DateRead = model.DateRead;
                book.Rate = model.Rate;
                book.Genre = model.Genre;
                book.CoverUrl = model.CoverUrl;

                _context.Books.Update(book);
                _context.SaveChanges();
            }
            return book;
        }

        public Book DeleteBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            return book;
        }


    }
}
