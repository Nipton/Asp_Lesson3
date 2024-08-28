using Asp_Lesson1.Repositories;
using Asp_Lesson3.Abstractions;
using Asp_Lesson3.Models;
using Asp_Lesson3.Services;
using Asp_Lesson3.Query;
using Microsoft.EntityFrameworkCore;
using Asp_Lesson3.Mutation;

namespace Asp_Lesson3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddMemoryCache();

            string? connectionString = builder.Configuration.GetConnectionString("db");
            string? versionString = builder.Configuration.GetConnectionString("Version");
            var version = new MySqlServerVersion(new Version(versionString));
            builder.Services.AddDbContext <ProductsDbContext>(dbContextOption => { dbContextOption.UseLazyLoadingProxies(); dbContextOption.UseMySql(connectionString, version); });

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<QueryProduct>()
                .AddMutationType<MutationProduct>();
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.MapGraphQL();          
            app.Run();
        }
    }
}
