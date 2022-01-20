using System;
using System.Collections.Generic;
using System.Linq;
using WEB_API_App.Data.Models;
using WEB_API_App.Data.Services.ViewModels;

namespace WEB_API_App.Data.Services
{
    public class AuthorServices
    {
        protected readonly ApplicationDbContext _context;
        public AuthorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorViewModel model)
        {
            var author = new Author() { Name = model.Name };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

    }
}
