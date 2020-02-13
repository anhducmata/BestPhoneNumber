using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BestPhoneNumber.Services
{
    public class FileService
    {
        public List<string> ReadPhoneNumberList(string filePath)
        {
            var result = new List<string>();
            using (var streamReader = File.OpenText(filePath))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                result.AddRange(lines);
            }

            return result;
        }
    }
}
