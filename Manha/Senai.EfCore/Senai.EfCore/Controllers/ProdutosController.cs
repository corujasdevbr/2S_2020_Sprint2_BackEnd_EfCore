using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using Senai.EfCore.Repositories;

namespace Senai.EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos no repositório
                var produtos = _produtoRepository.Listar();

                //Verifica se existe produtos, caso não exista retorna
                //NoContent - Sem Contúdo
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorna Ok e os produtos
                return Ok(new { 
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                //TODO: Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(new {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/produtos"
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Busco o produto no repositorio
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifica se o produto existe
                //Caso produto não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso produto exista retorna 
                //Ok e os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //retorna ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);

                if (produtoTemp == null)
                    return NotFound();

                produto.Id = id;
                _produtoRepository.Editar(produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }
    }
}
