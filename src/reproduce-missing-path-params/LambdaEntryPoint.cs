using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.AspNetCoreServer.Internal;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Mvc;

// makes it so every controller has this attribute
[assembly: ApiController]

namespace reproduce_missing_path_params;

public class LambdaEntryPoint :

    Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
{
    // workaround for broken path params
    /*
    protected override void MarshallRequest(InvokeFeatures features, APIGatewayProxyRequest apiGatewayRequest, ILambdaContext lambdaContext)
    {
        UseFixForProxyReplacementBugInApiGatewayProxyFunction(apiGatewayRequest);

        base.MarshallRequest(features, apiGatewayRequest, lambdaContext);
    }

    private static void UseFixForProxyReplacementBugInApiGatewayProxyFunction(APIGatewayProxyRequest apiGatewayRequest)
    {
        if (apiGatewayRequest.PathParameters == null || !apiGatewayRequest.PathParameters.ContainsKey("proxy") || string.IsNullOrEmpty(apiGatewayRequest.Resource))
        {
            return;
        }

        foreach (var pathParameter in apiGatewayRequest.PathParameters.Where(x => x.Key != "proxy"))
        {
            apiGatewayRequest.Resource = apiGatewayRequest.Resource.Replace($"{{{pathParameter.Key}}}", pathParameter.Value);
        }
    }
    */
    protected override void Init(IWebHostBuilder builder)
    {
        Console.WriteLine("lambda entry point");
        builder
            .UseStartup<Startup>();
    }
   
    protected override void Init(IHostBuilder builder)
    {
        Console.WriteLine("lambda entry point");
    }
}