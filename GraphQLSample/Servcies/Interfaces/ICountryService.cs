using GraphQLSample.Model.Entities;

namespace GraphQLSample.Servcies.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryByIdAsync(int id);
        Task<Country> AddCountryAsync(Country country);
        Task<Country> UpdateCountryAsync(int id, Country country);
        Task<Country> DeleteCountryAsync(int id);
    }
}
