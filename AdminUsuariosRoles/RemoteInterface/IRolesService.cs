using AdminUsuariosRoles.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.RemoteInterface
{
    public interface IRolesService
    {
        Task<(bool resultado, RolRemoto Rol, string ErrorMessage)> GetRol(int RolId);

    }
}
