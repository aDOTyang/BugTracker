namespace BugTracker.Services.Interfaces;

public class FileService : IFileService
{
    // private readonly string[] suffixes = { "Bytes", "KB, "MB, "GB", "TB", "PB" }
    private readonly string _defaultBTUserImageSrc = "/img/DefaultUserImage.png";
    private readonly string _defaultCompanyImageSrc = "/img/YOW.png";
    private readonly string _defaultProjectImageSrc = "/img/DefaultProjectImage.png";
    public string ConvertByteArrayToFile(byte[] fileData, string extension, int defaultImage)
    {
        if (fileData == null)
        {
            switch (defaultImage)
            {
                case 1: return _defaultBTUserImageSrc;
                case 2: return _defaultCompanyImageSrc;
                case 3: return _defaultProjectImageSrc;
            }
        }

        // try-catch statement will allow application to run despite exceptions/errors
        try
        {
            // converts the byte array to string and outputs as variable imageBase64Data
            string imageBase64Data = Convert.ToBase64String(fileData);
            // formats the data into a string that can be read by HTML img tag
            string imageSrcString = string.Format($"data:{extension};base64,{imageBase64Data}");

            return imageSrcString;

        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
    {
        try
        {
            // the using statement will clean up after itself by immediately reallocating the used memory
            // MemoryStream reads, buffers, and creates a cache memory of incoming data before feeding it to the PC for use
            using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] byteFile = memoryStream.ToArray();
            memoryStream.Close();
            return byteFile;

        }
        catch (Exception)
        {
            throw;
        }
    }
}
