using Infrastructure.Entity;
using Infrastructure.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class TokenManagerService
    {
        private static AccessToken _tokenValue = new("", 0);
        private static int MARGIN_TO_REFRESH_TOKEN = 600;  //Ten minutes in second

        public static void SetToken( AccessToken accessToken )
        {
            _tokenValue = accessToken;
        }
        public static string GetToken()
        {
            var valid = IsValid(_tokenValue);
            if( !valid )
            {
                throw new TokenException();
                /*return _tokenValue.access_token;*/
            }
            return _tokenValue.access_token;
        }
        private static bool IsValid(AccessToken accessToken)
        {
            return accessToken.expires_in > MARGIN_TO_REFRESH_TOKEN;
        }
    }
}
