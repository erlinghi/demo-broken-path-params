using Microsoft.AspNetCore.Mvc;

namespace reproduce_missing_path_params.Controllers;

[Route("site/{siteId}")]
public class TestController : ControllerBase
{
    [HttpGet("{someParam}/{someOtherParam}")]
    public NoContentResult WillFailOnSiteId(int siteId, int someParam, string someOtherParam)
    {
        Console.WriteLine(siteId); 
        Console.WriteLine(someParam); 
        Console.WriteLine(someOtherParam); 
        Console.WriteLine(":S"); 
        return NoContent();
    }
}