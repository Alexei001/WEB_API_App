using System.Collections.Generic;

namespace WEB_API_App.Data.Services.ViewModels
{
    public class PublisherViewModelWithAuthorsAndBooks
    {
        public string PublisherName { get; set; }
        public List<AuthorBooks> AuthorBooks { get; set; }
    }


    public class AuthorBooks
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
