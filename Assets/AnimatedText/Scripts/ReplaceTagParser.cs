using System.Collections.Generic;

namespace AnimatedText
{
	public class ReplaceTagParser
	{
        private static Dictionary<string, string> tagParserDictionary = new Dictionary<string, string>();

        /// <summary>
        /// Add an entry to the parser dictionary
        /// </summary>
        /// <param name="key">Key value</param>
        /// <param name="value">Value to be associated with the key</param>
        public static void AddEntry(string key, string value)
        {
            tagParserDictionary[key] = value;
        }

        /// <summary>
        /// Removes an entry from the parser dictionary
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveEntry(string key)
        {
            if (tagParserDictionary.ContainsKey(key))
                tagParserDictionary.Remove(key);
        }

        /// <summary>
        /// Clear all entries from the parser dictionary
        /// </summary>
        public static void ClearEntries()
        {
            tagParserDictionary.Clear();
        }

        /// <summary>
        /// Get the value associated with a key
        /// </summary>
        /// <param name="key">The dictionary key</param>
        /// <returns>The value associated with the key, or empty string if the value does not exist</returns>
        public static string ParseKey(string key)
        {
            if (!tagParserDictionary.ContainsKey(key))
                return string.Empty;

            return tagParserDictionary[key];
        }

        /// <summary>
        /// Get the whole tags dictionary
        /// </summary>
        public static IReadOnlyDictionary<string, string> GetTagsParserDictionary => tagParserDictionary;
    }
}