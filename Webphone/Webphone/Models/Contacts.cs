using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
	[Table("Contacts")]
	public class Contacts
	{
		[Key]
		public int ContactId { get; set; }
		public string? Names { get; set; }
		public string? Email { get; set; }
		public string? ContactDate { get; set; }
	}
}
