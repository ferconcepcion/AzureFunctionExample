using AzureFunctionExample.ValidateAndExecutePattern;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionExample.Calculator.Services
{
    public class SumService : Execution<double>, IExecution<double>
    {
        private readonly IEnumerable<double> _numbers;

        public SumService()
        {
            _numbers = new List<double>();
        }
        
        public SumService(double n1, double n2)
        {
            _numbers = new List<double>() { n1, n2 };
        }

        public SumService(IEnumerable<double> numbers)
        {
            _numbers = numbers;
        }

        public override bool Validate(out IEnumerable<string> errors)
        { 
            var errorsList = new List<string>();

            if (_numbers == null || !_numbers.Any()) { errorsList.Add("No hay números para sumar!"); }

            errors = errorsList;

            return !errors.Any();
        }

        protected override double Execute()
        {
            double result = 0;

            foreach(double n in _numbers)
            {
                result += n;
            }

            return result;
        }
    }
}
