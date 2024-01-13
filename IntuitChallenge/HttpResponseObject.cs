namespace IntuitChallenge
{
    public class HttpResponseObject
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }

        private HttpResponseObject(bool success, string message, object data)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
        }

        public static HttpResponseObject Success(object data = null)
        {
            return new HttpResponseObject(true, "Operación exitosa", data);
        }

        public static HttpResponseObject Failure(string message)
        {
            return new HttpResponseObject(false, message, null);
        }
    }

}
