using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctionExample.DataBase;

namespace AzureFunctionExample
{
    public static class UsersGet
    {
        [FunctionName("UsersGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var json = JsonConvert.SerializeObject(new { users = Db.GetUsers() });

            return new OkObjectResult(json);
        }
    }
}
