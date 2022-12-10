using GestorApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GestorApp.Views
{
    public partial class ClientsPage : ContentPage
    {
        ClientsViewModel _viewModel;

        public ClientsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ClientsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}