using AdminUsuariosRoles.Modelo;
using AdminUsuariosRoles.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Aplicacion
{
    public class apCrearUsuario
    {
        public class Insertar : IRequest
        {
            private string usuario;
            private string contraseña;
            private string correo;
            private int sucursalId;
            private List<int> listaRoles;
            public string Usuario { get => usuario; set => usuario = value; }
            public string Contraseña { get => contraseña; set => contraseña = value; }
            public string Correo { get => correo; set => correo = value; }
            public List<int> ListaRoles { get => listaRoles; set => listaRoles = value; }
            public int SucursalId { get => sucursalId; set => sucursalId = value; }
        }
        public class Manejador : IRequestHandler<Insertar>
        {
            private readonly UsuarioContexto _contexto;

            public Manejador(UsuarioContexto contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Insertar request, CancellationToken cancellationToken)
            {
                var modUsuario = new ModUsuario
                {
                    Usuario = request.Usuario,
                    Contraseña = request.Contraseña,
                    Correo = request.Correo,
                    SucursalId = request.SucursalId
                };
                var usuVerificar = await _contexto.Usuarios.Where(x => x.Correo == request.Correo).FirstOrDefaultAsync();
                if (usuVerificar is null)
                {
                    _contexto.Usuarios.Add(modUsuario);
                    var value = await _contexto.SaveChangesAsync();


                    int idUsuario = modUsuario.ModUsuarioId;

                    foreach (var obj in request.ListaRoles)
                    {
                        var modUsuariosRoles = new ModRolesUsuarios
                        {
                            ModUsuarioId = idUsuario,
                            ModRolId = obj
                        };

                        _contexto.RolesUsuarios.Add(modUsuariosRoles);
                    }
                    value = await _contexto.SaveChangesAsync();
                    {
                        if (value > 0)
                        {
                            return Unit.Value;
                        }
                        throw new Exception("No se pudo insertar un nuevo rol al usuario ");
                    }
                }
                else
                {
                    usuVerificar.SucursalId = request.SucursalId;
                    usuVerificar.Usuario = request.Usuario;
                    usuVerificar.Contraseña = request.Contraseña;
                    _contexto.Usuarios.Update(usuVerificar);
                    var value = await _contexto.SaveChangesAsync();
                    if (value == 0)
                    {
                        throw new Exception("Errores en la insercion del Usuario");
                    }

                    //Eliminar Roles
                    var roles = _contexto.RolesUsuarios.Where(obj => obj.ModUsuarioId == usuVerificar.ModUsuarioId);
                    if (roles.Count() > 0)
                    {
                        _contexto.RolesUsuarios.RemoveRange(roles);
                        value = await _contexto.SaveChangesAsync();
                        if (value == 0)
                        {
                            throw new Exception("Errores en la eliminación de Roles");
                        }
                    }
                    
                    //Insertar Roles
                    foreach (var obj in request.ListaRoles)
                    {
                        var modUsuariosRoles = new ModRolesUsuarios
                        {
                            ModUsuarioId = usuVerificar.ModUsuarioId,
                            ModRolId = obj
                        };

                        _contexto.RolesUsuarios.Add(modUsuariosRoles);
                    }

                    value = await _contexto.SaveChangesAsync();
                    {
                        if (value > 0)
                        {
                            return Unit.Value;
                        }
                        throw new Exception("No se pudo insertar un nuevo rol al usuario ");
                    }
                }

            }
        }
    }

}
