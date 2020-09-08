using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Domains
{
    public class Pedido 
    {
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
        }
    }
}
