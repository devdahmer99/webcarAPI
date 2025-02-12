using System.Net;

namespace webcarsAPI.Exception.ExceptionBase
{
    public class LoginInvalidException : webCarsException
    {
        public LoginInvalidException() : base(ResourceErrorMessages.EMAIL_AND_PASSWORD_NOT_MATCH)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> getErrors()
        {
            return [Message];
        }
    }
}
