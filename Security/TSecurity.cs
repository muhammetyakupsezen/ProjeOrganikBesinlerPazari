﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YeniData;

namespace Security
{
    public static class TSecurity
    {

        #region Settings

        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash = "SHA1";
        private static string _salt = "aselrias38490a32"; // Random
        private static string _vector = "8947az34awl34kjq"; // Random

        #endregion


        public static string StrToMd5(string Metin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(Metin);
            array = md5.ComputeHash(array);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in array)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        public static string Encrypt(string clearText, string encryptionKey)
        {
            return Encrypt<AesManaged>(clearText, encryptionKey);
        }

        public static string Decrypt(string cipherText, string encryptionKey)
        {
            return Decrypt<AesManaged>(cipherText, encryptionKey);
        }

        public static string Encrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Encoding.ASCII.GetBytes(value);

            byte[] encrypted;
            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);
                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
                {
                    using (MemoryStream to = new MemoryStream())
                    {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write))
                        {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
        {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;

            using (T cipher = new T())
            {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try
                {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes))
                    {
                        using (MemoryStream from = new MemoryStream(valueBytes))
                        {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read))
                            {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return String.Empty;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }



        public static TResult ValidToken(string Token, string SecretKey, out TToken OpenToken)
        {
            TResult result = new TResult();
            result.StatusCode = -1001;

          bool IsValid =   DoValidToken(Token, SecretKey , out OpenToken);

            result.Success = IsValid;
            result.StatusCode = 200;
           


            return result;
        }


        public static bool DoValidToken(string Token, string SecretKey, out TToken OpenToken)
        {
            bool result = true;

            var DecryptText = Security.TSecurity.Decrypt(Token, SecretKey);
            string LToken = DecryptText.Replace("+", " ").Replace("_", "");
            string[] Values = LToken.Split('|');

            OpenToken = new TToken()
            {
                KullaniciId = Convert.ToInt32(Values[0]),
                KisiId = Convert.ToInt32(Values[1]),
                Tc = Convert.ToUInt32(Values[2]),
                ExpireMinute = Convert.ToDateTime(Values[3]),
                Guid = Guid.Parse(Values[4])


            };

            if (OpenToken != null)
            {
                if (DateTime.Now > OpenToken.ExpireMinute)
                {   
                    result = false;

                }
            }




            return result;
        }

        



    }
}
