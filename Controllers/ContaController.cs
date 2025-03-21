using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApi.Context;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly BancoContext _context;
        public ContaController(BancoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Conta conta)
        {
            _context.Add(conta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { Id = conta.Id }, conta);
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            var conta = _context.Contas.Find(Id);
            if (conta == null)
                return NotFound();

            return Ok(conta);
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Conta conta)
        {
            var contaBanco = _context.Contas.Find(Id);
            if (contaBanco == null)
                return NotFound();

            contaBanco.NomeTitular = conta.NomeTitular;
            contaBanco.Saldo = conta.Saldo;
            contaBanco.Ativo = conta.Ativo;

            _context.Contas.Update(contaBanco);
            _context.SaveChanges();
            return Ok(contaBanco);
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var contaBanco = _context.Contas.Find(Id);

            if (contaBanco == null)
                return NotFound();

            _context.Contas.Remove(contaBanco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}