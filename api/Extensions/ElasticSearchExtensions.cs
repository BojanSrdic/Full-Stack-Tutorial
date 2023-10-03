using Api.Models;
using Nest;

namespace Api.Extensions
{
    public static class ElasticSearchExtensions
    {
        // This is exstension methode for Elastic Search
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration) 
        {
            // Read from appsettings.json
            var url = configuration["ElasticConfiguration:Uri"];
            var defaultIndex = configuration["ElasticConfiguration:index"];

            var settings = new ConnectionSettings(new Uri(url)).PrettyJson().DefaultIndex(defaultIndex);

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);

        }

        // This methode is telling Elastic Search which feelds of the object want to search on and which feelds to ignore
        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<CryptoCoin>(p => p.Ignore(x => x.BuyPrice)
                .Ignore(x => x.Id).Ignore(x => x.CurrentPrice).Ignore(x => x.Amount));
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            client.Indices.Create(indexName, i => i.Map<CryptoCoin>(x => x.AutoMap()));
        }

    }
}