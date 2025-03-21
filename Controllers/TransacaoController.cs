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
    public class TransacaoController : ControllerBase
    {
        private readonly TransacaoContext _context;
        public TransacaoController(TransacaoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { Id = transacao.Id }, transacao);
        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            var transacao = _context.Transacoes.Find(Id);
            if (transacao == null)
                return NotFound();

            return Ok(transacao);
        }

        [HttpGet]
        public IActionResult ObterTodas()
        {
            var transacao = _context.Transacoes.ToList();
            return Ok(transacao);
        }

    }
}