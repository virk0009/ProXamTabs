using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProXamTabsSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentView
	{
		public HomeView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}