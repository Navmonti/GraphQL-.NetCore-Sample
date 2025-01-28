using GraphQL.Types;
using GraphQLSample.Model.Entities;

namespace GraphQLSample.GraphQL.Types
{
    public class CountryType : ObjectGraphType<Country>
    {
        public CountryType()
        {
            Field(x => x.CountryId).Description("The unique ID of the country.");
            Field(x => x.Name).Description("The name of the country.");
            Field(x => x.Code).Description("The 3-letter code of the country.");
            Field<ListGraphType<CityType>>("cities").Description("The cities in this country").Resolve(context => context.Source.Cities);
        }
    }
}
