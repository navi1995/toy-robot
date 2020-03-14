﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
	class Program
	{
		static void Main(string[] args)
		{
			string input;
			Robot toy = new Robot();

			Console.WriteLine("Please enter a PLACE command to begin. Q at any time to exit.");
			
			while (true)
			{
				input = Console.ReadLine();

				//If user presses Q, exit app.
				if (input.ToLower() == "q")
				{
					break;
				} 
				else
				{
					//Pass command through to Robot
					string response = toy.Command(input);

					if (!string.IsNullOrEmpty(response))
					{
						Console.WriteLine(response);
					}
				}
			}
		}
	}
}
