using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class AccessToken
    {
        public string access_token { get; private set; }
        public int expires_in { get; private set; }
        public AccessToken( string access_token, int expires_in )
        {
            this.access_token = access_token;
            this.expires_in = expires_in;
        }
    }
}
