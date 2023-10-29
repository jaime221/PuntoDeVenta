using PuntoDeVenta.DTOs;

namespace PuntoDeVenta.Repositories.Inerfaces
{
    public interface IUsuario
    {
        Task<UsuarioDTO> Login (UsuarioLogin login);
        string GenerarToken(UsuarioDTO usuario);
    }
}
