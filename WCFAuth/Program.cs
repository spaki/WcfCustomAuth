using System;
using Topshelf;

namespace WCFAuth
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<Startup.Startup>(service =>
                {
                    service.ConstructUsing(s => new Startup.Startup());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                
                configure.RunAsNetworkService(); // windows service account
                configure.SetServiceName("WCFProdutoService");
                configure.SetDisplayName("WCFProdutoService");
                configure.SetDescription("Serviço WCF de Produtos");
            });
        }
    }
}
