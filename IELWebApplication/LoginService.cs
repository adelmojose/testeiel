using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using IELCadastroEstudante.ViewModel;

namespace IELCadastroEstudante
{
    public class LoginService
    {
              public async Task Login(HttpContext ctx, UsuarioViewModel user)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.Usuario));
                claims.Add(new Claim(ClaimTypes.Role, user.Funcao));

                var claimsIdentity =
                    new ClaimsPrincipal(
                        new ClaimsIdentity(
                            claims,
                            CookieAuthenticationDefaults.AuthenticationScheme
                        )
                    );

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(8),
                    IssuedUtc = DateTime.Now
                };


                await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
            }

            public async Task Logoff(HttpContext ctx)
            {
                await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

    }   
}
