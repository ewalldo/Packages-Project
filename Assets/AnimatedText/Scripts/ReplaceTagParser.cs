using System.Collections.Generic;

namespace AnimatedText
{
	public class ReplaceTagParser
	{
        private static Dictionary<string, string> tagParserDictionary;

        /// <summary>
        /// Add an entry to the parser dictionary
        /// </summary>
        /// <param name="key">Key value</param>
        /// <param name="value">Value to be associated with the key</param>
        public static void AddEntry(string key, string value)
        {
            if (tagParserDictionary == null)
                tagParserDictionary = new Dictionary<string, string>();

            tagParserDictionary[key] = value;
        }

        /// <summary>
        /// Get the value associated with a key
        /// </summary>
        /// <param name="key">The dictionary key</param>
        /// <returns>The value associated with the key, or empty string if the value does not exist</returns>
        public static string ParseKey(string key)
        {
            if (tagParserDictionary == null)
                tagParserDictionary = new Dictionary<string, string>();

            if (!tagParserDictionary.ContainsKey(key))
                return string.Empty;

            return tagParserDictionary[key];
        }

        /// <summary>
        /// Get the whole tags dictionary
        /// </summary>
        public static Dictionary<string, string> GetTagsParserDictionary => tagParserDictionary;
    }
}