using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store_app_be_portal.gRPCClient;

namespace store_app_be_portal.Controllers
{
    [Route("Product/[controller]")]
    [ApiController]
    public class ProductController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            GreeterClient client = new GreeterClient(configuration);
            var result = client.SayHelloAsync("Product Service").Result;
            return result;
        }
    }
}
