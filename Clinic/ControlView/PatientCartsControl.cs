using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.IO;

using Clinic.Model;

namespace Clinic.ControlView
{
public class PatientCartsControl
	{
		private bool DataFromFile;
		private string DataFilePath = @"c:\CartsCatalogue\carts.txt";

		private static PatientCartCatalogue _catalogue;

		public PatientCartsControl()
		{

	    IList<PatientCart> data = new List<PatientCart> {
			new PatientCart {
				Id = 1,
				Name = "Artut",
				DoSmokeSnuff = true,
				HasAnyAllergy = null,
				EatsSugarTimesId = 3
			},
			new PatientCart {
				Id = 2,
				Name = "Katia",
				DoSmokeSnuff = true,
				HasAnyAllergy = "penicillin",
				EatsSugarTimesId = 3
			}
		};

		_catalogue = new PatientCartCatalogue(data);
		}

		public PatientCartsControl(bool dataFromFile) : this()
		{
			DataFromFile = dataFromFile; 
			if (dataFromFile)
			{
				string text = File.ReadAllText(DataFilePath); //More checks
				IList<PatientCart> data = JsonConvert.DeserializeObject<IList<PatientCart>>(text);

				_catalogue = new PatientCartCatalogue(data);
			}			
		}

		public JsonResult GetAllCarts()
		{
			var arr = _catalogue.GetAll();

			string jsonArr = JsonConvert.SerializeObject(arr);
			if (DataFromFile)
			{
				//To a file
				File.WriteAllText(DataFilePath, jsonArr);
			}
			else {
				//To Console
				Console.WriteLine(jsonArr);
			}

			return new JsonResult(arr,
								  new JsonSerializerSettings() { Formatting = Formatting.Indented });
		}

		public static PatientCart GetCart(int id)
		{
			PatientCart cart = _catalogue.Get(id);

			if (cart == null)
			{				
				System.Console.WriteLine("Not found.");
			}
			return cart;
		}

		public void AddCart(PatientCart cart)
		{
			if (cart == null)
			{
				System.Console.WriteLine("Bad Request.");
				return;
			}

			var createdBook = _catalogue.Add(cart);   //Conflict in case Add is not successful
		}

		public static void UpdateCart(int id, PatientCart cart)
		{
			bool isSuccess = _catalogue.Update(id, cart);

			if (!isSuccess)
			{
				System.Console.WriteLine("The cart has not been updated.");
				// new Exeption();
			}
		}

		public static void DeleteCart(int id)
		{
			bool isSuccess = _catalogue.Delete(id);

			if (!isSuccess)
			{
				System.Console.WriteLine("The cart has not been deleted.");
				// new Exeption();
			}
		}

	}
}
