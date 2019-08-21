using Everis.Models;
using Everis.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Everis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginModel Login { get; set; }
        public LoginView()
        {
            InitializeComponent();
            Login = new LoginModel
            {
                //Matricula = "Matrícula everis",
                //Email = "E-mail everis",
                //Senha = "Digita aqui a senha"
            };

            BindingContext = this;
        }
        async void Login_Clicked(object sender, EventArgs e)
        {
            if (Login.Matricula == "0001"
                 && Login.Email == "teste@teste.com"
                 && Login.Senha == "everis123")
            {
                await Navigation.PushAsync(new EventosPage());
            }
        }
    }
}