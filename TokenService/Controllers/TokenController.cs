using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Auth.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Auth.Services.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly DataMhsContext _context;
        public TokenController(
            IConfiguration configuration, DataMhsContext context
            )
        {

            _configuration = configuration;
            _context = context;
        }

        // GET: api/token
        [HttpPost]
        public async Task<IActionResult> Get([FromHeader]string NPM, [FromHeader] string PASSWORD)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Mahasiswa.FirstOrDefaultAsync(m => m.npm == NPM);
                if (user != null)
                {

                    cekPassword(PASSWORD,PASSWORD);
                    if (PASSWORD!=user.password2)
                     {
                        return Unauthorized();
                     }

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, NPM),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Token:Issuer"],
                        audience: _configuration["Token:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }

            return BadRequest();
        }
        private bool cekPassword(string password, string passwordDatabase)
        {

            
            Encoding enc = Encoding.GetEncoding(1252);
            RIPEMD160 ripemdHasher = RIPEMD160.Create();
            byte[] data = ripemdHasher.ComputeHash(Encoding.Default.GetBytes(password));
            string str = enc.GetString(data);

            Debug.Write("Password input " + str + "Password db " + passwordDatabase);
            if (str == passwordDatabase)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
