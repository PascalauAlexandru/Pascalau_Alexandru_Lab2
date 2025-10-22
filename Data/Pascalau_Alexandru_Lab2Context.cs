using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pascalau_Alexandru_Lab2.Models;

namespace Pascalau_Alexandru_Lab2.Data
{
    public class Pascalau_Alexandru_Lab2Context : DbContext
    {
        public Pascalau_Alexandru_Lab2Context (DbContextOptions<Pascalau_Alexandru_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Pascalau_Alexandru_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Pascalau_Alexandru_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Pascalau_Alexandru_Lab2.Models.Author> Authors { get; set; } = default!;
    }
}
