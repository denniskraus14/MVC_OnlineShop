using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVC_OnlineShop.Infrastructure {
    public class AES {

        /// <summary>
        /// This will grab the string input and encrypt it using AES. Then once it has been encrypted it will output the
        /// encryption into a string. 
        /// </summary>
        /// <param name="clearText">string to encrypt into AES</param>
        /// <returns>Return the AES encryption string</returns>
        public string Encryption(string clearText) {
            string EncryptionKey = "A4JE6UR8I3B89MDHAJ4KIWQP7L1MD9JE";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}