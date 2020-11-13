// ***********************************************************************
// Assembly         : XianaCore.Common
// Author           : Pablo Restrepo
// Created          : 07-17-2020
//
// Last Modified By : Pablo Restrepo
// Last Modified On : 07-23-2020
// ***********************************************************************
// <copyright file="CipherHelper.cs" company="XianaCore.Common">
//     Copyright (c) XianaApp S.A.S. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace XianaCore.Common.CrossCutting
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Class CipherHelper.
    /// </summary>
    public class CipherHelper
    {
        /// <summary>
        /// The cipher key
        /// </summary>
        private const string CIPHERKEY = "OVUNQUE";

        #region Builder

        /// <summary>
        /// Initializes a new instance of the <see cref="CipherHelper"/> class.
        /// </summary>
        protected CipherHelper()
        {
        }

        #endregion Builder

        #region Public Methods

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="planinText">The plane text parameter.</param>
        /// <param name="password">Password parameter.</param>
        /// <returns>System string.</returns>
        public static string Encrypt(string planinText, string password)
        {
            if (string.IsNullOrEmpty(planinText))
            {
                return null;
            }

            if (string.IsNullOrEmpty(password))
            {
                return null;
            }

            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(planinText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);
            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);
            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="planinText">The plane text.</param>
        /// <returns>System string.</returns>
        public static string Encrypt(string planinText)
        {
            if (string.IsNullOrEmpty(planinText))
            {
                return null;
            }

            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(planinText);
            var passwordBytes = Encoding.UTF8.GetBytes(CIPHERKEY);

            // Hash the password with SHA256
            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);
            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);
            return Convert.ToBase64String(bytesEncrypted);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted.</param>
        /// <param name="password">Password used during encryption.</param>
        /// <returns>System string.</returns>
        /// <exception cref="FormatException">Format exception.</exception>
        public static string Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = string.Empty;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        /// <summary>
        /// Decrypt a string.
        /// </summary>
        /// <param name="encryptedText">String to be decrypted</param>
        /// <returns>System string.</returns>
        /// <exception cref="FormatException">Format exception</exception>
        public static string Decrypt(string encryptedText)
        {
            if (encryptedText == null)
            {
                return null;
            }

            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(CIPHERKEY);

            passwordBytes = SHA512.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Encrypts the specified bytes to be encrypted.
        /// </summary>
        /// <param name="bytesToBeEncrypted">The bytes to be encrypted.</param>
        /// <param name="passwordBytes">The password bytes.</param>
        /// <returns>System.Byte[] array.</returns>
        private static byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 40 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged aES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    aES.KeySize = 256;
                    aES.BlockSize = 128;
                    aES.Key = key.GetBytes(aES.KeySize / 8);
                    aES.IV = key.GetBytes(aES.BlockSize / 8);
                    aES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        /// <summary>
        /// Decrypts the specified bytes to be decrypted.
        /// </summary>
        /// <param name="bytesToBeDecrypted">The bytes to be decrypted.</param>
        /// <param name="passwordBytes">The password bytes.</param>
        /// <returns>System byte[].</returns>
        private static byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 40 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged aES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    aES.KeySize = 256;
                    aES.BlockSize = 128;
                    aES.Key = key.GetBytes(aES.KeySize / 8);
                    aES.IV = key.GetBytes(aES.BlockSize / 8);
                    aES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, aES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        #endregion Private Methods
    }
}