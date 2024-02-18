using System.IO;
using System;
using OnlineShopWebApp.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Helpers
{
    public class ImageProvider
    {
        public static void SaveProductImages(string folderPath, ProductViewModel product)
        {
            if (product.UpFiles is null)
                return;

            var images = new List<string>();

            foreach (var img in product.UpFiles)
            {
                var link = SaveImage(folderPath, img);
                images.Add(link);
            }
            product.ImageLink = images[0];
            product.ImageLinks = images;
        }

        public static string SaveImage(string folderPath, IFormFile image)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (image is not null)
            {
                var fileName = Guid.NewGuid() + "." + image.FileName.Split('.').Last();
                var path = Path.Combine(folderPath, fileName);
                var relPath = string.Join("/", folderPath.Split('/').TakeLast(2));  
                
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                return $"/{relPath}/{fileName}";
            }
            return null;
        }

    }
}
