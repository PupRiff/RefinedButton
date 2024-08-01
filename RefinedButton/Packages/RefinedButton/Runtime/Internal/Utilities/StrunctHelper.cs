using System.Collections.Generic;

namespace RefinedButton.Internal.Utilities
{
	internal static class StructHelper
	{
		public static bool Exchange<T>(ref T field, T value, EqualityComparer<T> comparer = null)
		{
			comparer ??= EqualityComparer<T>.Default;

			if (comparer.Equals(field, value)) return false;

			field = value;
			return true;
		}
	}
}