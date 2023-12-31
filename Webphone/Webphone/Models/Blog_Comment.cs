using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
	[Table("Blog_Comment")]
	public class Blog_Comment
	{
		[Key]
		public int Comment_Id { get; set; }
		public int Blog_Id { get; set; }
		public string? Name { get; set; }
		public DateTime? CreateDate { get; set; }
		public string? Detail { get; set; }
		public int Status { get; set; }
		public string? Email { get; set; }
	}
}
