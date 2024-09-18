using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DetailsDbContext :DbContext
    {
        public DetailsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Details> Detail { get; set; }
    }
}
