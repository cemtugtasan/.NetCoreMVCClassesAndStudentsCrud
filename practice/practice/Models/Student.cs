namespace practice.Models
{
	public class Student
	{
		public int StudentID { get; set; }
		public string StudentName { get; set;}
		public string StudentSurname { get; set;}
		public string StudentAddress { get; set; }

		public int ClassID { get; set; }
		public Class Class { get; set; }
	}
}
