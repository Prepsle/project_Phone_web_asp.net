using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
	[Table("Menu")]
	public class Menu
	{
		[Key]
		public int Menu_Id { get; set; }
		public string? Menu_Name { get; set; }
		public bool? IsActive { get; set; }
		public string? ControllerName { get; set; }
		public string? ActiveName { get; set; }
		public int Levels { get; set; }
		public int Parent_Id { get; set; }
		public string? Link { get; set; }
		public int Menu_Order { get; set; }
		public int Position { get; set; }
	}
}
