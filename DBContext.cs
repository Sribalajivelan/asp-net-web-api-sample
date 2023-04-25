using System.Data;
using System.Data.SqlClient;

namespace AspDotWebAPISample;

public class DBContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DBContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetValue<string>("DatabaseSettings:ConnectionString");
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}