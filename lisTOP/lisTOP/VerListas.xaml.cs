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
	public partial class VerListas : ContentPage
	{
		public VerListas ()
		{
			InitializeComponent ();
            for(int i = 0; i < Gambs.listas.Count; i++)
            {
                ListaView itemNovo = new ListaView(this);
                itemNovo.SetItem(Gambs.listas[i]);
                containerListas.Children.Add(itemNovo);
            }
		}

        public void RemoverItem(ListaView item)
        {
            Gambs.listas.Remove(item.lista);
            App.DAUtil.RemoveLista(item.lista);
            containerListas.Children.Remove(item);
        }

        void OnButtonAdicionarLista(object sender, EventArgs args)
        {
            Gambs.listaAtual = new OpcoesLista();
            Navigation.PushModalAsync(new lisTOP.Listas());
        }

        void OnButtonEditarUsuarios(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new lisTOP.PagUsuario());
        }
    }
}