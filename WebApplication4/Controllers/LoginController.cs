using amabisca.Models;
using amabisca.modelsAux;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] loginClass login)
        {
            var user = new User();
            user.user = "indefinido";
            user.Email = "indefinido";
            user.UserId = "null";
            user.token = "error";

            if (login.CorreoElectronico != "correo@gmail.com")
            {
                return Ok(user.token);
            }
            else
            {
                if (login.Contrasenia != "password")
                {
                    return Ok(user.token);
                }
                else
                {
                    Console.WriteLine("Prueba Entrando 2");
                    var secretKey = _configuration.GetValue<string>("SecretKey");
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.NameIdentifier, "id1"),
                            new Claim(ClaimTypes.Name,"Raúl Sierra"),
                            new Claim(ClaimTypes.Email,"correo@gmail.com"),
                            new Claim(ClaimTypes.Role, "1")
                        }),
                        // Nuestro token va a durar un día
                        Expires = DateTime.UtcNow.AddDays(1),
                        // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var hola = tokenHandler.WriteToken(token);
                    user.user = "Raúl Sierra";
                    user.Email = "Raúl Sierra";
                    user.UserId = "id1";
                    user.token = hola;
                    return Ok(user);
                }
            }
            return Ok(user);
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
