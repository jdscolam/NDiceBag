using System.Collections.Generic;
using NDiceBag;

namespace DiceBag.Tests
{
	public static class TestHelpers
	{
		public static IEnumerable<int> Generate1000Rolls(Dice dice)
		{
			var rolls = new List<int>();

			for (var i = 0; i < 1000; i++)
			{
				rolls.Add(dice.Roll());
			}

			return rolls;
		}
	}
}
