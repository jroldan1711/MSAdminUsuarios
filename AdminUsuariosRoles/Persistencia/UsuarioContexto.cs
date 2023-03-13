using AdminUsuariosRoles.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.Persistencia
{
    public class UsuarioContexto : DbContext
    {
        public UsuarioContexto(DbContextOptions<UsuarioContexto> options) : base(options) { }

        public DbSet<ModUsuario> Usuarios{ get; set; }
        public DbSet<ModRolesUsuarios> RolesUsuarios { get; set; }
        //public DbSet<ModSucursal> Sucursal { get; set; }
    }
}
