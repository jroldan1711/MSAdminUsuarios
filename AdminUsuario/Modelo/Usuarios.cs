using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuario.Modelo
{
    public class Usuarios
    {
        private int id;
        private string usuario;
        private string contraseña;
        private string correo;
        private int sucursalId;
        public ICollection<RolesUsuarios> ListaRolesUsuario { get; set; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Correo { get => correo; set => correo = value; }
        public int SucursalId { get => sucursalId; set => sucursalId = value; }
        public int Id { get => id; set => id = value; }
    }
}
