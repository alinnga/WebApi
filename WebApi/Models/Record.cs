using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Record
    {
        [Key]
        public int idRecord { get; set; }
        public int Reader_idReader { get; set; }
        [ForeignKey("Reader_idReader")]
        public virtual Reader reader { get; set; }
        public int Book_idBook { get; set; }
        [ForeignKey("Book_idBook")]
        public virtual Book book { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfDelivery { get; set; }
    }
}
