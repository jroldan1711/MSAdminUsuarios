using AdminUsuariosRoles.Persistencia;
using AdminUsuariosRoles.RemoteInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<UsuarioDto>
        {

            public string Correo { set; get; }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioDto>
        {
            public readonly UsuarioContexto _contexto;
            private readonly IRolesService _rolesService;
            public Manejador(UsuarioContexto contexto, IRolesService rolesService)
            {
                _contexto = contexto;
                _rolesService = rolesService;
            }
            public async Task<UsuarioDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(x => x.Correo == request.Correo);
                var usuarioRoles = await _contexto.RolesUsuarios.Where(x => x.ModUsuarioId == usuario.ModUsuarioId).ToListAsync();
                var listaUsuarioRolDto = new List<UsuariosRolesDto>();
                foreach (var rol in usuarioRoles)
                {
                    var response = await _rolesService.GetRol(rol.ModRolId);
                    if (response.resultado)
                    {
                        ; var objRol = response.Rol;
                        var usuarioRol = new UsuariosRolesDto
                        {
                            Rolid = objRol.ModRolesId,
                            Rol = objRol.Rol
                        };
                        listaUsuarioRolDto.Add(usuarioRol);
                    }

                }
                var usuariodto = new UsuarioDto
                {
                    UsuarioId = usuario.ModUsuarioId,
                    Usuario=usuario.Usuario,
                    Correo=usuario.Correo,
                    Contraseña=usuario.Contraseña,
                    SucursalId=usuario.SucursalId,
                    ListaRoles = listaUsuarioRolDto
                };
                return usuariodto;
            }

        }
    }
}
