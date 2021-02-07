﻿using System;
using System.Collections.Generic;


namespace investment_bank
{
	class Program
	{
		class Configuration
		{
			public static Boolean wait;

			public static void Decode(string[] parameters)
			{
				int index;
				List<string> options;

				index = -1;
				while ( ++index < parameters.Length)
				{
					options = new List<string>(new string[] { "-w", "--wait" });
					Configuration.wait = (options.Contains(parameters[index].ToLower()));
				}
			}
		}

		static Input ReadInput()
		{
			Input input = new Input();

			input.trades.Add(new Trade(3_000_000, "Private", DateTime.Parse("12/03/2020")));
			input.trades.Add(new Trade(  900_000, "Public",  DateTime.Parse("15/05/2021")));

			return input;
		}


		static void Process(Input input)
		{
			Portfolio portfolio = new Portfolio();

			foreach(ITrade itrade in input.trades)
			{
				portfolio.Trades.Add(itrade);
			}

			portfolio.Display();
		}


		static void Main(string[] args)
		{
			Configuration.Decode(args);

			Console.WriteLine("Trades");
			Console.WriteLine();

			try
			{
				Process(ReadInput());
			}
			catch (Exception)
			{

			}

			if (Configuration.wait)
				Console.ReadKey();
		}
	}
}

