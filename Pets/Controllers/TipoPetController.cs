using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pets.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPetController : ControllerBase
    {
        TipoPetRepostory repoTP = new TipoPetRepostory();

        // GET: api/<TipoPetController>
        [HttpGet]
        public List<TipoPet> Get()
        {
            return repoTP.ListarTodosPet();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public TipoPet Get(int id)
        {
            return repoTP.BuscarId(id);
        }

        // POST api/<TipoPetController>
        [HttpPost]
        public void Post([FromBody] TipoPet tp)
        {
            repoTP.Cadastrar(tp);
        }

        // PUT api/<TipoPetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TipoPet tp)
        {
            repoTP.Alterar(id, tp);
        }

        // DELETE api/<TipoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repoTP.Excluir(id);
        }
    }
}
