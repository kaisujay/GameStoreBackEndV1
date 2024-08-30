﻿using GameStoreBackEndV1.ObjectLogic.TableDataModels;
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

        public DbSet<GameDataModel> Games { get; set; }

        public DbSet<PlatformTypeDataModel> PlatformTypes { get; set; }

        public DbSet<GamePlatformTypeDataModel> GamePlatformTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GamePlatformTypeDataModel>()    //Creating a composite Key. Since "[Column(order=1/2)]" is not working
                .HasKey(x => new { x.GameId, x.PlatformTypeId});
        }
    }
}
