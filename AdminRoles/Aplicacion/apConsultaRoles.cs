using AdminRoles.Modelo;
using AdminRoles.Persistencia;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AdminRoles.Aplicacion
{
    public class apConsultaRoles
    {
        public class ListaRoles : IRequest<List<apModRolesDto>>
        {

        }
        public class Manejador : IRequestHandler<ListaRoles, List<apModRolesDto>>
        {
            private readonly ContextoRol _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoRol contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
          

            public async Task<List<apModRolesDto>> Handle(ListaRoles request, CancellationToken cancellationToken)
            {
                var roles = await _contexto.Roles.ToListAsync();
                var apModRoles = _mapper.Map<List<ModRoles>, List<apModRolesDto>>(roles);
                return apModRoles;
            }
        }

    }
}
