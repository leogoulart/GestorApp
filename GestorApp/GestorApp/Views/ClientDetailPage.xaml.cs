using GestorApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetailPage : ContentPage
    {
        public ClientDetailPage()
        {
            InitializeComponent();
            BindingContext = new ClientDetailViewModel();
        }
    }
}