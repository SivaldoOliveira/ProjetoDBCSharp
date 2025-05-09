﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace SimpleGameApi.Models.Infrastructure.Data.Contexts;

public class ConnectionManager : IDisposable
{
    private readonly string _connectionString;
    private IDbConnection _connection;

    public ConnectionManager(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("JogosDb") ??
              throw new ArgumentException("Connectionm String não localizada");
    }

    public IDbConnection GetConnection()
    {
        if (_connection == null || _connection.State == ConnectionState.Closed)
        {
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
        }
        return _connection;
    }
    public void Dispose()
    {
        if (_connection != null)
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();

            _connection.Dispose();
            _connection = null;

        }
    }
}
