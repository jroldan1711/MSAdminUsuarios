using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Modelo
{
    public class ModUsuario2
    {
        private int modUsuarioId;
        private string usuario;
        private string contraseña;
        private string correo;
        private int sucursalId;
        private ICollection<ModRolesUsuarios> listaRolesUsuario;

        public ICollection<ModRolesUsuarios> ListaRolesUsuario { get => listaRolesUsuario; set => listaRolesUsuario = value; }
        public int ModUsuarioId { get => modUsuarioId; set => modUsuarioId = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Correo { get => correo; set => correo = value; }
        public int SucursalId { get => sucursalId; set => sucursalId = value; }
    }
}
