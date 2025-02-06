namespace webcarsAPI.Exception.ExceptionBase
{
    public abstract class webCarsException : SystemException
    {
        protected webCarsException(string message) : base(message)
        {
        }

        public abstract int StatusCode { get; }
        public abstract List<string> getErrors();
    }
}
