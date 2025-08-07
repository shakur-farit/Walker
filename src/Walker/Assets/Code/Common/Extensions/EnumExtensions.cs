using System;
using System.Text.RegularExpressions;

namespace Code.Common.Extensions
{
	public static class EnumExtensions
	{
		private static readonly Regex _camelCaseSplitter = new(@"(?<!^)([A-Z])", RegexOptions.Compiled);

		public static string ToDisplayName(this Enum value) =>
			_camelCaseSplitter.Replace(value.ToString(), " $1");
	}
}