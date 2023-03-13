using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuario.Modelo
{
    public class RolesUsuarios
    {
        private int rolesUsuariosId;
        private int rolId;
        private int idUsuario;
        private Usuarios usuario;

        public int RolesUsuariosId { get => rolesUsuariosId; set => rolesUsuariosId = value; }
        public int RolId { get => rolId; set => rolId = value; }
        
        public Usuarios Usuario { get => usuario; set => usuario = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
