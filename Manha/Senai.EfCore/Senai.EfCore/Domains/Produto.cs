using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.EfCore.Domains
{
    /// <summary>
    /// Domínio referente ao produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        [NotMapped] //Não mapeia a propriedade no banco de dados
        [JsonIgnore] //Ignora propriedade no retorno no Json
        public IFormFile Imagem { get; set; }

        //Url da imagem do produto salva no servidor
        public string UrlImagem { get; set; }

        //Propriedade referente ao relacionamento na classe PedidoItem com a classe Pedido
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
