using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ProAgilContext _context;
        public ValuesController(ProAgilContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //ActionResult<IEnumerable<Evento>>

            //NOTA: Esta é uma chama async sendo assim deve considerar a esperar da execução por linha
            //podem ser feitas várias requisições, e para cada chamada será aberta uma nova thread
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);

            }catch(System.Exception){

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }            

            /*
            return new Evento[] { 
                new Evento(){
                    EventoId = 1,
                    Tema = "Evento 1",
                    Local = "São Paulo",
                    Lote = "0001",
                    QtdPessoas = 150,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Evento 2",
                    Local = "Belo Horizonte",
                    Lote = "0002",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                }
             };
             */
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {            
            try
            {
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);

            }catch(System.Exception){

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            
            /*
            return new Evento[] { 
                new Evento(){
                    EventoId = 1,
                    Tema = "Evento 1",
                    Local = "São Paulo",
                    Lote = "0001",
                    QtdPessoas = 150,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento(){
                    EventoId = 2,
                    Tema = "Evento 2",
                    Local = "Belo Horizonte",
                    Lote = "0002",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                }
             }.FirstOrDefault(x => x.EventoId == id);
             */
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
