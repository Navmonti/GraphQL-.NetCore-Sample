using GraphQLSample.Model.Entities;
using GraphQLSample.Model.Enums;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, Name = "United States", Code = "USA" },
                new Country { CountryId = 2, Name = "Canada", Code = "CAN" }
            );

            // Seed Cities
            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, Name = "New York", CountryId = 1 },
                new City { CityId = 2, Name = "Los Angeles", CountryId = 1 },
                new City { CityId = 3, Name = "Toronto", CountryId = 2 }
            );

            // Seed Schools
            modelBuilder.Entity<School>().HasData(
                new School { SchoolId = 1, Name = "New York High School", CityId = 1 },
                new School { SchoolId = 2, Name = "Los Angeles Academy", CityId = 2 },
                new School { SchoolId = 3, Name = "Toronto Public School", CityId = 3 }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", Major = Major.ComputerScience, GradeLevel = Grade.Senior, SchoolId = 1 },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", Major = Major.Mathematics, GradeLevel = Grade.Junior, SchoolId = 2 },
                new Student { StudentId = 3, FirstName = "Mike", LastName = "Johnson", Major = Major.Physics, GradeLevel = Grade.Sophomore, SchoolId = 3 },
                new Student { StudentId = 4, FirstName = "Emma", LastName = "Brown", Major = Major.Engineering, GradeLevel = Grade.Senior, SchoolId = 1 },
                new Student { StudentId = 5, FirstName = "Liam", LastName = "Williams", Major = Major.Engineering, GradeLevel = Grade.Senior, SchoolId = 2 },
                new Student { StudentId = 6, FirstName = "Olivia", LastName = "Davis", Major = Major.Mathematics, GradeLevel = Grade.Junior, SchoolId = 3 },
                new Student { StudentId = 7, FirstName = "Noah", LastName = "Miller", Major = Major.ComputerScience, GradeLevel = Grade.Sophomore, SchoolId = 1 },
                new Student { StudentId = 8, FirstName = "Ava", LastName = "Wilson", Major = Major.Physics, GradeLevel = Grade.Senior, SchoolId = 2 },
                new Student { StudentId = 9, FirstName = "William", LastName = "Moore", Major = Major.Engineering, GradeLevel = Grade.Senior, SchoolId = 3 }
            );
        }
    }
}
