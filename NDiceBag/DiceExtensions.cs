namespace NDiceBag
{
	public static class DiceExtensions
	{

		/// <summary>
		/// Get a number of d6.
		/// </summary>
		/// <param name="numberOfDice"></param>
		/// <returns></returns>
		// ReSharper disable InconsistentNaming
		public static Dice d(this int numberOfDice)
		// ReSharper restore InconsistentNaming
		{
			var dice = new Dice { NumberOfDice = numberOfDice, Sides = 6 };

			return dice;
		}

		/// <summary>
		/// Get a number of dice.
		/// </summary>
		/// <param name="numberOfDice"></param>
		/// <param name="numberOfSides"></param>
		/// <returns></returns>
		// ReSharper disable InconsistentNaming
		public static Dice d(this int numberOfDice, int numberOfSides)
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

		// ReSharper disable InconsistentNaming
		public static Dice x(this Dice dice, int multiplier)
		// ReSharper restore InconsistentNaming
		{
			dice.RollModifiers.Add(roll => roll * multiplier);

			return dice;
		}

		public static Dice Plus(this Dice dice, int modifier)
		{
			dice.RollModifiers.Add(roll => roll + modifier);

			return dice;
		}

		public static Dice Minus(this Dice dice, int modifier)
		{
			dice.RollModifiers.Add(roll => roll - modifier);

			return dice;
		}

	}
}
