using AdminUsuario.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuario.Persistencia
{
    public class UsuarioContexto : DbContext
    {
        public UsuarioContexto(DbContextOptions<UsuarioContexto> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<RolesUsuarios> Roles_Usuarios { get; set; }
    }
}
