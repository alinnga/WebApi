using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Author
    {
        [Key]
        public int idAuthor { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Book> books { get; set; }
    }
}
