using System;
using System.Collections.Generic;

namespace Senai.EfCore.Manha.DbFirst.Domains
{
    public partial class Produtos
    {
        public Produtos()
        {
            PedidosItens = new HashSet<PedidosItens>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public virtual ICollection<PedidosItens> PedidosItens { get; set; }
    }
}
