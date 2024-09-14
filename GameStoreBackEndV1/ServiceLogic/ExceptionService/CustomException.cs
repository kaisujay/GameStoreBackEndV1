namespace GameStoreBackEndV1.ServiceLogic.ExceptionService
{
    public class NotFoundException : Exception
    {
        public int StatusCode { get; set; }

        public NotFoundException() : base()
        {
            StatusCode = StatusCodes.Status404NotFound;
        }

        public NotFoundException(string message) : base(message)
        {
            StatusCode = StatusCodes.Status404NotFound;
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = StatusCodes.Status404NotFound;
        }
    }

    public class ExternalResourceNotFoundException : Exception
    {
        public int StatusCode { get; set; }

        public ExternalResourceNotFoundException() : base()
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        public ExternalResourceNotFoundException(string message) : base(message)
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }

        public ExternalResourceNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    public class DataAlreadyExistsException : Exception
    {
        public int StatusCode { get; set; }

        public DataAlreadyExistsException() : base()
        {
            StatusCode = StatusCodes.Status409Conflict;
        }

        public DataAlreadyExistsException(string message) : base(message)
        {
            StatusCode = StatusCodes.Status409Conflict;
        }

        public DataAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = StatusCodes.Status409Conflict;
        }
    }
}
