using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePackagesGeneral.Utilities.Storage.Concrete
{
    public class BlobInfo
    {
        public string ContentType { get; set; }
        public Stream Content { get; set; }
        public BlobInfo(Stream content, string contentType)
        {
            Content = content;
            ContentType = contentType;
        }
    }
}
