using System.Collections.Generic;
using System.Linq;

namespace Clinic.Model
{
public class PatientCartCatalogue
	{
		private static object _inlock = new object(); 
		
		private static int PatientNumber = 0;

		private static IList<PatientCart> data = new List<PatientCart>();

		public PatientCartCatalogue(IList<PatientCart> dataInput) {
			data = dataInput;
			PatientNumber = dataInput.Count();
		}

		public IEnumerable<PatientCart> GetAll()
		{
			return data;     
		}

		public PatientCart Get(int id)
		{
			return data.Where(c => c.Id == id).FirstOrDefault();			
		}

		public PatientCart Add(PatientCart cart)
		{
			//to make a copy of the 'cart' before adding
			if (cart != null)
			{
				lock (_inlock)
				{
					cart.Id = ++PatientNumber;

					data.Add(cart);   
				}
			}
			return cart;
		}

		public bool Update(int id, PatientCart cart)
		{
			bool isSuccess = false;
			if (cart != null)
			{
				lock (_inlock)
				{
					int index = data.ToList().FindIndex(c => c.Id == id);
					if (cart != null)
					{
						cart.Id = id;
						data[index] = cart;
						isSuccess = true;
					}
				}
			}
			return isSuccess;
		}

		public bool Delete(int id)
		{
			bool isSuccess = false;
			lock (_inlock)
			{
				PatientCart cart = data.Where(c => c.Id == id).First();
				if (cart != null)
				{
					data.Remove(cart);
					isSuccess = true;
				}
			}
			return isSuccess;
		}
	}
}
