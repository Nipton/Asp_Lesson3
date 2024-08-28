using Microsoft.EntityFrameworkCore;
using Product_WarehouseManagementSystem.Abstractions;
using Product_WarehouseManagementSystem.Client;
using Product_WarehouseManagementSystem.Mutation;
using Product_WarehouseManagementSystem.Query;
using Product_WarehouseManagementSystem.Service;
using System.Net;
namespace Product_WarehouseManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? stringConnection = builder.Configuration.GetConnectionString("db");
            string? versionString = builder.Configuration.GetConnectionString("Version");
            var version = new MySqlServerVersion(new Version(versionString));

            builder.Services.AddDbContext<WarehouseProductsDbContext>(opt => { opt.UseLazyLoadingProxies(); opt.UseMySql(stringConnection, version); });
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IWarehouseProductsRepository, WarehouseProductsRepository>();
            builder.Services.AddGraphQLServer()
                .AddQueryType<WarhouseProductsQuery>()
                .AddMutationType<WarhouseProductsMutation>();
            var app = builder.Build();
            app.MapGraphQL();
          
            app.Run();
        }
    }
}
