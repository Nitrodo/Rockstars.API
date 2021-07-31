using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rockstars.Application.Helpers
{
    public static class FileHelper
    {
        public static IEnumerable<T> FileToObject<T>(IFormFile file)
        {
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var fileBytes = ms.ToArray();
            var json = Encoding.UTF8.GetString(fileBytes);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }
    }
}
