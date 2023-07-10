using Entity.Model;
using Entity.TestDbA;
using Microsoft.EntityFrameworkCore;
using WxsAppShop.Entity.Model;

namespace Core.Base.DBContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TestTable> _testTable { get; set; }

        public DbSet<User> _user { get; set; }

        public DbSet<Address> _addresses { get; set; }

        public DbSet<Category> _categories { get; set; }

        public DbSet<News> _news { get; set; }

        public DbSet<Topic> _topics { get; set; }

        public DbSet<Voice> _voice { get; set; }

        public DbSet<Vote> _vote { get; set; }

        public DbSet<Item> _items { get; set; }

        public DbSet<ItemSubOption> _itemsSubOption { get; set; }

        public DbSet<ItemTagOptions> _itemsTagOptions { get; set; }

        public DbSet<Order> _order { get; set; }

        public DbSet<ShoppingCar> shoppingCars { get; set; }

        public DbSet<Comment> _comments { get; set; }

        public DbSet<Collection> _collection { get; set; }
    }
}
