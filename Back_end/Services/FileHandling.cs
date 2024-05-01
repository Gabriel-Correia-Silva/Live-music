using System.IO;
using System.Threading.Tasks;

namespace Back_end.Services
{
    public class FileHandling
    {
        public async Task<byte[]> ReadFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            return await File.ReadAllBytesAsync(filePath);
        }

        public void ValidateFile(byte[] fileData)
        {
            if (fileData == null || fileData.Length == 0)
            {
                throw new InvalidDataException("File is empty or null");
            }

            // Add more validation if needed
        }
    }
}
