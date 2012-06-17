using System.Collections.Generic;
using FubuTestingSupport;
using NDiceBag;
using NUnit.Framework;

namespace DiceBag.Tests
{
	[TestFixture]
	public class DiceTests
	{
		private static IEnumerable<int> Generate1000Rolls(Dice dice)
		{
			var rolls = new List<int>();

			for (var i = 0; i < 1000; i++)
			{
				rolls.Add(dice.Roll());
			}

			return rolls;
		}

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
		public void DiceCanBeRolled()
		{
			//Setup
			var dice = 3.d();

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(2);
				roll.ShouldBeLessThan(19);
			});

			//Teardown
		}

		[Test]
		public void DiceRollsCanHaveMultipliers()
		{
			//Setup
			var dice = 3.d().x(10);
			
			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(29);
				roll.ShouldBeLessThan(181);
			});

			//Teardown
		}

		[Test]
		public void DiceRollsCanHaveMultiplePlusModifiers()
		{
			//Setup
			var dice = 1.d(4).Plus(1).Plus(2);

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(3);
				roll.ShouldBeLessThan(7);
			});

			//Teardown
		}

		[Test]
		public void DiceRollsCanHaveMultipleMinusModifiers()
		{
			//Setup
			var dice = 1.d(4).Minus(1).Minus(2);

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(-3);
				roll.ShouldBeLessThan(2);
			});

			//Teardown
		}

		[Test]
		public void DiceRollsCanHaveMixedModifiers()
		{
			//Setup
			var dice = 1.d(4).x(10).Minus(5).Plus(3);

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(7);
				roll.ShouldBeLessThan(39);
			});

			//Teardown
		}

		[Test]
		public void DiceCanBeAdded()
		{
			//Setup
			var dice1 = 3.d();
			var dice2 = 1.d(4);

			//Execute
			var rolls = Generate1000Rolls(dice1 + dice2);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(3);
				roll.ShouldBeLessThan(23);
			});

			//Teardown
		}

		[Test]
		public void DiceCanBeSubtracted()
		{
			//Setup
			var dice1 = 3.d();
			var dice2 = 1.d(4);

			//Execute
			var rolls = Generate1000Rolls(dice1 - dice2);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(-1);
				roll.ShouldBeLessThan(17);
			});

			//Teardown
		}

		[Test]
		public void DiceCanBeMultiplied()
		{
			//Setup
			var dice1 = 3.d();
			var dice2 = 1.d(4);

			//Execute
			var rolls = Generate1000Rolls(dice1 * dice2);

			//Verify
			rolls.Each(roll =>
			{
			roll.ShouldBeGreaterThan(2);
			roll.ShouldBeLessThan(73);
			});

			//Teardown
		}

		[Test]
		public void DiceCanBeFluentlyAdded()
		{
			//Setup
			//Execute
			var rolls = Generate1000Rolls(3.d() + 1.d(4));

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(3);
				roll.ShouldBeLessThan(23);
			});
			
			//Teardown
		}

		[Test]
		public void DiceCanBeFluentlySubtracted()
		{
			//Setup
			//Execute
			var rolls = Generate1000Rolls(3.d() - 1.d(4));

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(-1);
				roll.ShouldBeLessThan(17);
			});

			//Teardown
		}

		[Test]
		public void DShouldDefaultToSixSides()
		{
			//Setup
			var dice = 3.d();

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(2);
				roll.ShouldBeLessThan(19);
			});

			//Teardown
		}

		[Test]
		public void DiceCanHaveARolledNumberOfDiceToRoll()
		{
			//Setup
			var dice = 1.d(4).d(6);
			
			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(0);
				roll.ShouldBeLessThan(25);
			});

			//Teardown
		}

		[Test]
		public void CanGrabPercentileDice()
		{
			//Setup
			var dice = this.GrabPercentileDice();

			//Execute
			var rolls = Generate1000Rolls(dice);

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

		[Test]
		public void DiceCanBeDividedRoundingDown()
		{
			//Setup
			var dice = 1.d(4).DivideRoundingDown(2);

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(-1);
				roll.ShouldBeLessThan(3);
			});

			//Teardown
		}

		[Test]
		public void DiceCanBeDividedRoundingUp()
		{
			//Setup
			var dice = 1.d(4).DivideRoundingUp(2);

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(0);
				roll.ShouldBeLessThan(3);
			});

			//Teardown
		}

		[Test]
		public void DiceCanHaveIntegerAdditionModifiersUsingOperators()
		{
			//Setup
			var dice = 1.d(4) + 1 + 2;

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(3);
				roll.ShouldBeLessThan(7);
			});

			//Teardown
		}

		[Test]
		public void DiceCanHaveIntegerSubtractionModifiersUsingOperators()
		{
			//Setup
			var dice = 1.d(4) - 1 - 2;

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(-3);
				roll.ShouldBeLessThan(2);
			});

			//Teardown
		}

		[Test]
		public void DiceCanHaveIntegerMultipliersUsingOperators()
		{
			//Setup
			var dice = 3.d() * 10;

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(29);
				roll.ShouldBeLessThan(181);
			});

			//Teardown
		}

		[Test]
		public void DiceRollsCanHaveMixedIntegerModifiersUsingOperators()
		{
			//Setup
			var dice = 1.d(4) * 10 - 5 + 3;

			//Execute
			var rolls = Generate1000Rolls(dice);

			//Verify
			rolls.Each(roll =>
			{
				roll.ShouldBeGreaterThan(7);
				roll.ShouldBeLessThan(39);
			});

			//Teardown
		}
	}
}