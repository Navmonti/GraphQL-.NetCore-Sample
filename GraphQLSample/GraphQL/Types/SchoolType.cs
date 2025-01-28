using GraphQL.Types;
using GraphQLSample.Model.Entities;

namespace GraphQLSample.GraphQL.Types
{
    public class SchoolType : ObjectGraphType<School>
    {
        public SchoolType() {
            Field(x => x.SchoolId).Description("The unique ID of the school.");
            Field(x => x.Name).Description("The name of the school.");
            Field(x => x.CityId).Description("The ID of the city the school is located in.");
            Field<CityType>("city").Description("The city where the school is located").Resolve(context => context.Source.City);
            Field<ListGraphType<StudentType>>("students").Description("The students enrolled in this school").Resolve(context => context.Source.Students);
        }
    }
}
