using System.Collections.Generic;

namespace WEB_API_App.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //define relationships

        public List<Book> Books { get; set; }
    }
}
