using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Modelo
{
    public class ModSucursal
    {
        private int modSucursalId;
        private string sucursal;
        public int ModSucursalId { get => modSucursalId; set => modSucursalId = value; }
        public string Sucursal { get => sucursal; set => sucursal = value; }
    }
}
