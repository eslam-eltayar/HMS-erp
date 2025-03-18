using HMS.Application.Features.Auth.Queries.Login;
using HMS.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<Result<AuthResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
