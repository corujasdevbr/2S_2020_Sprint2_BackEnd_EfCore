using System.Collections.Generic;

namespace Senai.EfCore.Domains
{
    /// <summary>
    /// Domínio referente ao produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        //Propriedade referente ao relacionamento na classe PedidoItem com a classe Pedido
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
