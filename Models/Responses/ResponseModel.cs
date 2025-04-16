namespace danone_client.Models.Responses

{
    public class ResponseModel<T> : Response
    {
        public ResponseModel(int code, string msg, T model)
        {
            statusCode = code;
            message = msg;
            this.model = model;
        }

        public T model { get; set; }
    }
}