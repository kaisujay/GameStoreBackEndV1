using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.NuGetDependencies
{
    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {

        }

        public DbSet<PlayerTableDataModel> Players { get; set; }

        public DbSet<RoleTableDataModel> Roles { get; set; }

        public DbSet<PlayerRoleTableDataModel> PlayerRoles { get; set; }

        public DbSet<GameDataModel> Games { get; set; }

        public DbSet<PlatformTypeDataModel> PlatformTypes { get; set; }

        public DbSet<GamePlatformTypeDataModel> GamePlatformTypes { get; set; }

        public DbSet<CartDataModel> Carts { get; set; }

        public DbSet<WishListDataModel> WishLists { get; set; }

        public DbSet<OrderHistoryDataModel> OrderHistorys { get; set; }

        public DbSet<RatingDataModel> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GamePlatformTypeDataModel>()    //Creating a composite Key like this. Since "[Column(order=1/2)]" is not working
                .HasKey(x => new { x.GameId, x.PlatformTypeId });

            modelBuilder.Entity<CartDataModel>() //We are using "List<Game>" so no Keys can be generated for "Game"
                .HasKey(x => new { x.CartId, x.GameId, x.PlayerId });       // Without this change EF Core is not allowing to Save

            modelBuilder.Entity<WishListDataModel>()
                .HasKey(x => new { x.WishListId });        // Same as [key] on top of "WishListId"

            modelBuilder.Entity<OrderHistoryDataModel>()
                .HasIndex(x => x.PlayerId);
        }
    }
}
