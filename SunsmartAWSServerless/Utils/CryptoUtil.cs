using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace SunsmartAWSServerless.Utils
{
    public static class CryptoUtil
    {
        /// <summary>
        /// Encrypt string using AES
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="encSymmetric"></param>
        /// <param name="encSlt"></param>
        /// <returns></returns>
        public static string EncryptStringAES(string plainText, string encSymmetric = "", string encSlt = "")
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText is null");
            if (string.IsNullOrEmpty(encSymmetric))
                encSymmetric = Constants.encSymmetric;
            if (string.IsNullOrEmpty(encSlt))
                encSlt = Constants.encSalt;

            string outStr = null; // Encrypted string to return
            RijndaelManaged aesAlg = null; // RijndaelManaged object used to encrypt the data.

            try
            {
                var sltArry = Encoding.ASCII.GetBytes(encSlt);
                // generate the key from the shared secret and the salt
                var key = new Rfc2898DeriveBytes(encSymmetric, sltArry);

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Create a decryptor to perform the stream transform.
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    // prepend the IV
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (var csEncrypt =
                        new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }

                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt String using AES
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="encSymmetric"></param>
        /// <param name="encSlt"></param>
        /// <returns></returns>

        public static string DecryptStringAES(string cipherText, string encSymmetric = "", string encSlt = "")
        {
            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = "";

            try
            {
                cipherText = cipherText.Replace('-', '+');
                cipherText = cipherText.Replace('_', '/');

                if (string.IsNullOrEmpty(cipherText))
                    throw new ArgumentNullException("cipherText");
                if (string.IsNullOrEmpty(encSymmetric))
                    encSymmetric = Constants.encSymmetric;
                if (string.IsNullOrEmpty(encSlt))
                    encSlt = Constants.encSalt;


                var sltArry = Encoding.ASCII.GetBytes(encSlt);
                // generate the key from the shared secret and the salt
                var key = new Rfc2898DeriveBytes(encSymmetric, sltArry);

                // Create the streams used for decryption.
                var bytes = Convert.FromBase64String(cipherText);
                using (var msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    // Create a decrytor to perform the stream transform.
                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (var csDecrypt =
                        new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        /// <summary>
        /// Read Byte Array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static byte[] ReadByteArray(Stream s)
        {
            try
            {
                var rawLength = new byte[sizeof(int)];
                if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
                    throw new SystemException("Stream did not contain properly formatted byte array");

                var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
                if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
                    throw new SystemException("Did not read byte array properly");

                return buffer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}