using System;
namespace SLFormsApp.Models
{
    public class ResponseError
    {
        public ResponseError(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; }

        public string Message { get; }
    }
}
