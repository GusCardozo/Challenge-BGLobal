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

            builder.Entity<Brand>().HasData(
                new Brand
                {
                    Id = 1,
                    Name = "Ford"
                },
                new Brand
                {
                    Id = 2,
                    Name = "Fiat"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Peugeot"
                },
                new Brand
                {
                    Id = 4,
                    Name = "Mercedes Benz"
                },
                new Brand
                {
                    Id = 5,
                    Name = "Audi"
                },
                new Brand
                {
                    Id = 6,
                    Name = "BMW"
                },
                new Brand
                {
                    Id = 7,
                    Name = "Renault"
                });
        }

        public DbSet<Vehicle> Vehicles { get; set; } = null;
        public DbSet<Brand> Brands { get; set; } = null;
    }
}
