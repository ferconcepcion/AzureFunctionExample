using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunctionExample.ValidateAndExecutePattern
{
    public interface IExecution<T> : IValidation
    {
        T SafeExecute(out IEnumerable<string> errors);
        T UnSafeExecute();
        Task<T> UnSafeExecuteAsync();
    }

    public abstract class Execution<T> : Validation, IExecution<T>
    {
        protected abstract T Execute();

        public T SafeExecute(out IEnumerable<string> errors)
        {
            if (Validate(out errors))
            {
                return Execute();
            }

            return default;
        }

        public T UnSafeExecute()
        {
            if (Validate(out IEnumerable<string> errors))
            {
                return Execute();
            }

            throw new ValidationException(errors);
        }

        public Task<T> UnSafeExecuteAsync()
        {
            return Task.Run(() => UnSafeExecute());
        }
    }
}
