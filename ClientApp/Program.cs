using ClientApp.Clients;
using System;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var produtoClient = new ProdutoServiceClient();
            var produtos = produtoClient.Service.Listar();

            foreach (var item in produtos)
                Console.WriteLine($"{item.Nome}: {item.Preco:C}");

            Console.WriteLine();
            Console.WriteLine("Fim, tecle para finalizar...");
            Console.ReadKey();
        }
    }
}
