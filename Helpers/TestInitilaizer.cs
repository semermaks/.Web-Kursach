using System.Collections.Generic;
using System.Data.Entity;

namespace TestKursach2.Helpers
{
	//DropCreateDatabaseAlways
	//DropCreateDatabaseIfModelChanges
	//CreateDatabaseIfNotExists
	public class TestInitilaizer : DropCreateDatabaseAlways<TestsContext>
	{ 
		protected override void Seed(TestsContext context)
		{
			base.Seed(context);
		}
	}
}