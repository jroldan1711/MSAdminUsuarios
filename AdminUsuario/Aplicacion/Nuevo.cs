using AdminUsuario.Modelo;
using AdminUsuario.Persistencia;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdminUsuario.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : MediatR.IRequest
        {
            private string usuario;
            private List<int> listaRoles;

            public string Usuario { get => usuario; set => usuario = value; }
            public List<int> ListaRoles { get => listaRoles; set => listaRoles = value; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly UsuarioContexto _contexto;
            public Manejador(UsuarioContexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var modUsuario = new Usuarios
                {
                    Usuario = request.Usuario
                };

                _contexto.Usuarios.Add(modUsuario);
                var value = await _contexto.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("Errores en la insercion del carrito de compras");
                }

                int id = modUsuario.Id;

                foreach (var obj in request.ListaRoles)
                {
                    var roles = new RolesUsuarios
                    {

                        IdUsuario = id,
                        RolId = obj
                    };

                    _contexto.Roles_Usuarios.Add(roles);
                }

                value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudieron insertar los roles");

            }
        }
    }
}
