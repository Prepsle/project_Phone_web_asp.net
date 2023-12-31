using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("View_Blog_Menu")]
    public class View_Blog_Menu
    {
        [Key]
        public Int64 Blog_Id { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? Link { get; set; }
        public string? Author { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public int BlogOrder { get; set; }
        public int Menu_Id { get; set; }
        public int Status { get; set; }
        public string? Menu_Name { get; set; }
    }
}
