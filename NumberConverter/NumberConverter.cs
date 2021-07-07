using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NumberConverter
{
	public static class NumberConverter
	{
		public static string Convert(decimal value)
		{
			string resultStr = "";
			if (!ConvertValidation(value))
			{
				throw new ArgumentOutOfRangeException("Invalid value passed to Convert method");
			}
			string[] parts = value.ToString().Split(',');
			int wholePart = int.Parse(parts[0]);
			int fractionalPart = int.Parse(parts[1]);
			List<int> splitValue = ParseIntToArray(wholePart);
			if (splitValue.Count > 3)
			{
				resultStr += ConvertSubNumber(splitValue[3]) + " billion";
			}
			if (splitValue.Count > 2)
			{
				if (splitValue[2] != 0)
				{
					if (resultStr != "")
					{
						resultStr += ", ";
					}
					resultStr += ConvertSubNumber(splitValue[2]) + " million";
				}
			}
			if (splitValue.Count > 1)
			{
				if (splitValue[1] != 0)
				{
					if (resultStr != "")
					{
						resultStr += ", ";
					}
					resultStr += ConvertSubNumber(splitValue[1]) + " thousand";
				}
			}
			if (splitValue[0] != 0)
			{
				if (resultStr != "")
				{
					resultStr += ", ";
				}
				resultStr += ConvertSubNumber(splitValue[0]);
			}
			else if(resultStr == "")
			{
				resultStr += "zero";
			}

			resultStr += " DOLLARS AND ";
			resultStr += ConvertSubNumber(fractionalPart) + " CENTS";
			return resultStr;
		}
		private static string ConvertSubNumber(int value)
		{
			if (value > 999) throw new ArgumentOutOfRangeException("Input value > 999");
			string resultStr = "";
			if (value > 99)
			{
				resultStr += ConvertSubNumber(int.Parse(value.ToString().Substring(0,1))) + " hundred";
				int subValue = int.Parse(value.ToString().Substring(1, value.ToString().Length - 1));
				if (subValue > 0)
				{
					resultStr += " and " + ConvertSubNumber(subValue);
				}
			}
			else if(value > 19)
			{
				if (value > 89)
				{
					resultStr += "ninety";
				}
				else if(value > 79)
				{
					resultStr += "eighty";
				}
				else if(value > 69)
				{
					resultStr += "seventy";
				}
				else if(value > 59)
				{
					resultStr += "sixty";
				}
				else if(value > 49)
				{
					resultStr += "fifty";
				}
				else if(value > 39)
				{
					resultStr += "forty";
				}
				else if(value > 29)
				{
					resultStr += "thirty";
				}
				else
				{
					resultStr += "twenty";
				}
				int subValue = int.Parse(value.ToString().Substring(1, value.ToString().Length - 1));
				if (subValue > 0)
				{
					resultStr += " " + ConvertSubNumber(subValue);
				}
			}
			else
			{
				switch (value)
				{
					case 0:
						resultStr = "zero";
						break;
					case 1:
						resultStr = "one";
						break;
					case 2:
						resultStr = "two";
						break;
					case 3:
						resultStr = "three";
						break;
					case 4:
						resultStr = "four";
						break;
					case 5:
						resultStr = "five";
						break;
					case 6:
						resultStr = "six";
						break;
					case 7:
						resultStr = "seven";
						break;
					case 8:
						resultStr = "eight";
						break;
					case 9:
						resultStr = "nine";
						break;
					case 10:
						resultStr = "ten";
						break;
					case 11:
						resultStr = "eleven";
						break;
					case 12:
						resultStr = "twelve";
						break;
					case 13:
						resultStr = "thirteen";
						break;
					case 14:
						resultStr = "fourteen";
						break;
					case 15:
						resultStr = "fifteen";
						break;
					case 16:
						resultStr = "sixteen";
						break;
					case 17:
						resultStr = "seventeen";
						break;
					case 18:
						resultStr = "eighteen";
						break;
					case 19:
						resultStr = "nineteen";
						break;
					default:
						break;
				}
			}
			return resultStr;
		}
		private static bool ConvertValidation(decimal value)
		{
			int fractionalLength = value.ToString().Split(',')[1].Length;
			if (value < 0 || value > 2000000000 || fractionalLength != 2)
			{
				return false;
			}
			return true;
		}
		private static string ReverseInt(string value)
		{
			char[] arr = value.ToCharArray();
			Array.Reverse(arr);
			return new string(arr);
		}
		private static List<int> ParseIntToArray(int value)
		{
			int chunkSize = 3;
			List<int> resList = new List<int>();
			List<string> splitValue = (from Match m in Regex.Matches(ReverseInt(value.ToString()), @".{1," + chunkSize + "}")
									select m.Value).ToList();
			for (int i = 0; i < splitValue.Count; i++)
			{
				resList.Add(int.Parse(ReverseInt(splitValue[i])));
			}
			return resList;
		}
	}
}
