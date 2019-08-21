using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Everis.Models;
using Everis.ViewModels;

namespace Everis.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class EventoDetailPage : ContentPage
    {
        InscricaoViewModel viewModel;

        public EventoDetailPage(InscricaoViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public EventoDetailPage()
        {
            InitializeComponent();

            var item = new EventoModel();

            viewModel = new InscricaoViewModel(item);
            BindingContext = viewModel;
        }

        async void CadastrarInscricao_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddInscricao", this.viewModel.Inscricao);
            await Navigation.PopAsync();
        }
        void SwitchToggled(object sender, ToggledEventArgs e)
        {
            this.viewModel.Inscricao.Tema =   e.Value.ToString();
        }
    }
}