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
    public class RacaController : ControllerBase
    {
        RacaRepository repoR = new RacaRepository();
        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return repoR.ListarTodosRaça();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repoR.BuscarId(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public void Post([FromBody] Raca r)
        {
            repoR.Cadastrar(r);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Raca r)
        {
            repoR.Alterar(id, r);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repoR.Excluir(id);
        }
    }
}
