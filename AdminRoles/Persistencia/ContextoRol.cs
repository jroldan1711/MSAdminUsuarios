
using AdminRoles.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminRoles.Persistencia  
{
    public class ContextoRol : DbContext     
    {

        public ContextoRol(DbContextOptions<ContextoRol> options) : base(options) { }
        public DbSet<ModRoles> Roles { get; set; }
    }
}
