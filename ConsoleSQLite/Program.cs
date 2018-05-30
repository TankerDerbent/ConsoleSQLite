using System;
using System.Data.Entity;
using System.Linq;

namespace ConsoleSQLite
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Try SQLite + EF6 usage");
			Console.WriteLine();

			using (var ctx = new SiteContext("DefaultConnection"))
			{
				CreateAndSeedDatabase(ctx);
				DisplaySeededData(ctx);
			}

			Console.WriteLine();
			Console.WriteLine("Hit Enter to exit");
			Console.ReadLine();
		}

		private static void CreateAndSeedDatabase(DbContext context)
		{
			if (context.Set<User>().Count() != 0)
				return;

			context.Set<User>().Add(new User { UserName = "testdev666", Type = 1 });
			context.Set<User>().Add(new User { UserName = "lazybiker", Type = 1 });
			context.Set<User>().Add(new User { UserName = "Jora", Type = 1 });

			if (context.Set<Login>().Count() != 0)
				return;

			context.Set<Login>().Add(new Login { UserLoginID = 2, Password = "%#%@%#%@##$%" });

			context.SaveChanges();
		}

		private static void DisplaySeededData(DbContext context)
		{
			foreach (var u in context.Set<User>())
				Console.WriteLine(u.ToString() + string.Format(", has {0} articles", u.Articles.Count().ToString()));
		}
	}
}
