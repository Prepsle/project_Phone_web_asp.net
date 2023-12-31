using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
	[Table("Categories")]
	public class Categories
	{
		[Key]
		public int CategoryID { get; set; }
		public string? Names { get; set; }
		public string? Descriptions { get; set; }
		public string? Images { get; set; }
		public bool? IsActive { get; set; }
	}
}
