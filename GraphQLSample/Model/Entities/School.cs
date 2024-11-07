using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Model.Entities
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }  

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }  

        public City City { get; set; }

        public ICollection<Student> Students { get; set; }  

        public School()
        {
            Students = new List<Student>();
        }
    }
}
