using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankApi.Models;

namespace BankApi.Context
{
    public class TransacaoContext : DbContext
    {
        public TransacaoContext(DbContextOptions<TransacaoContext> options) : base(options)
        {
        }

        public DbSet<Transacao> Transacoes { get; set; }

    }
}