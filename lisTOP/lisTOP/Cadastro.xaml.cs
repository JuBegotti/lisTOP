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
	public partial class Cadastro : ContentPage
	{
		public Cadastro ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, value: true);
        }

        void OnButtonPreferenciasCadastro(object sender, EventArgs args)
        {
           foreach(Restricao r in Gambs.preferencias)
            {
                r.Ativo = true;
            }
           foreach(Restricao r in Gambs.restricoes)
            {
                r.Ativo = false;
            }
            Navigation.PushModalAsync(new lisTOP.Preferencias(true));
        }

        void OnButtonRestricoesCadastro(object sender, EventArgs args)
        {
            foreach (Restricao r in Gambs.preferencias)
            {
                r.Ativo = true;
            }
            foreach (Restricao r in Gambs.restricoes)
            {
                r.Ativo = false;
            }
            Navigation.PushModalAsync(new lisTOP.Preferencias(false));
        }

        void OnButtonCadastrar(object sender, EventArgs args)
        {
            if((labelUsername.Text == null) || (labelUsername.Text.Length < 2))
            {
                erro.Text = "Digite um nome de usuário válido!";
                erro.IsVisible = true;
                return;
            }

            for(int i = 0; i < Gambs.usuarios.Count; i++)
            {
                if (labelUsername.Text.Equals(Gambs.usuarios[i].Username))
                {
                    erro.Text = "O nome de usuário já está sendo utilizado!";
                    erro.IsVisible = true;
                    return;
                }
            }

            Usuario u = new Usuario();
            u.Username = labelUsername.Text;
            if(switchCrianca.IsToggled) u.FaixaEtaria = 0;
            if (switchAdolescente.IsToggled) u.FaixaEtaria = 1;
            if (switchAdulto.IsToggled) u.FaixaEtaria = 2;
            if (switchIdoso.IsToggled) u.FaixaEtaria = 3;
            u.Atleta = switchExercicioSim.IsToggled;
            u.Mulher = (switchFeminino.IsToggled);

            u.Amendoim = Gambs.restricoes[0].Ativo;
            u.Carboidrato = Gambs.restricoes[1].Ativo;
            u.Glutem = Gambs.restricoes[2].Ativo;
            u.Lactose = Gambs.restricoes[3].Ativo;
            u.Ovo = Gambs.restricoes[4].Ativo;
            u.Proteina = Gambs.restricoes[5].Ativo;
            u.Soja = Gambs.restricoes[6].Ativo;
            u.Vegano = Gambs.restricoes[7].Ativo;
            u.Vegetariano = Gambs.restricoes[8].Ativo;

            u.Achocolatado = Gambs.preferencias[0].Ativo;
            u.Aves = !u.Vegetariano;
            u.Bolos = Gambs.preferencias[2].Ativo;
            u.Cafe = Gambs.preferencias[3].Ativo;
            u.CarneBovina = !u.Vegetariano;
            u.CarneSuina = !u.Vegetariano;
            u.Cereais = Gambs.preferencias[6].Ativo;
            u.CereaisMatinais = Gambs.preferencias[7].Ativo;
            u.Chas = Gambs.preferencias[8].Ativo;
            u.Embutidos = !u.Vegetariano;
            u.Especiarias = Gambs.preferencias[10].Ativo;
            u.Frios = Gambs.preferencias[11].Ativo;
            u.Frutas = Gambs.preferencias[12].Ativo;
            u.FrutosDoMar = !u.Vegetariano;
            u.Graos = Gambs.preferencias[14].Ativo;
            u.Guloseimas = Gambs.preferencias[15].Ativo;
            u.Hortalica = Gambs.preferencias[16].Ativo;
            u.Iogurte = !u.Vegano;
            u.Legumes = Gambs.preferencias[18].Ativo;
            u.Leite = !u.Vegano;
            u.Massas = Gambs.preferencias[20].Ativo;
            u.Ovos = !u.Vegano;
            u.Paes = Gambs.preferencias[22].Ativo;
            u.Peixes = !u.Vegetariano;
            u.Suco = Gambs.preferencias[24].Ativo;

            Gambs.usuarios.Add(u);
            App.DAUtil.AddUsuario(u);

            Navigation.PushModalAsync(new lisTOP.PagUsuario());
        }

        void OnButtonVoltar(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        void MudancaSexo(object sender, ToggledEventArgs e)
        {
            if (switchMasculino.IsToggled)
            {
                switchMasculino.IsToggled = true;
                switchFeminino.IsToggled = false;
            }
            if (switchFeminino.IsToggled)
            {
                switchMasculino.IsToggled = false;
                switchFeminino.IsToggled = true;
            }
                
        }

        void MudancaIdade(object sender, ToggledEventArgs e)
        {
            if (switchCrianca.IsToggled)
            {
                switchCrianca.IsToggled = true;
                switchAdolescente.IsToggled = false;
                switchAdulto.IsToggled = false;
                switchIdoso.IsToggled = false;
            }
            if (switchAdolescente.IsToggled)
            {
                switchCrianca.IsToggled = false;
                switchAdolescente.IsToggled = true;
                switchAdulto.IsToggled = false;
                switchIdoso.IsToggled = false;
            }
            if (switchAdulto.IsToggled)
            {
                switchCrianca.IsToggled = false;
                switchAdolescente.IsToggled = false;
                switchAdulto.IsToggled = true;
                switchIdoso.IsToggled = false;
            }
            if (switchIdoso.IsToggled)
            {
                switchCrianca.IsToggled = false;
                switchAdolescente.IsToggled = false;
                switchAdulto.IsToggled = false;
                switchIdoso.IsToggled = true;
            }
        }

        void MudancaExercicio(object sender, ToggledEventArgs e)
        {
            if (switchExercicioSim.IsToggled)
            {
                switchExercicioSim.IsToggled = true;
                switchExercicioNao.IsToggled = false;
            }
            if (switchExercicioNao.IsToggled)
            {
                switchExercicioSim.IsToggled = false;
                switchExercicioNao.IsToggled = true;
            }

        }
    }
}