using MySql.Data.MySqlClient;

namespace AppWebMabley.Configs
{
    public class Conexao
    {
        private readonly string _connectionString;

        // Lê a ConnectionString do appsettings.json
        public Conexao(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("MySqlConnection") ?? "";
        }

        // Cria e abre uma nova conexão com o banco
        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        // Cria um comando SQL
        public MySqlCommand CreateCommand(
            string query,
            MySqlConnection? conn = null)
        {
            conn ??= GetConnection();
            return new MySqlCommand(query, conn);
        }
    }
}