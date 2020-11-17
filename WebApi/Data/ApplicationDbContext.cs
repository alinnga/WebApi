using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Reader> reader { get; set; }
        public virtual DbSet<Author> author { get; set; }
        public virtual DbSet<Book> book { get; set; }
        public virtual DbSet<Record> record { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        public DbSet<WebApi.Models.ReaderDTO> ReaderDTO { get; set; }

    }
}
