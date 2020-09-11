using Microsoft.EntityFrameworkCore;
using Senai.EfCore.Tarde.Contexts;
using Senai.EfCore.Tarde.Domains;
using Senai.EfCore.Tarde.Interfaces;
using Senai.EfCore.Tarde.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Tarde.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Criação do pobjeto do tipo pedido passando os valores
                Pedido pedido = new Pedido
                { 
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                    //PedidosItens = new List<PedidoItem>()
                };

                
                //Percorre a lista de pedidos itens e adciona a lista de pedidosItens
                foreach (var item in pedidosItens)
                {
                    //Adciona um pedidoitem a lista
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //Id do objeto pedido criado acima
                        IdProduto = item.IdProduto,
                        Quantidade = item.Quantidade
                    });
                }

                //Adiciono o pedido ao meu contexto
                _ctx.Pedidos.Add(pedido);
                //Salva as alterações do contexto no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.PedidosItens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id); //Inner Join
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
