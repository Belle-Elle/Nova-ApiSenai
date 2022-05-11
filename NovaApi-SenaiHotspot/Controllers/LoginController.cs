﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NovaApi_SenaiHotspot.Domains;
using NovaApi_SenaiHotspot.Interface;
using NovaApi_SenaiHotspot.Repositories;
using NovaApi_SenaiHotspot.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NovaApi_SenaiHotspot.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.NIF, login.Senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "NIF ou senha inválidos!");I
                }

               
                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    
                    new Claim("role", usuarioBuscado.Id.ToString()),


                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(""));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "",
                        audience: "",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
