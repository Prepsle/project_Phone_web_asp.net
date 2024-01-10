using Microsoft.EntityFrameworkCore;
using Webphone.Models;
using Webphone.Areas.Admin.Models;

namespace Webphone.Models
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Blog_Comment> Blog_Comments { get; set; }
		public DbSet<Contacts> Contacts { get; set; }
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Categories> Product_Categories { get; set; }
		public DbSet<Carts> Carts { get; set; }
		public DbSet<Categories> Categories { get; set; }
		public DbSet<Colors> Colors { get; set; }
		public DbSet<Discounts> Discounts { get; set; }
		public DbSet<Images> Images { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet<Payments> Payments { get; set; }
		public DbSet<Products> Products { get; set; }
		public DbSet<Reviews> Reviews { get; set; }
		public DbSet<Users> Users { get; set; }
        public DbSet<View_Blog_Menu> view_Blog_Menus { get; set; }
        public DbSet<View_Categories_Products> view_Categories_Products { get; set; }

		public DbSet<AdminMenu> AdminMenus { get; set; }
		public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<View_Contact_Menu> view_Contact_Menus { get; set; }

    }
}
