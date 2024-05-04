using Cooking.Domain.Entities;
using Cooking.Infrastructure.Repositories;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.DependencyInjection;

namespace Cooking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ElasticsearchClient>(sp =>
        {
            var uri = "https://127.0.0.1:9200";
            var settings = new ElasticsearchClientSettings(new Uri(uri))
                .CertificateFingerprint(
                    "EE:F0:8A:14:46:A1:9D:B0:2D:CC:38:82:00:B7:EE:A1:02:C6:49:FC:89:E7:0C:0A:88:E8:6C:AB:E7:F8:5F:E3")
                .Authentication(new BasicAuthentication("elastic", "95zVgchw9ow682")
                ).DisableDirectStreaming(true);
            return new ElasticsearchClient(settings);
        });

        //TODO:
        services.AddTransient<IRepository<Recipe>, RecipeRepository>();

        return services;
    }
}