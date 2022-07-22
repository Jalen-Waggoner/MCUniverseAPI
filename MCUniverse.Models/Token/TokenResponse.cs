using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCUniverse.Models.Token
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime IssuedAt { get; set; }
        public string Expires { get; set; }

    }
}
