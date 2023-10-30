using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace TestKursach2.Models
{
	public class TestsResults
	{
		static List<int> UserTestResults { get; set; } = new List<int>();
		public TestsResults()
		{
			Load();			
		}

		public static void Load()
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "info.txt", FileMode.Open, FileAccess.Read);
			if(stream.Length != 0)
			UserTestResults = (List<int>)formatter.Deserialize(stream);
			stream.Close();
		}

		public static void Save()
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "info.txt", FileMode.Create, FileAccess.Write);

			formatter.Serialize(stream, UserTestResults);
			stream.Close();
		}
		public static void Add(int UserId, int TestId, int Result)
		{
			UserTestResults.Add(UserId);
			UserTestResults.Add(TestId);
			UserTestResults.Add(Result);
			Save();
		}
		public static bool IsExist(int TestId)
		{
			for (int i = 3; i < UserTestResults.Count; i++)
			{
				if (i % 3 == 0)
				{
					if (UserTestResults.ElementAt(i - 3) == UserInfo.User.Id)
					{
						if(UserTestResults.ElementAt(i - 2) == TestId) return true;
					}
				}
			}
			return false;
		}
		public static Dictionary<int, int> getDictionary()
		{
			Dictionary<int, int> TestResult = new Dictionary<int, int>();
			for (int i = 3; i < UserTestResults.Count; i++)
			{
				if(i % 3 == 0)
				{
					if(UserTestResults.ElementAt(i-3) == UserInfo.User.Id)
					{
						TestResult.Add(UserTestResults.ElementAt(i - 2), UserTestResults.ElementAt(i-1));
					}
				}
			}
			return TestResult;
		}
	}
}