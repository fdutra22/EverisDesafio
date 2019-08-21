using Everis.Models;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Everis.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NovoEventoPage : ContentPage
    {
        public EventoModel Evento { get; set; }

        public NovoEventoPage()
        {
            InitializeComponent();

            Evento = new EventoModel();

            BindingContext = this;
        }

        async void CadastrarEvento_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Evento);
            await Navigation.PopModalAsync();
        }

        async void CancelarEvento_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}