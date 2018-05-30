using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleSQLite
{
	public class User
	{
		[Key]
		public int UserID { get; set; }
		[Column("Name", TypeName = "nvarchar")]
		[MaxLength(255)]
		public string UserName { get; set; }
		[Required]
		public int Type { get; set; }
		public virtual Login Login { get; set; }
		public virtual ICollection<Article> Articles { get; set; }
		public override string ToString()
		{
			string sLoginInfo = "w/o login";
			if (this.Login != null)
				sLoginInfo = "pass hash = " + this.Login.Password.ToString();

			return string.Format("User {0} '{1}', type {2}, {3}", this.UserID.ToString("D4"), this.UserName, this.Type.ToString(), sLoginInfo);
		}
	}

	public class Login
	{
		[Key]
		[ForeignKey("User")]
		public int UserLoginID { get; set; }
		public string Password { get; set; }
		public virtual User User { get; set; }
	}

	public class Article
	{
		[Key]
		public int AtricleID { get; set; }
		//[ForeignKey("User")]
		//public int UserID { get; set; }
		public string RawText { get; set; }
		public virtual User User { get; set; }
	}
}
