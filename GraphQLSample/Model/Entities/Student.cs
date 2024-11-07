using GraphQLSample.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLSample.Model.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } 

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public Major Major { get; set; }

        [Required]
        public Grade GradeLevel { get; set; }

        [ForeignKey("School")]
        public int SchoolId { get; set; } 

        public School School { get; set; }

        public Student()
        {
        }
    }
}
