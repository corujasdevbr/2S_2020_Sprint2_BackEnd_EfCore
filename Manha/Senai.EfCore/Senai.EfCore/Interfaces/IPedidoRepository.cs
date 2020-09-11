using Senai.EfCore.Domains;
using System.Collections.Generic;

namespace Senai.EfCore.Interfaces
{
    public interface IPedidoRepository
    {
        /// <summary>
        /// Lista todos os pedidos
        /// </summary>
        /// <returns>Retorna uma lista de pedidos</returns>
        List<Pedido> Listar();

        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Lista de pedidos itens</param>
        /// <returns>Objeto Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}
