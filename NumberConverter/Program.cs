using System;
using System.Globalization;

namespace NumberConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				string input = Console.ReadLine();
				string q = "";
				CultureInfo culture = new CultureInfo("en-US");
				try
				{
					q = NumberConverter.Convert(Convert.ToDecimal(input, culture));
				}
				catch (Exception)
				{
					Console.WriteLine("Incorrect value");
				}
				if (q != "")
				{
					Console.WriteLine(q);
				}
			}
		}
	}
}
