using System;
using MarketplaceAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Data
{
    public class AuctionsContext : DbContext
    {
        public AuctionsContext(DbContextOptions<AuctionsContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Auction> Auctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Auction>().ToTable("Auction");
        }
    }
}

