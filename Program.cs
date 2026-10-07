using System.Globalization;
using DesafioTarget.Estoque;
using DesafioTarget.Juros;
using DesafioTarget.Vendedor;

//Menu do projeto de inicialização mostrando cada opeção solicitada
Console.WriteLine("Digite qual operação deseja realizar");
 Console.WriteLine("1 - Comissão de Vendedor  ");
 Console.WriteLine("2 - Movimentar o  Estoque ");
 Console.WriteLine("3- Calcular juros ");

   int opcao = int.Parse(Console.ReadLine()); 

switch (opcao)// recebe a opcao do enu e encaminha a qual projeta deseja realizar
{
    case 1:
  // projeto 1 calcular a comissão do funcionario
        var comissao = new Vendedor();
        comissao.ComissaoDeCadaVendedor();
        break;

    case 2:
    //projeto dois entrada e saida de cada da quantida do produto
        Console.WriteLine("Digite qual opção desejada ");
        Console.WriteLine("1- Entrada de mercadoria ");
        Console.WriteLine("2- Saida de mercadoria ");

        
            var estoque = new Estoque();

        
      int opcaoEntradaOuSaida = int.Parse(Console.ReadLine());
        switch (opcaoEntradaOuSaida)// realiza a entrada ou sada
        {
            case 1:
            // realiza o projeto de entrada
                estoque.RetornarResultadoLIsta();
               Console.WriteLine("Digite o codigo do produto ");
                int codigoProdutoEntraada = int.Parse(Console.ReadLine());
            
               Console.WriteLine("Digite a quantidade da entrada");
            
                int quantidadeEntrada = int.Parse(Console.ReadLine());
                var tipoMovimentacao = new MovimentacaoEstoque
                {
                IdMovimentacao= Guid.NewGuid(),
                    CodigoProduto = codigoProdutoEntraada,
                    Descricao = "Entrada",
                    Quantidade = quantidadeEntrada

                };
                
                estoque.MovimentarEstoque(tipoMovimentacao);

                break;

            case 2:
            //realiza o projeto de saida 
             estoque.RetornarResultadoLIsta();

              Console.WriteLine("Digite o codigo do produto");
                int codigoProdutoSaida = int.Parse(Console.ReadLine());
            
               Console.WriteLine("Digite a quantidade da saida");
              int quantidadedeSaida = int.Parse(Console.ReadLine());

                var tipoDeMovimento2 = new MovimentacaoEstoque
                {
                    IdMovimentacao= Guid.NewGuid(),
                    CodigoProduto = codigoProdutoSaida,
                    Descricao = "Saida",
                    Quantidade = quantidadedeSaida



                };
               estoque.MovimentarEstoque(tipoDeMovimento2);
                break;

        }
        break;
    case 3:
    //projeto do calculo dos juros em cima da data de vencimento
            var juros = new Juros(); 
            Console.WriteLine("Digite o valor da prestação");
             double valorPrestacao = Double.Parse(Console.ReadLine());
            
               Console.WriteLine("Digite a data de Vencimento");
             string dataString = Console.ReadLine();
        
            DateTime dataVencimento = new DateTime();
             dataVencimento = DateTime.ParseExact(dataString ,"dd/MM/yyyy", CultureInfo.InvariantCulture);

            juros.JurosPorDataDeVencimento(2000, dataVencimento);
        break;
}
            





