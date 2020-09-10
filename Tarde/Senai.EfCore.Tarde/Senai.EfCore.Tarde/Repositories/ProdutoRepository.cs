using Senai.EfCore.Tarde.Contexts;
using Senai.EfCore.Tarde.Domains;
using Senai.EfCore.Tarde.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.EfCore.Tarde.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura
        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma Lista de Produto</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns>Lista de produto</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //return _ctx.Produtos.FirstOrDefault(c => c.Id == id); top 1
                return _ctx.Produtos.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produtos pelo nome
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravação
        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verifica se produto existe
                //Caso não existe gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera sua propriedades
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera Produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva o contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona objeto do tipo produto ao dbset do contexto
                _ctx.Produtos.Add(produto);
                //_ctx.Set<Produto>().Add(produto);
                //_ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Salva as alterações no contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(id);

                //Remove o produto do dbSet
                _ctx.Produtos.Remove(produtoTemp);
                //Salva as alteráções do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO : Incluir erro na tabela de Log
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
