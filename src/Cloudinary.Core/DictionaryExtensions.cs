using System.Collections.Generic;
using System.Linq;

namespace CloudinaryDotNet
{
    public static class DictionaryExtensions
    {
        public static string ReducePiped(this IDictionary<string, string> dictionary)
        {
            return string.Join("|",
                dictionary
                    .Where(x => x.Value != null)
                    .Select(x => $"{x.Key}={x.Value}")
            );
        }

        /// <summary>
        /// Slice a value out of the dictionary, based on index.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SliceValue(this IDictionary<string, string> dictionary, string key)
        {
            string value;
            dictionary.TryGetValue(key, out value);
            return value;
        }



    }
}