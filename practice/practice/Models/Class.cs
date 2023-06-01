using System.Reflection.Metadata.Ecma335;

namespace practice.Models
{
	public class Class
	{
		public int ClassID { get; set; }
		public string ClassName { get; set; }

		public int StudentID { get; set; }
		public ICollection<Student> Students { get; set; } = new List<Student>();
	}
}
