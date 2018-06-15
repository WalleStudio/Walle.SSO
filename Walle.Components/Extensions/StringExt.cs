using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Walle.Components.Extensions
{
    public static class StringExt
    {
        private static Encoding Encoder = Encoding.UTF8;

        public static string MD5Hash(this string text)
        {
            byte[] data = Encoder.GetBytes(text);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(data);
            string t = "";
            for (int i = 0; i < result.Length; i++)
            {
                t += Convert.ToString(result[i], 16);
            }
            return t;
        }

        /// <summary>
        /// utf-8 Base64加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string Base64Encode(this string source)
        {
            string encode = string.Empty;
            byte[] bytes = Encoder.GetBytes(source);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = source;
            }
            return encode;
        }


        /// <summary>
        /// utf-8 Base64解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(this string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = Encoder.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }
    }
}
