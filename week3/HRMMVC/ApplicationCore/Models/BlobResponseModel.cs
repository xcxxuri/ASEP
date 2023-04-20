using System;
namespace ApplicationCore.Models
{
    public class BlobResponseModel
    {
        public BlobResponseModel(Stream content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }
        public Stream? Content { get; }
        public string ContentType { get; }
    }
}

