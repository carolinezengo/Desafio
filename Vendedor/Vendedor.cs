using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


namespace DesafioTarget.Vendedor
{
    public class Vendedor
    {

        double comissao = 0;

       List<VendedorModel> listaVendas = new List<VendedorModel>();
        List<(string nome, double comissao)> listacomissao = new List<(string, double)>();
      
         // Função que calcula a taxa de comissão de cada funcionario confome o valor da venda
        public double CalcularTaxaComissao(Double valorVenda)
        {

            if (valorVenda < 100)
            {
                comissao = 0;

            }
            else if (valorVenda >= 100 && valorVenda < 500)
            {
                comissao = valorVenda / 100;

            }
            else if (valorVenda >= 500)
            {
                comissao = (valorVenda * 5) / 100;

            }



            return comissao;
        }

        //Função que calcula a comissao do vendedor conforme suas vendas 
        public void ComissaoDeCadaVendedor()
        {

            string tabelaDeVenda = Path.Combine("C:/C/DesafioTarget/DesafioTarget/Vendedor/Vendedor.json");
            if (tabelaDeVenda != null)
            {
                string jsonString = File.ReadAllText(tabelaDeVenda);

                if (jsonString != null)
                {
                    VendasPorVendedor dados = JsonSerializer.Deserialize<VendasPorVendedor>(jsonString);

                    listaVendas = dados.Vendas;
                    if (listaVendas != null)
                    {
                        foreach (var venda in listaVendas)
                        {
                            bool encontrado = false;
                        

                            for (int i = 0; i < listacomissao.Count; i++)
                            {

                                if (listacomissao[i].nome == venda.Vendedor)
                                {


                                    listacomissao[i] = (venda.Vendedor, listacomissao[i].comissao + CalcularTaxaComissao(venda.Valor));
                                    encontrado = true;
                                    break;


                                }


                            }

                            if (!encontrado)
                            {
                                var resultadoComissao = CalcularTaxaComissao(venda.Valor);
                                listacomissao.Add((venda.Vendedor, resultadoComissao));
                            }

                        }

                        foreach (var vendedor in listacomissao)
                        {
                            Console.WriteLine($"O Vendedor: {vendedor.nome}, obteve de comissao: {vendedor.comissao.ToString("N2")}");

                        }

                    }
                    else
                    {
                           Console.WriteLine("Lista Vazia ");
                    }



                }
                else
                {
                    Console.WriteLine("Arquivo JsonVazio ");
                }
            }
            else
            {
               Console.WriteLine("Arquivo  ");
            }
        }
    }
}
        
    
