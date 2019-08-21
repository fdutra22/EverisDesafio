using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Everis.Models;
using Everis.Views;
using Everis.Data;

namespace Everis.ViewModels
{
    public class EventosViewModel : BaseViewModel
    {
        public ObservableCollection<EventoModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EventosViewModel()
        {
            Title = "Eventos Everis";
            Items = new ObservableCollection<EventoModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NovoEventoPage, EventoModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as EventoModel;
                Items.Add(newItem);
                DataBase.db.Insert(item);
                //await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}