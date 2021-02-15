using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC_OnlineShop.Models
{
    public class ContentRepository
    {
        private readonly CustomerContext context = new CustomerContext();

        public int UploadImageInDataBase(HttpPostedFileBase file, Customer model)
        {
            model.File = ConvertToBytes(file);
            
                context.Customers.Add(model);
                int i = context.SaveChanges();
                if (i == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
        }

        private byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(file.InputStream);
            imageBytes = reader.ReadBytes((int)file.ContentLength);
            return imageBytes;
        }
    }
}