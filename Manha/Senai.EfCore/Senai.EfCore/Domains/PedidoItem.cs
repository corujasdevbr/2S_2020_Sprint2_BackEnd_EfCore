using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    public class PedidoItem
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        public Guid IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public PedidoItem()
        {
            Id = Guid.NewGuid();
        }
    }
}
