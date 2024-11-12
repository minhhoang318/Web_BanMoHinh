using Microsoft.Extensions.Configuration;

namespace DAL.Helper
{
    public class DatabaseHelper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
