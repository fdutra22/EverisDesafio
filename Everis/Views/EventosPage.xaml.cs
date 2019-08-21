using Everis.Models;
using Everis.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Everis.Views
{
  
    [DesignTimeVisible(false)]
    public partial class EventosPage : ContentPage
    {
        EventosViewModel viewModel;

        public EventosPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EventosViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as EventoModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new EventoDetailPage(new InscricaoViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void NovoEvento_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NovoEventoPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}