using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Entity.Infrastructure;

namespace TAB.Library.Backend.Application.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        public DatabaseHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found!");

                LocalDbConnectionFactory factory = new();

                using var connection = factory.CreateConnection(connectionString);

                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "SELECT 1";
                await command.ExecuteScalarAsync();

                await connection.CloseAsync();

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
