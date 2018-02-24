namespace Clinic.Model
{
public class PatientCart
	{
		//[Key]
		public int Id { get; set; }

		//[Required]
		public string Name { get; set; }

		//MandatoryQuestions
		//==================
		public bool DoSmokeSnuff { get; set; }
		public string HasAnyAllergy { get; set; }
		public int EatsSugarTimesId { get; set; }
	}
}
