using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{
    public class Sistema
    {
        private List<Frutas> frutas;
        private List<Carnes> carnes;
        private List<Lanches> lanches;
        public Carrinho carrinhos;

        public Sistema()
        {

            frutas = new List<Frutas>
            {
                new Frutas("Maçã", 2.50m, 100),
                new Frutas("Banana", 5.00m, 100),
                new Frutas("Laranja", 2.50m, 100),
                new Frutas("Uva", 5.00m, 100),
                new Frutas("Goiaba", 5.00m, 100)
             };

            carnes = new List<Carnes>
            {
                new Carnes("Alcatra", 9.00m, 100),
                new Carnes("Filé", 10.00m, 100),
                new Carnes("Picanha", 99.99m, 100),
                new Carnes("Pernil", 7.00m, 100),
                new Carnes("Linguiça", 5.00m, 100)
            };

            lanches = new List<Lanches>
            {
                new Lanches("Tapioca", 4.00m, 100),
                new Lanches("Bauru", 6.00m, 100),
                new Lanches("Pão de Queijo", 1.00m, 100),
                new Lanches("Torrada", 2.50m, 100),
                new Lanches("Coxinha", 1.50m, 100)
            };

            carrinhos = new Carrinho();
        }

        public void MostrarMenu()
        {

            Console.WriteLine("\nBem-vindo ao super mercado São João!\n");

            Console.WriteLine("\n1. Ver produtos");
            Console.WriteLine("2. Ver carrinho");
            Console.WriteLine("3. Finalizar compra");
            Console.WriteLine("4. Fechar");
        }
        public void ExibirOpções()
        {
            Console.WriteLine("\nEstas são as sessões disponíveis:");
            double secao;

            Console.WriteLine("\n1. Frutas");
            Console.WriteLine("2. Carnes");
            Console.WriteLine("3. Lanches");

            Console.Write("\nPor favor digite o número correspondente para a seção desejada: ");

            secao = Convert.ToInt32(Console.ReadLine());

            switch (secao)
            {
                case 1:
                    for (int i = 0; i < frutas.Count; i++)
                    {
                        var produto = frutas[i];
                        Console.WriteLine($"{i + 1} - {produto.Nome} - R${produto.Preco} - Estoque: {produto.QuantidadeEmEstoque}");
                    }

                    Console.Write("\nDigite o número do produto para adicionar ao carrinho: ");
                    int opcaoFruta = int.Parse(Console.ReadLine()) - 1;

                    if (opcaoFruta >= 0 && opcaoFruta < frutas.Count)
                    {
                        var produtoSelecionado = frutas[opcaoFruta];
                        carrinhos.AdicioarItens(produtoSelecionado);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida.\n");
                    }

                    break;

                case 2:
                    for (int a = 0; a < carnes.Count; a++)
                    {
                        var produto = carnes[a];
                        Console.WriteLine($"{a + 1} - {produto.Nome} - R${produto.Preco} - Estoque: {produto.QuantidadeEmEstoque}");
                    }

                    Console.Write("\nDigite o número do produto para adicionar ao carrinho: ");
                    int opcaoCarnes = int.Parse(Console.ReadLine()) - 1;

                    if (opcaoCarnes >= 0 && opcaoCarnes < carnes.Count)
                    {
                        var produtoSelecionado = carnes[opcaoCarnes];
                        carrinhos.AdicioarItens(produtoSelecionado);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida.\n");
                    }

                    break;

                case 3:
                    for (int b = 0; b < lanches.Count; b++)
                    {
                        var produto = lanches[b];
                        Console.WriteLine($"{b + 1} - {produto.Nome} - R${produto.Preco} - Estoque: {produto.QuantidadeEmEstoque}");
                    }

                    Console.Write("\nDigite o número do produto para adicionar ao carrinho: ");
                    int opcaoLanches = int.Parse(Console.ReadLine()) - 1;

                    if (opcaoLanches >= 0 && opcaoLanches < lanches.Count)
                    {
                        var produtoSelecionado = lanches[opcaoLanches];
                        carrinhos.AdicioarItens(produtoSelecionado);
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida.\n");
                    }
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Selecione uma sessão!\n");
                    break;
            }

        }

        public void ExibirCarrinho()
        {
            Console.WriteLine("\nItens no seu carrinho:\n");
            foreach (var item in carrinhos.ItensFrutas)
            {
                Console.WriteLine($"{item.Nome} - R${item.Preco}");
            }

            foreach (var item in carrinhos.ItensCarnes)
            {
                Console.WriteLine($"{item.Nome} - R${item.Preco}");
            }

            foreach (var item in carrinhos.ItensLanches)
            {
                Console.WriteLine($"{item.Nome} - R${item.Preco}");
            }

            decimal total = carrinhos.CalcularTotal();
            Console.WriteLine($"Total: R${total}");
        }

        public void FinalizarCompra()
        {
            decimal total = carrinhos.CalcularTotal();
            Console.WriteLine($"Compra finalizada! Total: R${total}");
            carrinhos = new Carrinho();
        }

        public void Executar()
        {
            bool continuar = true;
            while (continuar)
            {
                MostrarMenu();
                Console.Write("\nEscolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        ExibirOpções();
                        break;
                    case 2:
                        ExibirCarrinho();
                        break;
                    case 3:
                        FinalizarCompra();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }
            }

            Console.WriteLine("\nObrigado por comprar no supermercado São João!");
        }
    }
}