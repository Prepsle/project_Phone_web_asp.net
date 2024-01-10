using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webphone.Models
{
    [Table("View_Contact_Menu")]
    public class View_Contact_Menu
    {
        [Key]
        public int ContactId { get; set; }
        public string? Names { get; set; }
        public string? Email { get; set; }
        public DateTime? ContactDate { get; set; }
        public string? Menu_Name { get; set; }
        public int Menu_Id { get; set; }
        public string? Phone { get; set; }
    }
}
