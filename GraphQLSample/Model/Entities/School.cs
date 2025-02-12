using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Model.Entities
{
    /// <summary>
    /// School Entity
    /// </summary>
    public class School
    {
        public School() => Students = new List<Student>();

        /// <summary>
        /// The unique ID of the school.
        /// </summary>
        [Required]
        [Key]
        public int SchoolId { get; set; }

        /// <summary>
        /// The name of the school.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the city the school is located in.
        /// </summary>
       
        public int CityId { get; set; }

        /// <summary>
        /// The city where the school is located
        /// </summary>
        [ForeignKey("CityId")]
        public City City { get; set; }

        /// <summary>
        /// The students enrolled in this school
        /// </summary>
        public ICollection<Student> Students { get; set; }  

    }
}
