using Senai.EfCore.Manha.DbFirst.Contexts;

namespace Senai.EfCore.Manha.DbFirst.Repositories
{
    
    public class ProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
    }
}
