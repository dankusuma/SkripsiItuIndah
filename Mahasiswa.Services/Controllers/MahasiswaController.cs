using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mahasiswa.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Mahasiswa.Services.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Mahasiswa")]
    public class MahasiswaController : Controller
    {
        private readonly DataMhsContext _context;

        public MahasiswaController(DataMhsContext context)
        {
            _context = context;
        }

     

        // GET: api/Mahasiswa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMahasiswaClass([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mahasiswaClass = await _context.Mahasiswa.Include(m=>m.fakultas).Include(m=>m.prodi).Include(m=>m.transkrip).Where(m=>m.transkrip.islast==true).SingleOrDefaultAsync(m => m.npm == id);

            if (mahasiswaClass == null)
            {
                return NotFound();
            }

            return Ok(mahasiswaClass);
        }

        

        private bool MahasiswaClassExists(string id)
        {
            return _context.Mahasiswa.Any(e => e.npm == id);
        }
    }
}