using System.Collections.Generic;
using WCFAuth.Contrato;
using WCFAuth.Modelo;

namespace WCFAuth.Servico
{
    public class ProdutoService : IProdutoService
    {
        public List<Produto> Listar()
        {
            return new List<Produto> {
                new Produto { Id = 1, Nome = "iPhone XS", Preco = 100000000000 },
                new Produto { Id = 2, Nome = "Fusca", Preco = 5}
            };
        }
    }
}
