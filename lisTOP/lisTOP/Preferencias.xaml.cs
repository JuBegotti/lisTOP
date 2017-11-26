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
	public partial class Preferencias : ContentPage
	{
        private List<PreferenciaView> restricoes2 = new List<PreferenciaView>();
        private Boolean preferencia;

		public Preferencias (Boolean preferencia)
		{
			InitializeComponent ();
            txtRest.Text = (preferencia) ? "Preferências" : "Restrições";



            this.preferencia = preferencia;
            if (preferencia)
            {
                for (int i = 0; i < Gambs.preferencias.Count; i++)
                {
                    PreferenciaView pF = new PreferenciaView();
                    pF.setRestricao(Gambs.preferencias[i]);
                    restricoes2.Add(pF);
                    ContainerPreferencias.Children.Add(pF);
                }
            }
            else
            {
                for (int i = 0; i < Gambs.restricoes.Count; i++)
                {
                    PreferenciaView pF = new PreferenciaView();
                    pF.setRestricao(Gambs.restricoes[i]);
                    restricoes2.Add(pF);
                    ContainerPreferencias.Children.Add(pF);
                }
            }
            
		}

        void OnButtonSalvar(object sender, EventArgs args)
        {
            for(int i = 0; i < restricoes2.Count; i++)
            {
                if (preferencia)
                {
                    Gambs.preferencias[i].Ativo = restricoes2[i].isAtivo();
                }
                else
                {
                    Gambs.restricoes[i].Ativo = restricoes2[i].isAtivo();
                }
                
            }
            Navigation.PopModalAsync();
        }

    }
}