using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace lisTOP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Gambs.usuarios = App.DAUtil.GetAllUsuarios();
		}

        void OnButtonLogin(object sender, EventArgs args)
        {
            bool erroName = true;
            for(int i = 0; i < Gambs.usuarios.Count; i++)
            {
                if(entryUsername.Text == null)
                {
                    break;
                }
                if (entryUsername.Text.Equals(Gambs.usuarios[i].Username))
                {
                    erroName = false;
                }
            }

            if(!erroName)
            {
                Navigation.PushModalAsync(new lisTOP.VerListas());
            }
            
        }

        void OnButtonLoginFacebook(object sender, EventArgs args)
        {

        }

        void ButtonCadastro(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new lisTOP.Cadastro());
        }
    }
}
