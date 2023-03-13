using AdminUsuariosRoles.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioExpertosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioExpertosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(apCrearUsuario.Insertar data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("{correo}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuarios(string correo)
        {
            return await _mediator.Send(new Consulta.Ejecuta { Correo = correo });
        }

    }
}
