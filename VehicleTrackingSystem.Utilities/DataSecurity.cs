using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTrackingSystem.Utilities
{
    public class DataSecurity
    {
        private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        // default private int BlockSize = 128;
        private int BlockSize = 128;
        private string key = "my_super_secret_key_aaaaaaaaaaaa";

        string symetricKey = "my_super_secret_key_aaaaaaaaaaaa"; // must be 256/8 = 32 byte


        public string Encrypt(string plainText, string keyString)
        {
            byte[] cipherData;
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(keyString);
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            ICryptoTransform cipher = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }

                cipherData = ms.ToArray();
            }

            byte[] combinedData = new byte[aes.IV.Length + cipherData.Length];
            Array.Copy(aes.IV, 0, combinedData, 0, aes.IV.Length);
            Array.Copy(cipherData, 0, combinedData, aes.IV.Length, cipherData.Length);
            return Convert.ToBase64String(combinedData);
        }

        public string EncryptData(string data)
        {

            byte[] bytes = Encoding.Unicode.GetBytes(data);
            string encrytedDate = "";
            //Encrypt

            SymmetricAlgorithm crypt = Aes.Create();
            // HashAlgorithm hash = MD5.Create();
            HashAlgorithm hashSHA256 = SHA256.Create();
            crypt.BlockSize = BlockSize;
            crypt.Key = hashSHA256.ComputeHash(Encoding.Unicode.GetBytes(key));
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                encrytedDate = Convert.ToBase64String(memoryStream.ToArray());
            }

            return encrytedDate;
        }

        public string DecryptData(string encryptData)
        {

            //byte[] bytes = Encoding.Unicode.GetBytes("I will be encrypted..");
            string decryptDate = "";
            encryptData = "AQIDBAUGBwgJCgsMDQ4PECS/9bqIO0Pnr4k21+UjJ6U=";
            //Encrypt
            //SymmetricAlgorithm crypt = Aes.Create();
            //HashAlgorithm hash = MD5.Create();
            //crypt.BlockSize = BlockSize;
            //crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes("hashvalue-12s"));
            //crypt.IV = IV;


            //Decrypt which text
            byte[] bytes = Convert.FromBase64String(encryptData);
            SymmetricAlgorithm crypt = Aes.Create();
            //HashAlgorithm hash = MD5.Create();
            HashAlgorithm hashSHA256 = SHA256.Create();
            crypt.Key = hashSHA256.ComputeHash(Encoding.Unicode.GetBytes(key));
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream =
                   new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    decryptDate = Encoding.Unicode.GetString(decryptedBytes);
                }
            }


            return decryptDate;
        }

        public static string CreateHashValue(string password)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] password_bytes = Encoding.UTF8.GetBytes(password);
            byte[] encrypted_bytes = sha256.ComputeHash(password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }

    }
}
