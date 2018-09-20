using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace WCFAuth.WcfSettings
{
    public class ServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "admin" && password != "1234567")
                throw new SecurityTokenException("Usuário ou senha inválidos");
        }
    }
}
