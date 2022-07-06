using Microsoft.EntityFrameworkCore;
using CQRSDemo.Entity;
using System.Threading.Tasks;

namespace CQRSDemo.Context
{
    public class TransactionDbContext : DbContext, ITransactionDbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
