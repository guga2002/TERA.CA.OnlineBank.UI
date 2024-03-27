using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TERA.CA.OnlineBank.Core.Entities;

namespace TERA.CA.OnlineBank.Core.Data
{
    public class WalletDb:IdentityDbContext<User>
    {
        public WalletDb(DbContextOptions<WalletDb>ops):base(ops)
        {
                
        }

        public virtual DbSet<Curency> Curencies { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Wallet)
                .WithMany()
                .HasForeignKey(t => t.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
