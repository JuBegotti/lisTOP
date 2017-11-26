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
	public partial class PreferenciaView : ContentView
	{
		public PreferenciaView ()
		{
			InitializeComponent ();
		}

        public void setRestricao(Restricao r)
        {
            lblNomeRestricao.Text = r.NomeRestricao;
            switchRestricao.IsToggled = r.Ativo;
        }

        public Boolean isAtivo()
        {
            return this.switchRestricao.IsToggled;
        }
    }
}