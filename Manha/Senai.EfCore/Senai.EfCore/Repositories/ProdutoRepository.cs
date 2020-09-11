using Senai.EfCore.Contexts;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace Senai.EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Produto a ser adcionado</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Dados salvos no contexto em memória
                _ctx.Produtos.Add(produto);
                //_ctx.Set<Produto>().Add(produto);
                //_ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                //Persisti os dados no banco de dados
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns></returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //List<Produto> produto = _ctx.Produtos.Where(c => c.Nome == "produto").ToList();
                //Produto produto = _ctx.Produtos.FirstOrDefault(c => c.Id == id); top 1
                return _ctx.Produtos.Find(id);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca produto pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produto">Dados do produto</param>
        public void Editar(Produto produto)
        {
            try
            {
                //Busco um produto pelo seu Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                ////Verifica se o produto existe, caso não exista gera uma exception
                //if (produtoTemp == null)
                //    throw new Exception("Produto não encontrado");

                //Altera as propriedades do produto
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera o produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva o produto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO: Cadastrar Tabela LogErro  mensagem de erro com Tag Geral
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os produto
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.ToList();
                return produtos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do Produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Busco um produto pelo seu Id
                Produto produto = BuscarPorId(id);

                //Verifica se o produto existe, caso não exista gera uma exception
                if (produto == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista remove o produto
                _ctx.Produtos.Remove(produto);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO : Incluir erro no log do banco de dados
                throw new Exception(ex.Message);
            }
        }
    }
}
