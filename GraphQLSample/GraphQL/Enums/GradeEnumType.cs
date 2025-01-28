using GraphQL.Types;
using GraphQLSample.Model.Enums;

namespace GraphQLSample.GraphQL.Enums
{
    public class GradeEnumType : EnumerationGraphType<Grade>
    {
        public GradeEnumType() {
            Name = "Grade";
        }
    }
}
