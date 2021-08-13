using Challenge.BGLobal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.BGLobal.Context
{
    public class BGlobalContext : DbContext
    {
        private const string Schema = "BGlobal";

        public BGlobalContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }

        public DbSet<Vehicle> Vehicles { get; set; } = null;
    }
}
