using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lisTOP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewUsuario : ContentView
    {
        private PagUsuario parent;
        Usuario usuario;

        public ListViewUsuario()
        {
            InitializeComponent();
        }

        public ListViewUsuario(PagUsuario parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        void OnButtonRemoverUsuario(object sender, EventArgs args)
        {
            App.DAUtil.RemoveUsuario(usuario);
            Gambs.usuarios.Remove(usuario);
            this.parent.RemoverUsuario(this);
        }

        void OnButtonVerUsuario(object sender, EventArgs args)
        {
            Gambs.usuario = this.usuario;
            Navigation.PushModalAsync(new lisTOP.VerInfoUsuario(usuario));
        }

        public void SetItem(Usuario usuario)
        {
            this.lblNomeUsuario.Text = "   " + usuario.Username;
            this.usuario = usuario;
        }

        Usuario getItem()
        {
            return usuario;
        }
    }
}
