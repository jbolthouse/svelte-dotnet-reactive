/**
 * Implementing cookie-based auth:
 * https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-5.0
 */

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi
{
    [ApiController]
    [Route("/session")]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignInUser(UserSignIn userSignIn)
        {
            // TODO Add validation principal service to validate sign in.

            var claims = new List<Claim> {
                // Add user claims to cookie here.
                new Claim("Email", "email@address.com"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);

            return new OkResult();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> SignOutUser()
        {
            await HttpContext.SignOutAsync();

            return new OkResult();
        }
    }
}
