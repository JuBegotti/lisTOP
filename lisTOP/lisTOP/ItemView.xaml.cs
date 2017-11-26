using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lisTOP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemView : ContentView
	{
        private ListaConfirmacao parent;
        private List<Item> produtosDisponiveis = new List<Item>();

        public ItemView()
        {
            InitializeComponent();
        }

		public ItemView (ListaConfirmacao parent)
		{
			InitializeComponent ();
            this.parent = parent;
            produtosDisponiveis = new List<Item>();
            if (Gambs.listaAtual.cafe || !Gambs.listaAtual.listaPreDef)
            {
                produtosDisponiveis.AddRange(Item.PegarTodosOsProdutosCafe());
            }
            if(Gambs.listaAtual.almoco || Gambs.listaAtual.janta || !Gambs.listaAtual.listaPreDef)
            {
                produtosDisponiveis.AddRange(Item.PegarTodosOsProdutosAlmoco());
            }
            pickerProduto.ItemsSource = produtosDisponiveis;
		}

        void OnButtonRemoverCompra(object sender, EventArgs args)
        {
            this.parent.RemoverItem(this);
        }

        public void SetItem(Item item)
        {
            for (int i = 0; i < pickerProduto.Items.Count; i++)
            {
                if (produtosDisponiveis[i].Nome.Equals(item.Nome))
                {
                    pickerProduto.SelectedIndex = i;
                    entryQtd.Text = item.Quantidade.ToString();
                }
            }
        }

        public Item getItem()
        {
            if (pickerProduto.SelectedIndex == -1)
                return null;
            return new Item(produtosDisponiveis[pickerProduto.SelectedIndex].Nome, Double.Parse(entryQtd.Text), produtosDisponiveis[pickerProduto.SelectedIndex].UnidadeMedida, produtosDisponiveis[pickerProduto.SelectedIndex].Classe, produtosDisponiveis[pickerProduto.SelectedIndex].IdAlimento);
        }

        void OnItemChange(object sender, EventArgs args)
        {
            entryQtd.Text = produtosDisponiveis[pickerProduto.SelectedIndex].Quantidade.ToString();
            lblUnidade.Text = produtosDisponiveis[pickerProduto.SelectedIndex].UnidadeMedida;
        }
    }
}