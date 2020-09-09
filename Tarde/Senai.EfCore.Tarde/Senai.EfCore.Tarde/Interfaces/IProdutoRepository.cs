using Senai.EfCore.Tarde.Domains;
using System;
using System.Collections.Generic;

namespace Senai.EfCore.Tarde.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        List<Produto> BuscarPorNome(string nome);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);
    }
}
