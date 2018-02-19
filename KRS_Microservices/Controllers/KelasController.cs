using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kelas.Services.Models;
using System.Net.Http;
using System.Net;
using static IdentityModel.OidcConstants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Kelas.Services.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/Kelas")]
    public class KelasController : Controller
    {
        private readonly DataKelasContext _context;

        public KelasController(DataKelasContext context)
        {
            _context = context;
        }

        // GET: api/Kelas/5
        [HttpGet("{id}")]
        public IActionResult GetKelas(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<KelasKrsClass> kelaskrs = _context.KelasKRS.Include(m=>m.kelas).Include(m=>m.kelas.dosen1).Include(m => m.kelas.dosen2).Include(m => m.kelas.dosen3).Include(m => m.kelas.dosen4).Where(m => m.id_prodi_tawar == id).Where(m=>m.tahun_akademik.iscurrent==true).Where(m=>m.kelas.iscurrent==true).ToList();
            if (kelaskrs.Count()==0)
            {
                return NotFound();    
            }
            return Ok(kelaskrs);
        }


    }
}