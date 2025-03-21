using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string NomeTitular { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativo { get; set; }
    }
}