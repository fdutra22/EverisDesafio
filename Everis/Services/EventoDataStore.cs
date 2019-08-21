using Everis.Data;
using Everis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Everis.Services
{
    public class EventoDataStore : IDataStore<EventoModel>
    {
        List<EventoModel> items;

        public EventoDataStore()
        { 
 
            items = DataBase.db.Table<EventoModel>().ToList();
        }

        public async Task<bool> AddItemAsync(EventoModel item)
        {
            try
            {
                DataBase.db.Insert(item);
            }catch (Exception ex)
            {
                Debug.Write(ex);
            }
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(EventoModel item)
        {
            var oldItem = items.Where((EventoModel arg) => arg.Evento == item.Evento).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((EventoModel arg) => arg.Evento == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<EventoModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Evento == id));
        }

        public async Task<IEnumerable<EventoModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}