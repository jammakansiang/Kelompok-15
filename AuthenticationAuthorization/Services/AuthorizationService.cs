using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using AuthenticationAuthorization.Models;

namespace AuthenticationAuthorization.Services
{
    public class AuthorizationService
    {   
        public bool HasRole(User user, params UserRole[] roles) =>
            roles.Contains(user.Role);

        public void Require(User user, UserRole role)
        {
            if (user.Role != role)
                throw new UnauthorizedAccessException(
                    $"Role {user.Role} tidak boleh membuka form {role}.");
        }
    }
}
