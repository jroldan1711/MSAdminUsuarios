using AdminRoles.Modelo;
using AdminRoles.Persistencia;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdminRoles.Aplicacion
{
    public class apCrearRol : IRequest
    {
        public class Insertar : IRequest
        {
            private string rol;
            private string descripcion;
            public string Rol { get => rol; set => rol = value; }
            public string Descripcion { get => descripcion; set => descripcion = value; }
        }
        public class InsertaValidaion : AbstractValidator<Insertar>
        {
            public InsertaValidaion()
            {
                RuleFor(x => x.Rol).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
            }
        }


        public class Manejador : IRequestHandler<Insertar>
        {
            public readonly ContextoRol _contexto;

            public Manejador(ContextoRol contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Insertar request, CancellationToken cancellationToken)
            {
                var modRoles = new ModRoles { Rol = request.Rol, Descripcion=request.Descripcion};
                _contexto.Roles.Add(modRoles);
                var respuesta = await _contexto.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar un rol");
            }
        }

    }
}
