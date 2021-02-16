using MVC_OnlineShop.Models;
using System.IO;
using System.Web;

namespace MVC_OnlineShop.Model {
    public class ContentRepository {

        /// <summary>
        /// Converts an image into bytes for saving to database
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public byte[] ConvertToBytes(HttpPostedFileBase file) {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(file.InputStream); // TODO: Revamp to more secure Reader
            imageBytes = reader.ReadBytes( (int) file.ContentLength);
            return imageBytes;
        }

    }
}