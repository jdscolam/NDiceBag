namespace NDiceBag
{
	public static class DiceExtensions
	{

		/// <summary>
		/// Get a number of dice.
		/// </summary>
		/// <param name="numberOfDice"></param>
		/// <param name="numberOfSides"></param>
		/// <returns></returns>
		// ReSharper disable InconsistentNaming
		public static Dice d(this int numberOfDice, int numberOfSides = 6)
		// ReSharper restore InconsistentNaming
		{
			var dice = new Dice { NumberOfDice = numberOfDice, Sides = numberOfSides };

			return dice;
		}

		/// <summary>
		/// Get a number of dice determined by a roll of dice.
		/// </summary>
		/// <param name="diceToRollForNumberOfDice"></param>
		/// <param name="numberOfSides"></param>
		/// <returns></returns>
		// ReSharper disable InconsistentNaming
		public static Dice d(this Dice diceToRollForNumberOfDice, int numberOfSides)
		// ReSharper restore InconsistentNaming
		{
			var dice = new Dice { NumberOfDice = 0, Sides = numberOfSides };
			
			dice.NumberOfDiceModifiers.Add(numberOfDice => numberOfDice + diceToRollForNumberOfDice.Roll());

			return dice;
		}

		public static Dice GrabPercentileDice(this object me)
		{
			var dice = new Dice { NumberOfDice = 1, Sides = 100 };

			return dice;
		}

	}
}
