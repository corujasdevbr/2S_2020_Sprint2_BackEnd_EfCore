using Senai.EfCore.DbFirst.Tarde.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.DbFirst.Tarde.Repositories
{
    public class ProdutoRepository
    {
        private readonly PedidoContex _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContex();
            _ctx.Pedidos.First
            
        }
    }
}
