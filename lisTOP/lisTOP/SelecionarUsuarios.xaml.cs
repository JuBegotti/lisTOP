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
	public partial class SelecionarUsuarios : ContentPage
	{
        public List<UsuarioView> usuarios = new List<UsuarioView>();
		public SelecionarUsuarios ()
		{
			InitializeComponent ();
            foreach(Usuario u in Gambs.usuarios)
            {
                UsuarioView uV = new UsuarioView();
                uV.setUsuario(u);
                usuarios.Add(uV);
                this.containerUsuarios.Children.Add(uV);
            }
		}

        void OnButtonVoltar(object sender, EventArgs args)
        {
            Gambs.usuariosLista.Clear();
            int numHomens = 0;
            try
            {
                numHomens = Int32.Parse(entryHomens.Text);
            }catch(Exception ex)
            {
                numHomens = 0;
            }

            int numMulheres = 0;
            try
            {
                numMulheres = Int32.Parse(entryMulheres.Text);
            }
            catch (Exception ex)
            {
                numMulheres = 0;
            }
            for(int i = 0; i < numHomens; i++)
            {
                Usuario u = new Usuario();
                u.Mulher = false;
                u.FaixaEtaria = 3;
                Gambs.usuariosLista.Add(u);
            }
            for (int i = 0; i < numMulheres; i++)
            {
                Usuario u = new Usuario();
                u.Mulher = true;
                u.FaixaEtaria = 3;
                Gambs.usuariosLista.Add(u);
            }
            for(int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].IsSelecionado())
                {
                    Gambs.usuariosLista.Add(usuarios[i].usuario);
                }
            }

            Navigation.PopModalAsync();
        }

        void OnButtonAddUsuario(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new lisTOP.PagUsuario());
        }
    }
}