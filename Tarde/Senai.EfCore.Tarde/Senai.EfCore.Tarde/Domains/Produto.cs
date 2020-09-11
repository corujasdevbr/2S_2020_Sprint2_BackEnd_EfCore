using System.Collections.Generic;

namespace Senai.EfCore.Tarde.Domains
{
    /// <summary>
    /// Define a classe produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        //Relacionamento com a tabela PedidoItem 1,N
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
