using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{
    public class Carrinho
    {
        public List<Frutas> ItensFrutas { get; private set; }
        public List<Carnes> ItensCarnes { get; private set; }
        public List<Lanches> ItensLanches { get; private set; }

        public Carrinho()
        {
            ItensFrutas = new List<Frutas>();
            ItensCarnes = new List<Carnes>();
            ItensLanches = new List<Lanches>();
        }

        public void AdicioarItens(Frutas produtoSelecionado)
        {
            ItensFrutas.Add(produtoSelecionado);
        }

        public void AdicioarItens(Carnes produtoSelecionado)
        {
            ItensCarnes.Add(produtoSelecionado);
        }

        public void AdicioarItens(Lanches produtoSelecionado)
        {
            ItensLanches.Add(produtoSelecionado);
        }

        public decimal CalcularTotal()
        {
            decimal totalFrutas = 0;
            decimal totalCarnes = 0;
            decimal totalLanches = 0;

            foreach (var item in ItensFrutas)
            {
                totalFrutas += item.Preco;
            }

            foreach (var item in ItensCarnes)
            {
                totalCarnes += item.Preco;
            }

            foreach (var item in ItensLanches)
            {
                totalLanches += item.Preco;
            }

            return totalFrutas + totalCarnes + totalLanches;
        }
    }
}
