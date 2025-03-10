using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Jaryway.IdentityServer.Extensions
{
    internal class CustomJwtPayload : JwtPayload
    {
        public CustomJwtPayload(string issuer, string audience, IEnumerable<Claim> claims, DateTime? notBefore, DateTime? expires) :
            base(issuer, audience, claims, notBefore, expires)
        {
        }

        public override string SerializeToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
