using delivery_order_services.Domain.Domain;
using delivery_order_services.Domain.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace delivery_order_services.ServicesCollectionExtensions
{
    public static class ServicesCollectionExtensions
    {
        private static readonly string ConnectionString = "MongoDb";

        public static IServiceCollection AddAllExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddMongoDbExtension(configuration)
                .AddRepositoriesExtension(configuration);


            return services;
        }

        public static IServiceCollection AddMongoDbExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton(sp =>
                            new MongoDbContext(
                                configuration.GetConnectionString(ConnectionString)!,
                                "MinhaBaseDeDados"
                            ));


            return services;
        }

        public static IServiceCollection AddRepositoriesExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.TryAddScoped<UserRepository>();

            return services;
        }
    }
}
