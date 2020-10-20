using AzureFunctionExample.ValidateAndExecutePattern;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionExample.Calculator.Services
{
    public class DivisionService : Execution<double>, IExecution<double>
    {
        private readonly double number1;
        private readonly double number2;

        public DivisionService()
        {
            number1 = 0;
            number2 = 0;
        }

        public DivisionService(double n1, double n2)
        {
            number1 = n1;
            number2 = n2;
        }

        public override bool Validate(out IEnumerable<string> errors)
        {
            var errorsList = new List<string>();

            if (number2 == 0) { errorsList.Add("Divide by Zero error!"); }

            errors = errorsList;

            return !errors.Any();
        }

        protected override double Execute()
        {
            double result = number1/number2;

            return result;
        }
    }
}
