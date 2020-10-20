using System.Collections.Generic;

namespace AzureFunctionExample.ValidateAndExecutePattern
{
    public interface IValidation
    {
        bool Validate(out IEnumerable<string> errors);
    }
    
    public abstract class Validation : IValidation
    {
        public abstract bool Validate(out IEnumerable<string> errors);
    }
}
