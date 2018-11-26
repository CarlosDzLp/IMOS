
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IMOS.Views.Principal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : MasterDetailPage
	{
		public MasterPage ()
		{
			//
			InitializeComponent ();
		    App.MasterPageDetail = this;
		}
	}
}