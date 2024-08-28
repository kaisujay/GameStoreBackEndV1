using GameStoreBackEndV1.ObjectLogic.TableDataModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBackEndV1.DataLogic
{
    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {
            
        }

        public DbSet<PlayerTableDataModel> Players { get; set; }

        public DbSet<RoleTableDataModel> Roles { get; set; }

        public DbSet<PlayerRoleTableDataModel> PlayerRoles { get; set; }
    }
}
