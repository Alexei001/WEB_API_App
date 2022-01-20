using System.Collections.Generic;

namespace WEB_API_App.Data.Services.ViewModels
{
    public class AuthorViewModelWithBooks
    {
        public string Name { get; set; }
        public List<string> BooksName { get; set; }
    }
}
