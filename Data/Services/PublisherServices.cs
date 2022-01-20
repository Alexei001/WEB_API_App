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
    }
}
