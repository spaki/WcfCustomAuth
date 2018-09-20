using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using WCFAuth.Contrato;
using WCFAuth.Servico;
using WCFAuth.WcfSettings;

namespace WCFAuth.Startup
{
    public class Startup
    {
        private ServiceHost servidor = new ServiceHost(
            typeof(ProdutoService), 
            new Uri[] { new Uri("http://localhost:7171") } 
        );

        public void Start()
        {
            // auth
            var serviceCredentials = new ServiceCredentials();
            serviceCredentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
            serviceCredentials.UserNameAuthentication.CustomUserNamePasswordValidator = new ServiceAuthenticator();

            servidor.Description.Behaviors.Add(serviceCredentials);

            // bind
            var binding = new BasicHttpBinding();
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            servidor.AddServiceEndpoint(
                typeof(IProdutoService),
                binding,
                "Produto.svc"
            );

            // mex
            servidor.Description.Behaviors.Add(new ServiceMetadataBehavior());
            servidor.AddServiceEndpoint(
                typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpBinding(),
                "mex"
            );

            servidor.Open();
        }

        public void Stop()
        {
            servidor.Close();
        }
    }
}
