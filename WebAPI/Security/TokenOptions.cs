using System;

namespace WebAPI.Security
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationTime { get; set; }
        public string SecurityKey { get; set; }
    }
}
