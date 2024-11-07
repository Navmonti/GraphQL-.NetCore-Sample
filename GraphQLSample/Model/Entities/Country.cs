using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GraphQLSample.Model.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }  

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        public ICollection<City> Cities { get; set; }  

        public Country()
        {
            Cities = new List<City>();
        }
    }

}
