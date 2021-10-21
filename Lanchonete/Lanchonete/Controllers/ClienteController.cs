using Lanchonete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanchonete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public ClienteController (Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]

        public List<Cliente> Get()
        {
            return Contexto.Clientes.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return Contexto.Clientes.First(c => c.IdCliente == id);
        }

        [HttpGet("idcliente/{idcliente}")]
        public List<Cliente> Filtrar(int id)
        {
            return Contexto.Clientes.Where(c => c.IdCliente == id).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Cliente>> Create(Cliente Cliente)
        {
            Cliente.IdCliente = 0;
            Contexto.Clientes.Add(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Cliente>> Update(Cliente Cliente)
        {
            Contexto.Clientes.Add(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Cliente>> Remove(Cliente Cliente)
        {
            Contexto.Clientes.Remove(Cliente);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Cliente.IdCliente, Cliente });
        }
    }
}
