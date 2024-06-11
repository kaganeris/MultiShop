using System;

namespace MultiShop.IdentityServer.Tools
{
    public class TokenResponseViewModel
    {
        public TokenResponseViewModel(string token, DateTime expiredDate)
        {
            Token = token;
            ExpiredDate = expiredDate;
        }

        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}
