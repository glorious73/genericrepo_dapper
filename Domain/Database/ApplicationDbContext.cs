using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Domain.Database;

public class ApplicationDbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection(string connectionString = "DefaultConnection")
    {
        string? connection = _configuration.GetConnectionString(connectionString);
        return new NpgsqlConnection(connection);
        
    }
}