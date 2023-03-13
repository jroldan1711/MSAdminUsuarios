using AdminUsuario.Aplicacion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminUsuariosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

    }
}
