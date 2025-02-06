
using System.Net;

namespace webcarsAPI.Exception.ExceptionBase
{
    public class ErrorOnValidateException : webCarsException
    {
        private readonly List<string> _errors;
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public ErrorOnValidateException(List<string> errorMessages) : base(string.Join(";", errorMessages))
        {
            if(errorMessages == null || !errorMessages.Any())
            {
                throw new ArgumentException("Mensagens de erro não podem ser nulas ou vazias", nameof(errorMessages));
            }
            _errors = errorMessages;
        }


        public override List<string> getErrors()
        {
            return _errors;
        }
    }
}
