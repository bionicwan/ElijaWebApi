using System;
using System.IO;
using System.Net;
using ImageResizer;

namespace FreakyByte.Elija.Processing.Helpers
{
    public static class ImageProcessingHelper
    {
        #region Public Methods and Operators

        public static string ResizeImage(string url)
        {
            Stream outputImage = new MemoryStream();
            using (var downloader = new WebClient())
            {
                Stream inputImage = downloader.OpenRead(url);
                var resizeSettings = new ResizeSettings {/*MaxHeight = 350, MaxWidth = 350,*/ Quality = 50};
                ImageBuilder.Current.Build(inputImage, outputImage, resizeSettings, true);
            }
            byte[] fileDataInByte = null;
            using (var binaryReader = new BinaryReader(outputImage))
            {
                outputImage.Position = 0;
                fileDataInByte = binaryReader.ReadBytes((int) outputImage.Length);
            }
            return Convert.ToBase64String(fileDataInByte);
        }

        #endregion
    }
}