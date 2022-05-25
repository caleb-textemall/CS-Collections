namespace Acme.Common
{
    /// <summary>
    /// Provides a success flag and message 
    /// useful as a method return type.
    /// </summary>
    public class OperationResult<T>  // T is called a "type parameter"
    // this makes the class a "generic" class because of the type parameter T
    // it is good practice to start all type parameters with the letter T
    // so that they can be easily identified as a type parameter    
    {
        // public OperationResult() {}

        public OperationResult(T result, string message)
        {
            this.result = result;
            this.Message = message;
        }

        public T result { get; set; }
        public string Message { get; set; }
    }

}
