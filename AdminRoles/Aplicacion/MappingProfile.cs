using AdminRoles.Modelo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminRoles.Aplicacion
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<ModRoles, apModRolesDto>();
        }
    }
}
