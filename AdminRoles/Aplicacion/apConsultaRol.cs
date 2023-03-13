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
    public class apConsultaRol
    {
        public class RolEspecifico : IRequest<apModRolesDto>
        {
            public int ModRolesId { get; set; }
        }
        public class Manejador : IRequestHandler<RolEspecifico, apModRolesDto>
        {
            private readonly ContextoRol _contexto;
            private readonly IMapper _mapper;
            public Manejador(ContextoRol contexto,IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<apModRolesDto> Handle(RolEspecifico request, CancellationToken cancellationToken)
            {
                var rol = await _contexto.Roles.Where(x => x.ModRolesId == request.ModRolesId).FirstOrDefaultAsync();
                if (rol == null)
                {
                    throw new Exception("No se encontro el autor");
                }
                var apModRolesDto = _mapper.Map<ModRoles, apModRolesDto>(rol);
                return apModRolesDto;
            }
        }
    }
}
