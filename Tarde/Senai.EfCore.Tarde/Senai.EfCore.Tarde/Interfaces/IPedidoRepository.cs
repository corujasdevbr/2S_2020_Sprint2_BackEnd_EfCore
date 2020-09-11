using Senai.EfCore.Tarde.Domains;
using System;
using System.Collections.Generic;

namespace Senai.EfCore.Tarde.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid id);
        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem> pedidosItens);
    }
}
