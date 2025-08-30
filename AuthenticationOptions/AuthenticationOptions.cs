using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace messanger.AuthenticationOptions
{
    public class AuthenticationOptions
    {
        public const string ISSUER = "MyMessanger";
        public const string AUDIENCE = "MyAuthClient";
        const string KEY = "fsdsrgfrfesfsdfsefaqdsadgfergredasfasd34234321423";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
