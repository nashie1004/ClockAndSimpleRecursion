using System;

namespace Clock
{
	public class ClockApp
	{
		public static void Main(string[] args)
		{
            Console.WriteLine("----Console Clock----\n");

			// get user input
			bool hourSuccess = false;
			bool minutesSuccess = false;

			double hour = 0;
			double minutes = 0;
			while (!hourSuccess)
			{
                Console.Write("Hour: ");
				string hourInput = Console.ReadLine();

                if (double.TryParse(hourInput, out double hourOut))
				{
					hourSuccess = true;
					hour = hourOut;
				} 
				else
				{
                    Console.WriteLine("Enter a valid hour");
                }
			}
			while (!minutesSuccess) 
			{
				Console.Write("Minutes: ");
				string minutesInput = Console.ReadLine();

				if (double.TryParse(minutesInput, out double minutesOut))
				{
					minutesSuccess = true;
					minutes = minutesOut;
				}
				else
				{
					Console.WriteLine("Enter valid minutes");
				}
			}


			// clock angle formula
			double angleMinutes = 6 * minutes;
			double angleHours = (30 * hour) + (0.5 * minutes);
			double firstAngle = Math.Abs(angleHours - angleMinutes);
			double secondAngle = 360 - firstAngle;

			Console.WriteLine($"Hour = {hour}, Minutes = {minutes}");
			Console.WriteLine(
				$"LesserAngle = {firstAngle}, GreaterAngle = {secondAngle}"
			);
		}
	}
}