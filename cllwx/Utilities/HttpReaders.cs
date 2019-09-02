using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace cllwx.Utilities
{
    public interface IHttpReaders
    {
        string ReadBodyAsString(HttpRequest request);
    }
    public class HttpReaders
    {
        public string ReadBodyAsString(HttpRequest request)
        {
            var initialBody = request.Body; // Workaround

            try
            {
                request.EnableRewind();

                using (StreamReader reader = new StreamReader(request.Body))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
            finally
            {
                // Workaround so MVC action will be able to read body as well
                request.Body = initialBody;
            }

            return string.Empty;
        }
    }
}
