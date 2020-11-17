using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Book
    {
        [Key]
        public int idBook { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }
        public int Size { get; set; }
        public int Author_idAuthor { get; set; }
        [ForeignKey("Author_idAuthor")]
        public Author author { get; set; }
        public List<Record> records { get; set; }
    }
}
