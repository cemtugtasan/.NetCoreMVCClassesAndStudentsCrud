using Microsoft.EntityFrameworkCore;
using practice.Models;

namespace practice.Context
{
	public class GeneralContext : DbContext
	{
		public GeneralContext(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Class> Classes { get; set; }
		public DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Class>().HasData(
			new Class
			{
				ClassID = 1,
				ClassName = "Math"
			},
			new Class
			{
				ClassID = 2,
				ClassName = "Science"
			});
			modelBuilder.Entity<Student>().HasData(
			new Student
			{
				StudentID = 1,
				StudentName = "Cemtuğ Kaan",
				StudentSurname="Taşan",
				StudentAddress="Eskişehir",
				ClassID=1
			},
			new Student
			{
				StudentID = 2,
				StudentName = "Burcu",
				StudentSurname = "Taşan",
				StudentAddress = "My Heart",
				ClassID = 1
			},
			new Student
			{
				StudentID = 3,
				StudentName = "Hakan",
				StudentSurname = "Balamir",
				StudentAddress = "Siirt",
				ClassID = 2
			},				
			new Student
			{
				StudentID = 4,
				StudentName = "Uğur",
				StudentSurname = "Demir",
				StudentAddress = "İstanbul",
				ClassID = 2
			}
			);

		}
	}
}
