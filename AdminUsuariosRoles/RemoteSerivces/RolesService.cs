using AdminUsuariosRoles.RemoteInterface;
using AdminUsuariosRoles.RemoteModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminUsuariosRoles.RemoteSerivces
{
    public class RolesService : IRolesService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<RolesService> _logger;

        public RolesService(IHttpClientFactory httpClient, ILogger<RolesService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, RolRemoto Rol, string ErrorMessage)> GetRol(int RolId)
        {
            try
            {
                var cliente = _httpClient.CreateClient("Roles");
                var response = await cliente.GetAsync($"api/Roles/{RolId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido =  await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<RolRemoto>(contenido, options);
                    return (true, resultado, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }  
        }
    }
}
