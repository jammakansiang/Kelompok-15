using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text;
using MySqlConnector;
using AuthenticationAuthorization.Models;

namespace AuthenticationAuthorization.Services
{
    public class AuthService
    {
        private readonly string connectionString;

        public AuthService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User? Login(string username, string password)
        {
            username = username.Trim();

            using var connection = new MySqlConnection(connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT id, email, full_name, role
                                    FROM users
                                    WHERE username = @username
                                      AND password_hash = SHA2(@password, 256)
                                      AND is_active = TRUE";
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            connection.Open();
            using var reader = command.ExecuteReader();
            if (!reader.Read())
                return null;

            return new User(username, reader.GetString(1), reader.GetString(2),
                            Enum.Parse<UserRole>(reader.GetString(3)))
            {
                Id = reader.GetInt64(0)
            };
        }
    }
}
