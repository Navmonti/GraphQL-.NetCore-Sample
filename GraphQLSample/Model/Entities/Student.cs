using GraphQLSample.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLSample.Model.Entities
{
    /// <summary>
    /// Student Entity
    /// </summary>
    public class Student
    {
        /// <summary>
        /// The unique ID of the student.
        /// </summary>
        [Required]
        [Key]
        public int StudentId { get; set; }

        /// <summary>
        /// The first name of the student.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The last name of the student.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// The major of the student.
        /// </summary>
        [Required]
        public Major Major { get; set; }

        /// <summary>
        /// The grade level of the student.
        /// </summary>
        [Required]
        public Grade GradeLevel { get; set; }

        /// <summary>
        /// The ID of the school the student attends.
        /// </summary>
        [ForeignKey("School")]
        public int SchoolId { get; set; }

        /// <summary>
        /// The school of the student
        /// </summary>
        public School School { get; set; } = new School();

    }
}
