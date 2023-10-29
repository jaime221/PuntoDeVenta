using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PuntoDeVenta.Context;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;
using PuntoDeVenta.Repositories.Inerfaces;
using PuntoDeVenta.Setting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PuntoDeVenta.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        private readonly TokenSetting _tokenSetting;


        public UsuarioRepository(ApplicationDBContext db, IMapper mapper, IOptions<TokenSetting> tokenSetting)
        {
            _db = db;
            _mapper = mapper;
            _tokenSetting = tokenSetting.Value;
        }

        public string GenerarToken(UsuarioDTO usuario)
        {
            var claveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Key));
            var credenciales = new SigningCredentials(claveSimetrica, SecurityAlgorithms.HmacSha256);
            var claimsUsuario = new List<Claim>
            {
                new Claim("Id", usuario.Id.ToString())

            };
            var jwt = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credenciales,
                claims: claimsUsuario
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }

        public async Task<UsuarioDTO> Login(UsuarioLogin login)
        {
            var entidad = await _db.Usuarios
                .FirstOrDefaultAsync(x => x.Correo == login.Correo && x.Clave == login.Clave);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }
    }
}
