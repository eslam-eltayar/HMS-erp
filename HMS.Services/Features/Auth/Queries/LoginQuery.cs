using HMS.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Features.Auth.Queries
{
    public class LoginQuery : IRequest<Result<AuthResponse>>
    {
        public string Email { get; set; } 
        public string Password { get; set; }
    }
}
