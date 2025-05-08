using Microsoft.AspNetCore.Http;

namespace danone_client.Models.Responses

{
    public class Response
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public Response() { }
        public Response(int code, string msg)
        {
            statusCode = code;
            message = msg;
        }
    }
}
