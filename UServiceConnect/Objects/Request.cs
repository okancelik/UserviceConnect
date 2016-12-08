using System.Net.Http.Headers;

namespace UServiceConnect.Objects
{
    public class Request
    {
        public string Uri { get; set; }
        public string Method { get; set; }
        public string Content_Type { get; set; }
        public AuthenticationHeaderValue Authorization { get; set; }
        public string[] Headers { get; set; }
        public string Body { get; set; }
    }
}
