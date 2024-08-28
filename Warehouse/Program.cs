using Microsoft.EntityFrameworkCore;
using Warehouse.Abstactions;
using Warehouse.Mutation;
using Warehouse.Query;
using Warehouse.Services;

namespace Warehouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            string? stringConnection = builder.Configuration.GetConnectionString("db");
            string? versionString = builder.Configuration.GetConnectionString("Version");
            var version = new MySqlServerVersion(new Version(versionString));
            builder.Services.AddDbContext<WarehouseDbContext>(opt => { opt.UseLazyLoadingProxies(); opt.UseMySql(stringConnection, version); });
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            builder.Services.AddGraphQLServer()
                .AddQueryType<WarehouseQuery>()
                .AddMutationType<WarehouseMutation>();
            var app = builder.Build();
            app.MapGraphQL();
            app.Run();
        }
    }
}
