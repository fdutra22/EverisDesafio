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
    public class InscricaoViewModel : BaseViewModel
    {
        public EventoModel Evento { get; set; }
        public InscricaoModel Inscricao { get; set; }
        public Command LoadItemsCommand { get; set; }

        public InscricaoViewModel(EventoModel item)
        {
            Title = "Inscrição";
            Evento = item;



            Inscricao = new InscricaoModel();

            var existe = DataBase.db.Table<InscricaoModel>().Where( x => x.IdEvento == Evento.Id)?.FirstOrDefault();
            if(existe != null)
            {
                Inscricao = existe;
            }
            MessagingCenter.Subscribe<EventoDetailPage, InscricaoModel>(this, "AddInscricao", async (obj, inscr) =>
            {
                var newItem = inscr as InscricaoModel;
                inscr.IdEvento = Evento.Id;
                DataBase.db.Insert(inscr);
                //await DataStore.AddItemAsync(newItem);
            });
        }

       
    }
}