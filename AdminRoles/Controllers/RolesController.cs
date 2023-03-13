using AdminRoles.Aplicacion;
using AdminRoles.Modelo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminRoles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(apCrearRol.Insertar data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<apModRolesDto>>> GetRoles()
        {
            return await _mediator.Send(new  apConsultaRoles.ListaRoles());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<apModRolesDto>> GetRolesEspecifico(int id) 
        {
            return await _mediator.Send(new apConsultaRol.RolEspecifico { ModRolesId = id });

        }


    }
}
