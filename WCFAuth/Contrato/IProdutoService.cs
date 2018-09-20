using System.Collections.Generic;
using System.ServiceModel;
using WCFAuth.Modelo;

namespace WCFAuth.Contrato
{
    [ServiceContract]
    public interface IProdutoService
    {
        [OperationContract]
        List<Produto> Listar();
    }
}
