using GraphQL.Types;
using GraphQLSample.Model.Entities;

namespace GraphQLSample.GraphQL.Types
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(x => x.StudentId).Description("The unique ID of the student.");
            Field(x => x.FirstName).Description("The first name of the student.");
            Field(x => x.LastName).Description("The last name of the student.");
            Field(x => x.Major).Description("The major of the student.");
            Field(x => x.GradeLevel).Description("The grade level of the student.");
            Field(x => x.SchoolId).Description("The ID of the school the student attends.");
            Field<SchoolType>("school").Description("The school of the student").Resolve(context => context.Source.School);
        }
    }
}
