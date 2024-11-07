using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Model.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; } 

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<School> Schools { get; set; } 

        public City()
        {
            Schools = new List<School>();
        }
    }
}
