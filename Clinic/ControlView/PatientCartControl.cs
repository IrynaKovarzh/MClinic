using Clinic.Model;

namespace Clinic.ControlView
{
public class PatientCartControl
	{

		public static PatientCart CreateNew()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("Please write your name");
			string name = System.Console.ReadLine();

			if (name == null && name.Length == 0)
			{
				return null;
			}

			PatientCart cart = new PatientCart();
			cart.Name = name;

			return cart;
		}

		public static PatientCart ChangeMandatoryQuestions(PatientCart cart)
		{
			//AskMandatoryQuestions
			//=====================
			System.Console.WriteLine();
			System.Console.WriteLine("Mandatory questions:");
			System.Console.WriteLine("====================");

			System.Console.WriteLine();
			System.Console.WriteLine("Do you smoke or use snuff? (Y/N)");
			string answer1 = System.Console.ReadLine();

			System.Console.WriteLine();
			System.Console.WriteLine("Do you have any allergy? ");
			string answer2 = System.Console.ReadLine();

			System.Console.WriteLine();
			System.Console.WriteLine("How often do you eat sweets (candies, ice cream etc.)? Times per week.");
			string answer3 = System.Console.ReadLine();

			System.Console.WriteLine("........................................................................");

			//update the cart
			//===============

			//DoSmokeSnuff
			cart.DoSmokeSnuff = answer1.ToLower().Substring(0, 1) == "y" ? true : false;

			//HasAnyAllergy
			cart.HasAnyAllergy = answer2.ToLower().Substring(0, 1) == "n" ? null : answer2;

			//HasAnyAllergy
			int number;
			bool isParseSuccessful = int.TryParse(answer3, out number);
			if (isParseSuccessful) {
				cart.EatsSugarTimesId = number;
			      }

			return cart;
		}
	}
}
