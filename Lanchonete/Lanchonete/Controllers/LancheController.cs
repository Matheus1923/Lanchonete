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
    public class LancheController : ControllerBase
    {
        public Contexto Contexto { get; set; }

        public LancheController(Contexto novoContexto)
        {
            this.Contexto = novoContexto;
        }

        [HttpGet]

        public List<Lanche> Get()
        {
            return Contexto.Lanches.ToList();
        }

        [HttpGet("{id}")]
        public Lanche Get(int id)
        {
            return Contexto.Lanches.First(c => c.IdLanche == id);
        }

        [HttpGet("idLanche/{idLanche}")]
        public List<Lanche> Filtrar(int id)
        {
            return Contexto.Lanches.Where(c => c.IdLanche == id).ToList();
        }

        [HttpPost]
        [Route("add")]

        public async Task<ActionResult<Lanche>> Create (Lanche Lanche)
        {
            Lanche.IdLanche = 0;
            Contexto.Lanches.Add(Lanche);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Lanche.IdLanche, Lanche });
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Lanche>> Update(Lanche Lanche)
        {
            Contexto.Lanches.Add(Lanche);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Lanche.IdLanche, Lanche });
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Lanche>> Remove(Lanche Lanche)
        {
            Contexto.Lanches.Remove(Lanche);
            await Contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Lanche.IdLanche, Lanche });
        }
    }
}
