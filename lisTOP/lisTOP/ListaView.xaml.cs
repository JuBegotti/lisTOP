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
	public partial class ListaView : ContentView
	{
        private VerListas parent;
        public Lista lista;

        public ListaView ()
		{
			InitializeComponent ();
		}

        public ListaView(VerListas parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        void OnButtonRemoverLista(object sender, EventArgs args)
        {
            this.parent.RemoverItem(this);
        }

        void OnButtonEditarLista(object sender, EventArgs args)
        {
            Gambs.listaAtual.listaPreDef = false;
            Navigation.PushModalAsync(new lisTOP.ListaConfirmacao(this.lista));
        }

        void OnButtonVerLista(object sender, EventArgs args)
        {
            Gambs.listaAtual.listaPreDef = false;
            Navigation.PushModalAsync(new lisTOP.ListaConfirmacao(this.lista));
        }

        public void SetItem(Lista lista)
        {
            this.lblNomeLista.Text = "   " + lista.dataCriacao.ToShortDateString() + " - " + lista.nomeLista;
            this.lista = lista;
        }

        Lista getItem()
        {
            return lista;
        }
    }
}