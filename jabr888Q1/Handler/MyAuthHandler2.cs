using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using jabr888Q1.Data;
using System.Net.Http.Headers;
using System.Text;
using jabr888Q1.Models;
using System.Security.Claims;


namespace jabr888Q1.Handler
{
    public class MyAuthHandler2 : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IWebAPIRepo _repository;

        public MyAuthHandler2(
            IWebAPIRepo repository,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _repository = repository;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                Response.Headers.Add("WWW-Authenticate", "Basic");
                return AuthenticateResult.Fail("Authorization header not found.");
            }
            else
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(":");
                var username = credentials[0];
                var password = credentials[1];
                int id = int.Parse(username);

                if (_repository.ValidLogin2(id, password))
                {
                    var claims = new[] { new Claim("userName", username) };

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                    return AuthenticateResult.Fail("id and password do not match");
            }
        }
    }
}
