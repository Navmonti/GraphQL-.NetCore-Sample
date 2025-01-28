using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraphQLSample.Model.Entities
{
    /// <summary>
    /// Country Entity
    /// </summary>
    public class Country
    {
        public Country() => Cities = new List<City>();

        /// <summary>
        /// The unique ID of the country.
        /// </summary>
        [Key]
        public int CountryId { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// The 3-letter code of the country.
        /// </summary>
        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        /// <summary>
        /// The cities in this country
        /// </summary>
        public ICollection<City> Cities { get; set; }

    }

}
