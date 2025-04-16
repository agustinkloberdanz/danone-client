namespace danone_client.Models.Responses

{
    public class ResponseCollection<T> : Response
    {
        public ResponseCollection(int code, string msg, List<T> model)
        {
            statusCode = code;
            message = msg;
            this.model = model;
        }

        public List<T> model { get; set; }
    }
}

