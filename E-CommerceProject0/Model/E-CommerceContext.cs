using Microsoft.EntityFrameworkCore;

namespace E_CommerceProject0.Model
{
    public class E_CommerceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> Items { get; set; }

        //public DbSet<CartItem> CartItems { get; set; }


        public DbSet<ProductRequest> ProductRequests { get; set; }

        public DbSet<ProdRequestDetail> ProductRequestDetails { get; set; }

        public DbSet<Category> Categories { get; set; }

        //public DbSet<MainCategory> MainCategories { get; set; }

        //public DbSet<Cart> Carts { get; set; }

        public DbSet<Offer> Offers { get; set; }

        //public DbSet<C_Payment> Payments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-MOQNAJL;
            Database = projectecommerce;
            trusted_connection = true;"

            //optionsBuilder.UseSqlServer(@"Data Source=SQL8005.site4now.net;
            //                            Initial Catalog=db_a9441e_walkerthereal;
            //                            User Id=db_a9441e_walkerthereal_admin;
            //                            Password=aaaa1234"
);
        }

    }
}