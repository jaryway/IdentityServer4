using System;
using IdentityModel;
using Jaryway.IdentityServer.Stores.Serialization;
using System.Security.Claims;
using System.Linq;

namespace Jaryway.IdentityServer.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ClaimsPrincipalLiteExtensions
    {
        /// <summary>
        /// Converts a ClaimsPrincipalLite to ClaimsPrincipal
        /// </summary>
        public static ClaimsPrincipal ToClaimsPrincipal(this ClaimsPrincipalLite principal)
        {
            var claims = principal.Claims.Select(x => new Claim(x.Type, x.Value, x.ValueType ?? ClaimValueTypes.String)).ToArray();
            var id = new ClaimsIdentity(claims, principal.AuthenticationType, JwtClaimTypes.Name, JwtClaimTypes.Role);

            return new ClaimsPrincipal(id);
        }

        /// <summary>
        /// Converts a ClaimsPrincipal to ClaimsPrincipalLite
        /// </summary>
        public static ClaimsPrincipalLite ToClaimsPrincipalLite(this ClaimsPrincipal principal)
        {
            var claims = principal.Claims.Select(
                    x => new ClaimLite
                    {
                        Type = x.Type,
                        Value = x.Value,
                        ValueType = x.ValueType == ClaimValueTypes.String ? null : x.ValueType
                    }).ToArray();

            return new ClaimsPrincipalLite
            {
                AuthenticationType = principal.Identity?.AuthenticationType!,
                Claims = claims
            };
        }
    }
}

