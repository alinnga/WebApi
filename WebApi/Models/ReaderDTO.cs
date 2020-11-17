using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ReaderDTO
    {
        [Key]
        public int idReader { get; set; }
        public string Name { get; set; }
    }
}
