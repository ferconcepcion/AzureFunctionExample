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
    public static class UserCreate
    {
        [FunctionName("UserCreate")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = null, surname = null;
            DateTimeOffset birthday = default;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation("request body", requestBody);
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            surname = surname ?? data?.surname;
            birthday = birthday != default ? data?.birthday : default;

            if (name != null && surname != null && birthday != default)
            {
                log.LogInformation("name", name);
                var user = Db.CreateUser(name, surname, birthday);
                var json = JsonConvert.SerializeObject(new
                {
                    user
                });
                return new OkObjectResult(json);
            }
            else
            {
                return new BadRequestObjectResult("Missing name, surname or birthday in posted Body");
            }
        }
    }
}