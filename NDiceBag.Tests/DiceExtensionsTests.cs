using System.Collections.Generic;
using FubuTestingSupport;
using NDiceBag;
using NUnit.Framework;

namespace DiceBag.Tests
{
	[TestFixture]
	public class DiceExtensionsTests
	{
		[Test]
		public void DiceCanBeCreatedFromAnInteger()
		{
			//Setup
			//Execute
			var dice = 3.d();

			//Verify
			dice.Sides.ShouldEqual(6);
			dice.NumberOfDice.ShouldEqual(3);

			//Teardown
		}

		[Test]
		public void DShouldDefaultToSixSides()
		{
			//Setup
			var dice = 3.d();

			//Execute
			var rolls = TestHelpers.Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(2);
				roll.ShouldBeLessThan(19);
			});

			//Teardown
		}

		[Test]
		public void CanGrabPercentileDice()
		{
			//Setup
			var dice = this.GrabPercentileDice();

			//Execute
			var rolls = TestHelpers.Generate1000Rolls(dice);

			//Verify
			dice.Sides.ShouldEqual(100);
			dice.NumberOfDice.ShouldEqual(1);

			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(0);
				roll.ShouldBeLessThan(101);
			});

			//Teardown
		}
	}
}
