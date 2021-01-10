using HotChocolate;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using HotChocolate.AzureFunctionsProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using Test;

[assembly: FunctionsStartup(typeof(Test.Startup))]
namespace Test
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;
            services.AddGraphQLServer()
                 .AddQueryType(d => d.Name("Query"))
                //.AddMutationType(d => d.Name("Mutation"))
                .AddType<BeerQueries>();

            services.AddAzureFunctionsGraphQL();
        }
    }
}