using GestorApp.Views;
using Xamarin.Forms;

namespace GestorApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NewClientPage), typeof(NewClientPage));
        }
    }
}