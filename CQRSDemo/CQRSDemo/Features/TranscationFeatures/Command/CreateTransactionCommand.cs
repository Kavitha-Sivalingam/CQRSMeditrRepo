using CQRSDemo.Context;
using CQRSDemo.Entity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSDemo.Features.TranscationFeatures.Command
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public int TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }
        public int Amount { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateTransactionCommand, int>
        {
            private readonly ITransactionDbContext _context;
            public CreateProductCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
            {
                var tran = new Transaction();
                tran.AccountNumber = command.AccountNumber;
                tran.BeneficiaryName = command.BeneficiaryName;
                tran.BankName = command.BankName;
                tran.SWIFTCode = command.SWIFTCode;
                tran.Amount = command.Amount;
                _context.Transactions.Add(tran);
                await _context.SaveChanges();
                return tran.TransactionId;
            }
        }
    }
}
