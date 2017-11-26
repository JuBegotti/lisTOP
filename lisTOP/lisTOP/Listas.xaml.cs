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
	public partial class Listas : ContentPage
	{
        private String[] tipos = { "Pré-definido", "Personalizado" };
        private String[] usuarios = { "Todos os usuários cadastrados", "Editar usuários da lista" };

		public Listas ()
		{
			InitializeComponent ();
            pickerTipo.ItemsSource = tipos;
            Gambs.usuariosLista = App.DAUtil.GetAllUsuarios();
        }

        void OnButtonProximo(object sender, EventArgs args)
        {
            if (entryNome.Text == null)
            {
                erroNomeLista.Text = "Digite o nome da lista!";
                erroNomeLista.IsVisible = true;
                return;
            }
            if (entryPeriodo.Text == null && pickerTipo.SelectedIndex == 0)
            {
                erroNumSemanas.Text = "Digite o número de semanas!";
                erroNumSemanas.IsVisible = true;
                return;
            }

            if (pickerTipo.SelectedIndex!=0 && pickerTipo.SelectedIndex != 1)
            {
                erroPicker.Text = "Escolha o tipo de lista!";
                erroPicker.IsVisible = true;
                return;
            }

            Gambs.listaAtual.listaPreDef = ((pickerTipo.SelectedIndex == 0) ? true : false);
            if (Gambs.listaAtual.listaPreDef)
            {
                Gambs.listaAtual.almoco = switchAlmoco.IsToggled;
                Gambs.listaAtual.cafe = switchCafe.IsToggled;
                Gambs.listaAtual.janta = switchJanta.IsToggled;
                Gambs.listaAtual.periodo = Int32.Parse(entryPeriodo.Text);
            }
            
            Gambs.nomeAtual = entryNome.Text;

            Navigation.PushModalAsync(new lisTOP.ListaConfirmacao());
        }

        void OnButtonVoltar(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        void OnPickerIndexChange(object sender, EventArgs args)
        {
            if(pickerTipo.SelectedIndex == 0)
            {
                switchCafe.IsVisible = true;
                switchAlmoco.IsVisible = true;
                switchJanta.IsVisible = true;
                labelCafe.IsVisible = true;
                labelAlmoco.IsVisible = true;
                labelJanta.IsVisible = true;
                entryPeriodo.IsVisible = true;
                buttonUsuarios.IsVisible = true;
            }
            else
            {
                switchCafe.IsVisible = false;
                switchAlmoco.IsVisible = false;
                switchJanta.IsVisible = false;
                labelCafe.IsVisible = false;
                labelAlmoco.IsVisible = false;
                labelJanta.IsVisible = false;
                entryPeriodo.IsVisible = false;
                buttonUsuarios.IsVisible = false;
            }
        }
        void OnPickerUsuarioChange(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new lisTOP.SelecionarUsuarios());
        }
    }
}