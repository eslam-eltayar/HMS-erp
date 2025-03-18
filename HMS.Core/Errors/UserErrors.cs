using HMS.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Errors
{
    public static class UserErrors
    {
        public static readonly Error InvalidCredentials
            = new("User.InvalidCredentials", "Invalid email/password", StatusCodes.Status401Unauthorized);
    }
}
