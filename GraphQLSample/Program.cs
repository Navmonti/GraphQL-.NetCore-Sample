using GraphQL; 
using GraphQL.Types;
using GraphQLSample.Data;
using GraphQLSample.GraphQL.Types;
using GraphQLSample.GraphQL;
using GraphQLSample.Repasitories.Implements;
using GraphQLSample.Servcies.Implements;
using GraphQLSample.Servcies.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolAppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//GraphQL
builder.Services
    .AddSingleton<CountryType>()
    .AddSingleton<CityType>()
    .AddSingleton<SchoolType>()
    .AddSingleton<StudentType>()
    .AddSingleton<Query>()
    .AddSingleton<ISchema, AppSchema>()
    .AddGraphQL(builder => builder
        .AddSystemTextJson()
    );


//Services
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICountryService, CountryService>();

//Repository 
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//        options.JsonSerializerOptions.WriteIndented = true;
//    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGraphQLGraphiQL("/ui/graphql");


app.UseAuthorization();

app.MapControllers();

app.Run();
