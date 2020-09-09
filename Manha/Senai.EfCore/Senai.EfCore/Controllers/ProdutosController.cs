using System;
using System.Collections.Generic;
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
        private IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return _produtoRepository.Listar();
        }

        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _produtoRepository.BuscarPorId(id);
        }

        [HttpPost]
        public void Post(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, Produto produto)
        {
            produto.Id = id;
            _produtoRepository.Editar(produto);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _produtoRepository.Remover(id);
        }
    }
}
