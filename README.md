This repo is to provide a project that reproduces the issue described in https://github.com/aws/aws-lambda-dotnet/issues/1233 

Setup:
Install and setup Lambda test tools for .NET Core 6.0 as described in https://github.com/aws/aws-lambda-dotnet/tree/master/Tools/LambdaTestTool
Make sure you build the project in src/reproduce-missing-path-params for debug, otherwise the tool won't work.

Running:
run dotnet lambda-test-tool-6.0 in src/reproduce-missing-path-params. Once the browser is open; paste the example requests provided down below:

Scenario : resource has path parameters and proxy+
Result: {siteId} is provided to the controller instead of 2626 
```
{
    "Resource": "/site/{siteId}/{proxy+}",
    "Path": "/api/payment/site/2626/123123/asdasd",
    "HttpMethod": "GET",
    "Headers":
    {
    },
    "MultiValueHeaders":
    {
    },
    "QueryStringParameters": null,
    "MultiValueQueryStringParameters": null,
    "PathParameters":
    {
        "proxy": "123123/asdasd",
        "siteId": "2626"
    },
    "StageVariables": null,
    "RequestContext":
    {
        
    },
    "Body": null,
    "IsBase64Encoded": false
}
```
