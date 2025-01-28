using GraphQL.Types;
using GraphQLSample.Model.Enums;

namespace GraphQLSample.GraphQL.Enums
{
    public class MajorEnumType : EnumerationGraphType<Major>
    {
        public MajorEnumType() {
            Name = "Major";   
        }
    }
}
