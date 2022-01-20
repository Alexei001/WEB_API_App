using System.Collections.Generic;

namespace WEB_API_App.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //define Relationships

        public List<Book_Author> Books_Authors { get; set; }
    }
}
