using System;
using System.Collections.Generic;
using FubuTestingSupport;
using NDiceBag;
using NUnit.Framework;

namespace DiceBag.Tests
{
	[TestFixture]
	public class StringParsingSpec
	{
		[TestCase("3d", 3, 6, 2, 19)]
		[TestCase("d", 1, 6, 0, 7)]
		[TestCase("d4", 1, 4, 0, 5)]
		[TestCase("3d8", 3, 8, 2, 25)]
		public void CanGrabDiceInstanceFromAString(string diceString, int numberOfDice, int sides, int rollShouldBeGreaterThan, int rollShouldBeLessThan)
		{
			//Setup
			var dice = diceString.GrabDice();

			//Execute
			var rolls = TestHelpers.Generate1000Rolls(dice);

			//Verify
			dice.NumberOfDice.ShouldEqual(numberOfDice);
			dice.Sides.ShouldEqual(sides);
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(rollShouldBeGreaterThan);
				roll.ShouldBeLessThan(rollShouldBeLessThan);
			});

			//Teardown
		}

		[Test]
		public void WillThrowAnArgumentExceptionWhenUnableToParseAString()
		{
			//Setup
			Exception thrownException = null;
			const string notADiceString = "This is not a dice string";
			
			//Execute
			try
			{
				var dice = notADiceString.GrabDice();
			}
			catch (Exception ex)
			{
				thrownException = ex;
			}
			
			//Verify
			thrownException.ShouldNotBeNull();
			thrownException.ShouldBeOfType<ArgumentException>();
			thrownException.ShouldContainErrorMessage(string.Format("Unable to parse string into dice: \"{0}\"", notADiceString));

			//Teardown
		}

		[TestCase("percentile")]
		[TestCase("PERCENTILE")]
		[TestCase("Percentile")]
		public void CanGrabPercentileDiceFromAString(string percentileDice)
		{
			//Setup
			var dice = percentileDice.GrabDice();

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

		[TestCase("3dx10", 29, 181)]
		[TestCase("3d4x10", 29, 121)]
		[TestCase("3d*10", 29, 181)]
		[TestCase("3d4*10", 29, 121)]
		[TestCase("d4+1+2", 3, 7)]
		[TestCase("1d8+1+2", 3, 12)]
		[TestCase("1d4-1-2", -3, 2)]
		[TestCase("1d4x10-5+3", 7, 39)]
		[TestCase("1d4*10-5+3", 7, 39)]
		[TestCase("3d x10", 29, 181)]
		[TestCase("3d4 x10", 29, 121)]
		[TestCase("3d *10", 29, 181)]
		[TestCase("3d4 *10", 29, 121)]
		[TestCase("d4 +1 +2", 3, 7)]
		[TestCase("1d8 +1 +2", 3, 12)]
		[TestCase("1d4 -1 -2", -3, 2)]
		[TestCase("1d4 x10 -5 +3", 7, 39)]
		[TestCase("3dx 10", 29, 181)]
		[TestCase("3d4x 10", 29, 121)]
		[TestCase("1d4 *10 -5 +3", 7, 39)]
		[TestCase("3d* 10", 29, 181)]
		[TestCase("3d4* 10", 29, 121)]
		[TestCase("d4+ 1+ 2", 3, 7)]
		[TestCase("1d8+ 1+ 2", 3, 12)]
		[TestCase("1d4- 1- 2", -3, 2)]
		[TestCase("1d4x 10- 5+ 3", 7, 39)]
		[TestCase("3d x 10", 29, 181)]
		[TestCase("3d4 x 10", 29, 121)]
		[TestCase("1d4* 10- 5+ 3", 7, 39)]
		[TestCase("3d * 10", 29, 181)]
		[TestCase("3d4 * 10", 29, 121)]
		[TestCase("d4 + 1 + 2", 3, 7)]
		[TestCase("1d8 + 1 + 2", 3, 12)]
		[TestCase("1d4 - 1 - 2", -3, 2)]
		[TestCase("1d4 x 10 - 5 + 3", 7, 39)]
		[TestCase("1d4 * 10 - 5 + 3", 7, 39)]
		public void CanGrabDiceInstanceFromAStringWithSimpleModifiers(string diceString, int rollShouldBeGreaterThan, int rollShouldBeLessThan)
		{
			//Setup
			var dice = diceString.GrabDice();

			//Execute
			var rolls = TestHelpers.Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(rollShouldBeGreaterThan);
				roll.ShouldBeLessThan(rollShouldBeLessThan);
			});

			//Teardown
		}

		[TestCase("3d+d4", 3, 23)]
		[TestCase("3d+1d4", 3, 23)]
		[TestCase("3d6+d4", 3, 23)]
		[TestCase("3d6+1d4", 3, 23)]
		[TestCase("3d-d4", -1, 17)]
		[TestCase("3d-1d4", -1, 17)]
		[TestCase("3d6-d4", -1, 17)]
		[TestCase("3d6-1d4", -1, 17)]
		[TestCase("3d*d4", 2, 73)]
		[TestCase("3d*1d4", 2, 73)]
		[TestCase("3d6*d4", 2, 73)]
		[TestCase("3d6*1d4", 2, 73)]
		[TestCase("3dxd4", 2, 73)]
		[TestCase("3dx1d4", 2, 73)]
		[TestCase("3d6xd4", 2, 73)]
		[TestCase("3d6x1d4", 2, 73)]
		[TestCase("3d +d4", 3, 23)]
		[TestCase("3d +1d4", 3, 23)]
		[TestCase("3d6 +d4", 3, 23)]
		[TestCase("3d6 +1d4", 3, 23)]
		[TestCase("3d -d4", -1, 17)]
		[TestCase("3d -1d4", -1, 17)]
		[TestCase("3d6 -d4", -1, 17)]
		[TestCase("3d6 -1d4", -1, 17)]
		[TestCase("3d *d4", 2, 73)]
		[TestCase("3d *1d4", 2, 73)]
		[TestCase("3d6 *d4", 2, 73)]
		[TestCase("3d6 *1d4", 2, 73)]
		[TestCase("3d xd4", 2, 73)]
		[TestCase("3d x1d4", 2, 73)]
		[TestCase("3d6 xd4", 2, 73)]
		[TestCase("3d6 x1d4", 2, 73)]
		[TestCase("3d+ d4", 3, 23)]
		[TestCase("3d+ 1d4", 3, 23)]
		[TestCase("3d6+ d4", 3, 23)]
		[TestCase("3d6+ 1d4", 3, 23)]
		[TestCase("3d- d4", -1, 17)]
		[TestCase("3d- 1d4", -1, 17)]
		[TestCase("3d6- d4", -1, 17)]
		[TestCase("3d6- 1d4", -1, 17)]
		[TestCase("3d* d4", 2, 73)]
		[TestCase("3d* 1d4", 2, 73)]
		[TestCase("3d6* d4", 2, 73)]
		[TestCase("3d6* 1d4", 2, 73)]
		[TestCase("3dx d4", 2, 73)]
		[TestCase("3dx 1d4", 2, 73)]
		[TestCase("3d6x d4", 2, 73)]
		[TestCase("3d6x 1d4", 2, 73)]
		[TestCase("3d + d4", 3, 23)]
		[TestCase("3d + 1d4", 3, 23)]
		[TestCase("3d6 + d4", 3, 23)]
		[TestCase("3d6 + 1d4", 3, 23)]
		[TestCase("3d - d4", -1, 17)]
		[TestCase("3d - 1d4", -1, 17)]
		[TestCase("3d6 - d4", -1, 17)]
		[TestCase("3d6 - 1d4", -1, 17)]
		[TestCase("3d * d4", 2, 73)]
		[TestCase("3d * 1d4", 2, 73)]
		[TestCase("3d6 * d4", 2, 73)]
		[TestCase("3d6 * 1d4", 2, 73)]
		[TestCase("3d x d4", 2, 73)]
		[TestCase("3d x 1d4", 2, 73)]
		[TestCase("3d6 x d4", 2, 73)]
		[TestCase("3d6 x 1d4", 2, 73)]
		public void CanGrabDiceInstanceFromAStringWithDiceMath(string diceString, int rollShouldBeGreaterThan, int rollShouldBeLessThan)
		{
			//Setup
			var dice = diceString.GrabDice();

			//Execute
			var rolls = TestHelpers.Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(rollShouldBeGreaterThan);
				roll.ShouldBeLessThan(rollShouldBeLessThan);
			});

			//Teardown
		}
	}
}
