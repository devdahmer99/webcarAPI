namespace webcarsAPI.Comunicacao.Responses.Errors
{
    public class ResponseErrors
    {
        public List<string> Errors { get; set; }

        public ResponseErrors(string errorMessage)
        {
            Errors = new List<string> { errorMessage };
        }

        public ResponseErrors(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
