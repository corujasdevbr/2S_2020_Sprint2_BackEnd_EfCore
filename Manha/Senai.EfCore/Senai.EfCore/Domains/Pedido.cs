using System;
using System.Collections.Generic;

namespace Senai.EfCore.Domains
{
    public class Pedido : BaseDomain
    {
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        //Propriedade referente ao relacionamento na classe PedidoItem com a classe Pedido
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
