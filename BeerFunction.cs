using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HotChocolate.AzureFunctionsProxy;
using System.Threading;

namespace Company.Function
{
    public class BeerFunction
    {

        private readonly IGraphQLAzureFunctionsExecutorProxy _graphqlExecutorProxy;

        public BeerFunction(IGraphQLAzureFunctionsExecutorProxy graphQLProxy)
        {
            _graphqlExecutorProxy = graphQLProxy;
        }


        [FunctionName("BeerFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql")] HttpRequest req,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");


            return await _graphqlExecutorProxy.ExecuteFunctionsQueryAsync(
                req.HttpContext,
                logger,
                cancellationToken
            ).ConfigureAwait(false);

        }
    }
}
