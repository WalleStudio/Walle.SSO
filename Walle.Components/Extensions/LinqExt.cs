 

using System.Linq;
using System.Collections.Generic;
using System;
namespace Walle.Components.Extensions
{
    public static class LinqExt
    {
        public static void InvokeForeach<T>(this IEnumerable<T> lst, Action<T> action)
        {
            foreach (var item in lst)
            {
                action?.Invoke(item);
            }
        }

        public static void BeginInvokeForeach<T>(this IEnumerable<T> lst, Action<T> action, AsyncCallback callback = null, object obj = null)
        {
            foreach (var item in lst)
            {
                action?.BeginInvoke(item, callback, obj);
            }
        }

        public static List<TOutput> ConvertAll<TInput, TOutput>(this List<TInput> lst, Func<TInput, TOutput> converter)
        {
            List<TOutput> result = new List<TOutput>();
            if (lst.HasAny())
            {
                foreach (var item in lst)
                {
                    var another = converter(item);
                    result.Add(another);
                }
            }
            return result;
        }

        /// <summary>
        /// 转成字符串并使用指定的分割符进行分割.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static string ToArrayString(this IEnumerable<int> source, char spliter)
        {
            var result = string.Empty;
            foreach (var item in source)
            {
                result += item.ToString() + spliter;
            }
            result = result.TrimEnd(spliter);
            return result;
        }

        public static string ToArrayString(this IEnumerable<long> source, char spliter)
        {
            var result = string.Empty;
            foreach (var item in source)
            {
                result += item.ToString() + spliter;
            }
            result = result.TrimEnd(spliter);
            return result;
        }

        public static string ToArrayString(this IEnumerable<string> source, char spliter, string leftchar = "", string rightchar = "")
        {
            var result = string.Empty;
            foreach (var item in source)
            {
                result += leftchar + item.ToString() + rightchar + spliter;
            }
            result = result.TrimEnd(spliter);
            return result;
        }
    }

}
