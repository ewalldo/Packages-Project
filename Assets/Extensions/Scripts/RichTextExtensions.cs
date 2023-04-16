using UnityEngine;

namespace Extensions
{
	public static class RichTextExtensions
	{
		/// <summary>
		/// Wraps a start and end string around another one
		/// </summary>
		/// <param name="input">The string to have the elements wrapped around</param>
		/// <param name="startElement">The start string</param>
		/// <param name="endElement">The final string</param>
		/// <returns>The string with the start and end element wrapped around it</returns>
		public static string WrapAround(this string input, string startElement, string endElement) => string.Join(string.Empty, startElement, input, endElement);

		/// <summary>
		/// Renders the text in bold
		/// </summary>
		/// <param name="input">Text to be rendered in bold</param>
		/// <returns>The bolded text representation</returns>
		public static string Bold(this string input) => input.WrapAround("<b>", "</b>");

		/// <summary>
		/// Renders the text in italic
		/// </summary>
		/// <param name="input">Text to be rendered in italic</param>
		/// <returns>The italic text representation</returns>
		public static string Italic(this string input) => input.WrapAround("<i>", "</i>");

		/// <summary>
		/// Change the render size of the text
		/// </summary>
		/// <param name="input">Text to be resized</param>
		/// <param name="size">The size for the text, given in pixels</param>
		/// <returns>The resized text</returns>
		public static string Size(this string input, int size) => input.WrapAround($"<size={size}>", "</size>");

		/// <summary>
		/// Change the render color of the text
		/// </summary>
		/// <param name="input">The text to have the color changed</param>
		/// <param name="color">The color to apply to the text</param>
		/// <returns>The text with the color applied</returns>
		public static string Color(this string input, Color color) => input.WrapAround($"<color=#{ColorUtility.ToHtmlStringRGB(color)}>", "</color>");

		/// <summary>
		/// Change the render color of the text
		/// </summary>
		/// <param name="input">The text to have the color changed</param>
		/// <param name="hexColor">The color to apply to the text</param>
		/// <returns>The text with the color applied</returns>
		public static string Color(this string input, uint hexColor) => input.WrapAround($"<color={hexColor}>", "</color>");
	}
}