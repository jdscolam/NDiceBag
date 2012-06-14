using System;
using System.Collections.Generic;
using System.Linq;
using NPack;

namespace NDiceBag
{
	public class Dice
	{
		public Dice()
		{
			RollModifiers = new List<Func<int, int>>();
			NumberOfDiceModifiers = new List<Func<int, int>>();
		}

		public int NumberOfDice { get; set; }
		public int Sides { get; set; }
		public List<Func<int, int>> NumberOfDiceModifiers { get; set; }
		public List<Func<int, int>> RollModifiers { get; set; }

		public int Roll()
		{
			//Get Random Number Generator.
			var random = new MersenneTwister(DateTime.Now.Millisecond);

			//Figure out how many dice we should be rolling (aggregate number of dice rolls, or use provided number).
			var numberOfDice = NumberOfDiceModifiers.Aggregate(NumberOfDice, (current, modifier) => modifier(current));

			//Generate Random Number within the dice range.
			//The min value is the NumberOfDice (min of one per die), and the max value is the NumberOfDice * Sides.
			var roll = random.Next(numberOfDice, numberOfDice * Sides);
			
			//Apply modifiers, including other dice rolls.
			roll = RollModifiers.Aggregate(roll, (current, modifier) => modifier(current));
			
			return roll;
		}

		public static Dice operator +(Dice dice1, Dice dice2 )
		{
			dice1.RollModifiers.Add(roll => roll + dice2.Roll());

			return dice1;
		}

		public static Dice operator -(Dice dice1, Dice dice2)
		{
			dice1.RollModifiers.Add(roll => roll - dice2.Roll());

			return dice1;
		}

		public static Dice operator *(Dice dice1, Dice dice2)
		{
			dice1.RollModifiers.Add(roll => roll * dice2.Roll());

			return dice1;
		}

		// ReSharper disable InconsistentNaming
		public Dice x(int multiplier)
		// ReSharper restore InconsistentNaming
		{
			RollModifiers.Add(roll => roll * multiplier);

			return this;
		}

		public Dice Plus(int modifier)
		{
			RollModifiers.Add(roll => roll + modifier);

			return this;
		}

		public Dice Minus(int modifier)
		{
			RollModifiers.Add(roll => roll - modifier);

			return this;
		}
	}
}