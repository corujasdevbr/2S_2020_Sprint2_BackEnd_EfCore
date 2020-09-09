using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Domains
{
    /// <summary>
    /// Domínio referente ao produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
    }
}
