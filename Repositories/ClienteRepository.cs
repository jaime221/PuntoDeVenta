using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Context;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Repositories
{
    public class ClienteRepository : ICliente
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public ClienteRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> Clientes(int id)
        {
            var entidad = await _db.Clientes.FindAsync(id);
            var cliente = _mapper.Map<Cliente, ClienteDTO>(entidad);
            return cliente;
        }

        public async Task<ICollection<ClienteDTO>> Clientes()
        {
            var entidades = await _db.Clientes
                        .Where(c => c.Estado == 1)
                        .ToListAsync();

            var cliente = _mapper.Map<ICollection<Cliente>, ICollection<ClienteDTO>>(entidades);
            return cliente;
        }

        public async Task<int> Crear(ClienteDTO cliente)
        {
            var nuevoCliente = _mapper.Map<ClienteDTO, Cliente>(cliente);
            nuevoCliente.Estado = 1;

            await _db.Clientes.AddAsync(nuevoCliente);
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var cliente = await _db.Clientes.FindAsync(id);
            if (cliente == null)
                return 0;

            cliente.Estado = 0;

            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, ClienteDTO cliente)
        {
            var entidad = await _db.Clientes.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = cliente.Nombre;
            entidad.Apellido = cliente.Apellido;
            entidad.DUI = cliente.DUI;
            entidad.Telefono = cliente.Telefono;
            entidad.Correo = cliente.Correo;
            _db.Clientes.Update(entidad);
            return await Guardar();
        }
    }
}
