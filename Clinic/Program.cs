using Clinic.Model;
using Clinic.ControlView;

namespace Clinic
{
public	class Program
	{

	public static void Main(string[] args)
		{
			//PatientCartsControl catalogControl = new PatientCartsControl();
			PatientCartsControl catalogControl = new PatientCartsControl(true);  //from file

			bool toContinue = false;
			do
			{
			PatientCart cart = PatientCartControl.CreateNew();
			catalogControl.AddCart(cart);

			if (cart != null) {		
					PatientCart updatedCart = PatientCartControl.ChangeMandatoryQuestions(cart);
					PatientCartsControl.UpdateCart(cart.Id, updatedCart);
				}

				    toContinue = false;
					System.Console.WriteLine();
					System.Console.WriteLine("To continue? Y/N");
					string input = System.Console.ReadLine();
					toContinue = input.ToLower().Substring(0, 1) == "y" ? true : false;
				} while (toContinue) ;

			var res = catalogControl.GetAllCarts();

			System.Console.ReadKey();
		}

	}
}
