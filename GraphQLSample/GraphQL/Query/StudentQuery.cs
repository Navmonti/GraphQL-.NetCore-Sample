using GraphQL;
using GraphQL.Types;
using GraphQLSample.GraphQL.Types;
using GraphQLSample.Repasitories.Implements;

namespace GraphQLSample.GraphQL.Query
{
    public class StudentQuery : ObjectGraphType
    {
        public StudentQuery(IStudentRepository studentRepo)
        {
            Field<ListGraphType<StudentType>>()
                .Description("students")
                .ResolveAsync(async context => await studentRepo.GetAllStudentsAsync());


            Field<StudentType>("student")
            .Description("Get a student by ID")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "ID of the student" }
            ))
            .ResolveAsync(async context =>
            {
                var id = context.GetArgument<int>("id");
                return await studentRepo.GetStudentByIdAsync(id);
            });
        }
    }
}
