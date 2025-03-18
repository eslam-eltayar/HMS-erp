using HMS.Application.Authentication;
using HMS.Domain.Abstractions;
using HMS.Domain.Entities;
using HMS.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Features.Auth.Queries
{
    public class LoginQueryHandler(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider) : IRequestHandler<LoginQuery, Result<AuthResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<Result<AuthResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

            var isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isValidPassword)
                return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

            var (token, expiresIn) = _jwtProvider.GenerateToken(user);


            //await _userManager.UpdateAsync(user);

            var response = new AuthResponse(
                user.Id,
                user.Email,
                user.FirstName,
                user.LastName,
                token,
                expiresIn
                );

            //return Result<AuthResponse>.Success(response);

            return Result.Success(response);
        }
    }
}
