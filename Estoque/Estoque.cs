using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;



namespace DesafioTarget.Estoque
{
    public class Estoque
    {
        EstoqueModel dadosDeEstoque; 
        string enderecoJson = "C:/C/DesafioTarget/DesafioTarget/Estoque/Estoque.json";
        List<ProdutoModel> listaProdutos = new List<ProdutoModel>();

        string jsonAtualizado = "";

        // Retorna a lista de produto
        public void RetornarResultadoLIsta()
        {
            RetornarEstoque();

             foreach (ProdutoModel produto in dadosDeEstoque.Estoque)
                       {
                        Console.WriteLine($"Codigo: {produto.CodigoProduto} , Descricao: {produto.DescricaoProduto}, Estoque: {produto.Estoque}");
                     }
               

        }

        // Realiza o retorno do estoque 
        public EstoqueModel RetornarEstoque()
        {
            string caminhoArquivo = Path.Combine(enderecoJson);

            if (File.Exists(caminhoArquivo))
            {

                string jsonString = File.ReadAllText(caminhoArquivo);

               var options = new JsonSerializerOptions
                 {
                     PropertyNameCaseInsensitive = true
                     };
               dadosDeEstoque = JsonSerializer.Deserialize<EstoqueModel>(jsonString,options);
          
            }
                   return dadosDeEstoque;  
         
           
        }

        public string AtualizacaoJson()
        {

            jsonAtualizado = JsonSerializer.Serialize(dadosDeEstoque);

            return jsonAtualizado;
        }


         //Realiza o tipo de movimentação se entrada ou saida 
        public void MovimentarEstoque(MovimentacaoEstoque tipoDeMovimento)
        {

            if (tipoDeMovimento.Descricao == "Entrada")
            {
                dadosDeEstoque = RetornarEstoque();

                listaProdutos = dadosDeEstoque.Estoque;



                ProdutoModel produtoExistente = listaProdutos.FirstOrDefault(p => p.CodigoProduto == tipoDeMovimento.CodigoProduto);

                if (produtoExistente != null)
                {

                    produtoExistente.Estoque = produtoExistente.Estoque + tipoDeMovimento.Quantidade;
                    var movimento = new MovimentacaoEstoque()
                    {
                        IdMovimentacao = tipoDeMovimento.IdMovimentacao,
                        Descricao = tipoDeMovimento.Descricao

                    };

                    produtoExistente.MovimentacaoEstoque = movimento;

                    Console.WriteLine($"ID : {tipoDeMovimento.IdMovimentacao} | Tipo: {tipoDeMovimento.Descricao} ");
                  
                

                   jsonAtualizado = AtualizacaoJson();
                   File.WriteAllText(enderecoJson, jsonAtualizado);



                    Console.WriteLine(); 
                    Console.WriteLine($"Quantidade Final do Produto {produtoExistente.DescricaoProduto}: {produtoExistente.Estoque}\n");                


                }
                else
                {
                    Console.WriteLine("Produto não existe");

                }

            }

            else if (tipoDeMovimento.Descricao == "Saida")
            {

                dadosDeEstoque = RetornarEstoque();

                listaProdutos= dadosDeEstoque.Estoque;


               ProdutoModel produtoExistente = listaProdutos.FirstOrDefault(p => p.CodigoProduto == tipoDeMovimento.CodigoProduto);

                if (produtoExistente != null)
                {

                    produtoExistente.Estoque = produtoExistente.Estoque - tipoDeMovimento.Quantidade;
                    var movimento = new MovimentacaoEstoque()
                    {
                        IdMovimentacao= tipoDeMovimento.IdMovimentacao,
                        Descricao = tipoDeMovimento.Descricao

                    };

                    produtoExistente.MovimentacaoEstoque= movimento;

                    Console.WriteLine($"ID Movimentação: {tipoDeMovimento.IdMovimentacao} | Tipo: {tipoDeMovimento.Descricao}");
                 
                    jsonAtualizado = AtualizacaoJson();

                    File.WriteAllText(enderecoJson, jsonAtualizado);
                   

                    Console.WriteLine(); 
                    Console.WriteLine($"Quantidade Final do Produto {produtoExistente.DescricaoProduto}: {produtoExistente.Estoque}\n");                
             
               
                }
                else
                {
                    Console.WriteLine("Produto não existe");

                }
                    
            }
     
        }


    }
        
}
