using System;
using System.Collections.Generic;
using System.Linq;
using WEB_API_App.Data.Models;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Data.Services
{
    public class PublisherServices
    {
        protected readonly ApplicationDbContext _context;
        public PublisherServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherViewModel model)
        {
            var publisher = new Publisher()
            {
                Name = model.Name
            };
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public PublisherViewModelWithAuthorsAndBooks GetPublisherWithBookAuthorsById(int id)
        {
            var model = _context.Publishers.Where(p => p.Id == id).Select(p => new PublisherViewModelWithAuthorsAndBooks
            {
                PublisherName = p.Name,
                AuthorBooks = p.Books.Select(book => new AuthorBooks()
                {
                    BookName = book.Title,
                    BookAuthors = book.Books_Authors.Select(ba => ba.Author.Name).ToList()
                }).ToList()
            }).FirstOrDefault();

            return model;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(p => p.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }
    }
}
