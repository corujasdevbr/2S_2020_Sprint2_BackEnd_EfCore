using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Domains
{
    /// <summary>
    /// Domínio referente ao produto
    /// </summary>
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}
