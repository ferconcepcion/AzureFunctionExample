using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Web.Http;
using AzureFunctionExample.ValidateAndExecutePattern;
using AzureFunctionExample.Calculator.Services;

namespace AzureFunctionExample
{
    public static class DivisionFunction
    {
        [FunctionName("DivisionFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Division/{number1}/{number2}")] HttpRequest req,
            string number1,
            string number2,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            double n1, n2;

            try
            {
                n1 = double.Parse(number1);
                n2 = double.Parse(number2);
            }
            catch (Exception ex)
            {
                string errorEx = string.Format(
                    "Parsing error with parameters {0} and {1}, please insert double values. More details: {2}",
                    number1,
                    number2,
                    ex.ToString());

                return new BadRequestErrorMessageResult(errorEx);
            }

            IExecution<double> sumOperation = new DivisionService(n1, n2);

            try
            {
                var result = await sumOperation.UnSafeExecuteAsync().ConfigureAwait(false);

                var responseMessage = string.Format("Result: {0} .", result);

                return new OkObjectResult(responseMessage);
            }
            catch (ValidationException vex)
            {
                return new BadRequestErrorMessageResult(vex.ToString());
            }
            catch (Exception)
            {
                return new InternalServerErrorResult();
            }
        }
    }
}