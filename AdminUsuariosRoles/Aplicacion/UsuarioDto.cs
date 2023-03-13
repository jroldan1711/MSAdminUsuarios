using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Aplicacion
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        private string usuario;
        private string contraseña;
        private string correo;
        private int sucursalId;
        public List<UsuariosRolesDto> ListaRoles { get; set; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Correo { get => correo; set => correo = value; }
        public int SucursalId { get => sucursalId; set => sucursalId = value; }
    }
}
