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
	public partial class ListaConfirmacao : ContentPage
	{
        private List<ItemView> listaItems = new List<ItemView>();
        private Lista lista = Gambs.listaAtual.GerarLista(Gambs.nomeAtual);

		public ListaConfirmacao ()
		{
			InitializeComponent ();
            lista.id = -1;
            entryNome.Text = Gambs.nomeAtual;
            for(int i = 0; i < lista.compras.Count; i++)
            {
                adicionarItem(lista.compras[i]);
            }
        }

        public ListaConfirmacao(Lista lista)
        {
            InitializeComponent();
            entryNome.Text = lista.nomeLista;
            this.lista = lista;
            for (int i = 0; i < lista.compras.Count; i++)
            {
                adicionarItem(lista.compras[i]);
            }
        }

        public void RemoverItem(ItemView item)
        {
            this.containerLista.Children.Remove(item);
            this.listaItems.Remove(item);
        }

        void OnButtonAdicionar(object sender, EventArgs args)
        {
            adicionarItem();
        }

        void OnButtonSalvar(object sender, EventArgs args)
        {
            Lista l = new Lista();
            l.id = lista.id;
            l.nomeLista = entryNome.Text;
            l.compras = new List<Item>();
            for(int i = 0; i < containerLista.Children.Count; i++)
            {
                if (((ItemView)(containerLista.Children[i])).getItem() == null)
                    continue;
                Item it = ((ItemView)(containerLista.Children[i])).getItem();
                it.IdLista = l.id;
                l.compras.Add(it);
            }
            l.dataCriacao = DateTime.Now;
            if(l.id == -1)
            {
                App.DAUtil.AddLista(l);
            }
            else
            {
                App.DAUtil.UpdateLista(l);
            }
            
            
            Navigation.PushModalAsync(new lisTOP.VerListas());
        }

        void OnButtonVoltar(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        private void adicionarItem()
        {
            ItemView itemNovo = new ItemView(this);
            this.containerLista.Children.Add(itemNovo);
        }

        private void adicionarItem(Item item)
        {
            ItemView itemNovo = new ItemView(this);
            itemNovo.SetItem(item);
            this.containerLista.Children.Add(itemNovo);
        }
    }
}