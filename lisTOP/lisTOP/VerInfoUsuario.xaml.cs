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
	public partial class VerInfoUsuario : ContentPage
	{
		public VerInfoUsuario (Usuario u)
		{
			InitializeComponent ();
            VerUsuarioNome.Text = u.Username;
            VerUsuarioSexo.Text = u.Mulher ? "Feminino, " : "Masculino, ";
            if (u.FaixaEtaria==0) VerUsuarioIdade.Text = "Criança, ";
            if (u.FaixaEtaria == 1) VerUsuarioIdade.Text = "Adolescente, ";
            if (u.FaixaEtaria == 2) VerUsuarioIdade.Text = "Adulto, ";
            if (u.FaixaEtaria == 3) VerUsuarioIdade.Text = "Idoso, ";
            VerUsuarioAtleta.Text = u.Atleta ? "Atleta." : "Não atleta.";

            if (u.Amendoim) VerAmendoim.IsVisible = true;
            if (u.Carboidrato) VerCarboidrato.IsVisible = true;
            if (u.Glutem) VerGlutem.IsVisible = true;
            if (u.Lactose) VerLactose.IsVisible = true;
            if (u.Ovo) VerOvo.IsVisible = true;
            if (u.Proteina) VerProteina.IsVisible = true;
            if (u.Soja) VerSoja.IsVisible = true;
            if (u.Vegano) VerVegano.IsVisible = true;
            if (u.Vegetariano) VerVegetariano.IsVisible = true;

            if (u.Achocolatado) VerAchocolatado.IsVisible = true;
            if (u.Aves) VerAves.IsVisible = true;
            if (u.Bolos) VerBolos.IsVisible = true;
            if (u.Cafe) VerCafe.IsVisible = true;
            if (u.CarneBovina) VerCarneBovina.IsVisible = true;
            if (u.CarneSuina) VerCarneSuina.IsVisible = true;
            if (u.Cereais) VerCereais.IsVisible = true;
            if (u.CereaisMatinais) VerCereaisMatinais.IsVisible = true;
            if (u.Chas) VerChas.IsVisible = true;
            if (u.Embutidos) VerEmbutidos.IsVisible = true;
            if (u.Especiarias) VerEspeciarias.IsVisible = true;
            if (u.Frios) VerFrios.IsVisible = true;
            if (u.Frutas) VerFrutas.IsVisible = true;
            if (u.FrutosDoMar) VerFrutosDoMar.IsVisible = true;
            if (u.Graos) VerGraos.IsVisible = true;
            if (u.Guloseimas) VerGuloseimas.IsVisible = true;
            if (u.Hortalica) VerHortalica.IsVisible = true;
            if (u.Iogurte) VerIogurte.IsVisible = true;
            if (u.Legumes) VerLegumes.IsVisible = true;
            if (u.Leite) VerLeite.IsVisible = true;
            if (u.Massas) VerMassas.IsVisible = true;
            if (u.Ovos) VerOvos.IsVisible = true;
            if (u.Paes) VerPaes.IsVisible = true;
            if (u.Peixes) VerPeixes.IsVisible = true;
            if (u.Suco) VerSuco.IsVisible = true;
        }

        void OnButtonVoltar(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
    }
}