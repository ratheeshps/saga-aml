using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmlService.Models
{
    public class TraxDbContext:DbContext
    {
        public TraxDbContext() { }

        public TraxDbContext(DbContextOptions<TraxDbContext> options) : base(options)
        {
        }

        public DbSet<AmlData> AmlTransactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CTINLT006;initial catalog=NewTrax;integrated security=true");
        }
    }
}
