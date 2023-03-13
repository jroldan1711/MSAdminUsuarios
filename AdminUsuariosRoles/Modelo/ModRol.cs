using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Modelo
{
    public class ModRol
    {
        private int entRolId;
        private string rol;
        private string descripcion;

        public int EntRolId { get => entRolId; set => entRolId = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

    }
}
