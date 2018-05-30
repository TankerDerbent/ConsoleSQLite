using System.Data.Entity;

namespace ConsoleSQLite
{
	public class ModelConfiguration
	{
		public static void Configure(DbModelBuilder modelBuilder)
		{
			ConfigureUserEntity(modelBuilder);
		}
		private static void ConfigureUserEntity(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<User>()
				//.HasRequired(u => u.UserID)
				//.WillCascadeOnDelete(true);
		}
	}
}
