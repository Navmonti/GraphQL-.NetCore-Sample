using GraphQLSample.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Data
{
    public class SchoolAppDbContext : DbContext
    {
        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
