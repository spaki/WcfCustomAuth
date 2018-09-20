using System;
using System.ServiceModel;
using WCFAuth.Contrato;

namespace ClientApp.Clients
{
    public class ProdutoServiceClient : IDisposable
    {
        private ChannelFactory<IProdutoService> channelFactory;

        public IProdutoService Service { get; private set; }

        public ProdutoServiceClient()
        {
            var binding = new BasicHttpBinding();
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            this.channelFactory = new ChannelFactory<IProdutoService>(binding, "http://localhost:7171/Produto.svc");
            this.channelFactory.Credentials.UserName.UserName = "admin";
            this.channelFactory.Credentials.UserName.Password = "1234567";
            this.Service = channelFactory.CreateChannel();
        }

        public void Dispose()
        {
            channelFactory.Close();
        }
    }
}
