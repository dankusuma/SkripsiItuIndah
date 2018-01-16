using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahasiswa.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mahasiswa.Services.Controllers
{

    [Route("")]

    public class MahasiswaController : Controller
    {
          private readonly DataMhsContext _context;

        public MahasiswaController(DataMhsContext context)
        {
            _context = context;

            
        }

        // GET: api/Mahasiswa
        [HttpGet]
        public IActionResult Get()
        {
           
            return BadRequest();
        }

        // GET: api/Mahasiswa/5
        [HttpGet("{npm}", Name = "Get")]
        public IActionResult Get(string npm)
        {
            var mhs = _context.Mahasiswa.Include("PRODI").Include("FAKULTAS").Include("TRANSKRIP").FirstOrDefault(t => t.NPM == npm);
            if (mhs == null)
            {
                return NotFound();
            }
            return  Ok(new ObjectResult(mhs));
            
        }
        
        // POST: api/Mahasiswa
        [HttpPost]
        public void Post([FromBody]string value)
        {
        
        }
        
        // PUT: api/Mahasiswa/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
           
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        
    }
}
