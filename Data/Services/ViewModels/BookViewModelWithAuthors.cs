﻿using System;
using System.Collections.Generic;

namespace WEB_API_App.Data.Services.ViewModels
{
    public class BookViewModelWithAuthors
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverUrl { get; set; }
        public string PublisherName { get; set; }

        public List<String> AuthorsName { get; set; }
    }
}
