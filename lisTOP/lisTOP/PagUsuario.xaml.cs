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
	public partial class PagUsuario : ContentPage
	{
        public PagUsuario()
        {
            InitializeComponent();
            for (int i = 0; i < Gambs.usuarios.Count; i++)
            {
                ListViewUsuario itemNovo = new ListViewUsuario(this);
                itemNovo.SetItem(Gambs.usuarios[i]);
                containerUsuarios.Children.Add(itemNovo);
            }
        }

        public void RemoverUsuario(ListViewUsuario item)
        {
            containerUsuarios.Children.Remove(item);
        }

        void OnButtonAdicionarUsuario(object sender, EventArgs args)
        {
            Gambs.usuario = new Usuario();
            Navigation.PushModalAsync(new lisTOP.Cadastro());
        }

        void OnButtonVoltar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new lisTOP.VerListas());
        }
    }
}