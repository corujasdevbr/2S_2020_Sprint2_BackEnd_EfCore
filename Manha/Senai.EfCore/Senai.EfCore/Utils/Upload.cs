using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Senai.EfCore.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gero o nome do arquivo único
            //Pego a extensão do arquivo
            //Concateno o nome do arquivo com sua exteñsão
            //98889898r9uwe8urweuhuwhfyf.png
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //GetCurrentDirectory - Pega o caminho do diretório atual, aplicação esta
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //Crio um objeto do tipo FileStream passando o caminho do arquivo
            //Passa para criar este arquivo
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Executo o comando de criação do arquivo no local informado
            file.CopyTo(streamImagem);

            //Aws,Azure,Cloud Storage
            //var urlImagem = Chamada ao método.Salvar(nomearquivo)

            return "http://localhost:51557/upload/imagens/" + nomeArquivo;
        }
    }
}
