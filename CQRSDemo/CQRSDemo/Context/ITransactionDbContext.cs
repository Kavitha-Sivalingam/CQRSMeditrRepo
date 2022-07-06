using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CQRSDemo.Entity;

namespace CQRSDemo.Context
{
    public interface ITransactionDbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        Task<int> SaveChanges();
    }
}
