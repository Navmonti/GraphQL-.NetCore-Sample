using GraphQL.Types;
using GraphQLSample.Model.Entities;

namespace GraphQLSample.GraphQL.Types
{
    public class CityType : ObjectGraphType<City>
    {
        public CityType() {
            Field(x => x.CityId).Description("The unique ID of the city.");
            Field(x => x.Name).Description("The name of the city.");
            Field(x => x.CountryId).Description("The ID of the country the city belongs to.");
            Field<CountryType>("country").Description("The country of the city").Resolve(context => context.Source.Country);
            Field<ListGraphType<SchoolType>>("schools").Description("The schools located in this city").Resolve(context => context.Source.Schools);
        }
    }
}
