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
	public partial class UsuarioView : ContentView
	{
        public Usuario usuario;

		public UsuarioView ()
		{
			InitializeComponent ();
		}

        public void setUsuario(Usuario usuario)
        {
            this.usuario = usuario;
            labelUsuario.Text = usuario.Username;
            switchUsuario.IsToggled = true;
        }

        public Boolean IsSelecionado()
        {
            return switchUsuario.IsToggled;
        }
	}
}