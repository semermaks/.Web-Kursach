using System.Data.Entity;
using TestKursach2.Models;

namespace TestKursach2.Helpers
{
	public class TestsContext : DbContext
	{
		public TestsContext() : base("OnlineTests21")
		{

		}
		public virtual DbSet<Test> Test { get; set; }
		public virtual DbSet<Question> Questions { get; set; }
		public virtual DbSet<User> Users { get; set; }
	}
}