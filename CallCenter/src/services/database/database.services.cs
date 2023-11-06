using System.Data;
using Microsoft.Data.SqlClient;

public class DatabaseServices
{
    private readonly string _connectionString;

    public DatabaseServices(IConfiguration configuration)
    {
        _connectionString = configuration.GetSection("Database:DefaultConnection").Value;
    }

    public SqlConnection GetOpenConnection()
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public SqlCommand CreateCommand(string query, SqlConnection connection)
{
    SqlCommand command = new SqlCommand(query, connection);
    return command;
}

    public void CloseConnection(SqlConnection connection)
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
}
