using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieFinder.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingView : ContentPage
	{
		public LoadingView ()
		{
			InitializeComponent ();
            this.BindingContext = new ViewModels.LoadingViewModel();
        }
	}
}