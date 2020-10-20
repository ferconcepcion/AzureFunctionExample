using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AzureFunctionExample.ValidateAndExecutePattern
{
    [Serializable]
    public class ValidationException : Exception
    {
        private readonly IEnumerable<string> _errors;

        public ValidationException() : base()
        {
            _errors = new List<string>();
        }

        public ValidationException(IEnumerable<string> errors) : this()
        {
            _errors = errors;
        }

        public ValidationException(string message) : base(message)
        {
            _errors = new List<string>();
        }

        public ValidationException(string message, IEnumerable<string> errors) : base(message)
        {
            _errors = errors;
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
            _errors = new List<string>();
        }

        public ValidationException(string message, Exception innerException, IEnumerable<string> errors) : base(message, innerException)
        {
            _errors = errors;
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string ToString()
        {
            return string.Format("Validation Exception: {0}More information: {1}", GetStringErrors(), base.ToString());
        }

        private string GetStringErrors()
        {
            string errors = string.Empty;

            foreach (var errorString in _errors)
            {
                errors = string.Format("{0}{1}. ", errors, errorString);
            }

            return errors;
        }
    }
}