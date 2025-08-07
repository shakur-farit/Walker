using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Common.Extensions
{
	public static class EnumUtility
	{
		public static List<T> InitEnumList<T>(T excludeValue = default) where T : Enum
		{
			return Enum.GetValues(typeof(T))
				.Cast<T>()
				.Where(e => !EqualityComparer<T>.Default.Equals(e, excludeValue))
				.ToList();
		}
	}
}