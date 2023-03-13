using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Modelo
{
    public class ModRolesUsuarios
    {
        private int modRolesUsuariosId;
        private int modRolId;
        private int modUsuarioId;
        private ModUsuario modUsuario;

        public int ModRolesUsuariosId { get => modRolesUsuariosId; set => modRolesUsuariosId = value; }
        public int ModRolId { get => modRolId; set => modRolId = value; }
        public ModUsuario ModUsuario { get => modUsuario; set => modUsuario = value; }
        public int ModUsuarioId { get => modUsuarioId; set => modUsuarioId = value; }
    }
}
