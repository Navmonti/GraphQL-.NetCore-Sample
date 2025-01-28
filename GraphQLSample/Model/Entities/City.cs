using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraphQLSample.Model.Entities
{
    /// <summary>
    /// City Entity
    /// </summary>
    public class City
    {
        public City() => Schools = new List<School>();

        /// <summary>
        /// The unique ID of the city.
        /// </summary>
        [Required]
        [Key]
        public int CityId { get; set; }

        /// <summary>
        /// The name of the city.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the country the city belongs to.
        /// </summary>
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        /// <summary>
        /// The country of the city
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The schools located in this city
        /// </summary>
        public ICollection<School> Schools { get; set; } 

    }
}
