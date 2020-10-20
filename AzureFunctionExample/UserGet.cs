using System;
using System.IO;
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
    public static class UserGet
    {
        [FunctionName("UserGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "UsersGet/{id}")] HttpRequest req,
            Guid id,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var user = Db.GetUserById(id);
            var json = JsonConvert.SerializeObject(new
            {
                user = user
            });

            return (ActionResult)new OkObjectResult(json);
        }
    }
}
