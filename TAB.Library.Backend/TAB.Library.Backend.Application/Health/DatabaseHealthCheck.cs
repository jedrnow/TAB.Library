using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Entity.Infrastructure;

namespace TAB.Library.Backend.Application.Health
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly IConfiguration _configuration;
        public DatabaseHealthCheck(IDbConnectionFactory dbConnectionFactory, IConfiguration configuration)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _configuration = configuration;

        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found!");
                using var connection = _dbConnectionFactory.CreateConnection(connectionString);
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT 1";
                await command.ExecuteScalarAsync();

                return HealthCheckResult.Healthy();
            }
            catch(Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception: ex);
            }
        }
    }
}
