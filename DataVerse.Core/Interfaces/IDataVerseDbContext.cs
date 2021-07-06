using DataVerse.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Interfaces
{
    public interface IDataVerseDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Phones> Phones { get; set; }

        public int SaveChanges();
    }
}
