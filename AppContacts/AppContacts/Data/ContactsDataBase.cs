﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppContacts.Data
{
    using SQLite;
    using Model;
    using System.Threading.Tasks;
    using System.Collections.ObjectModel;
    using AppContacts.Helpers;
    using System.Linq;

    public class ContactsDataBase
    {
        #region Atributos

        private readonly SQLiteAsyncConnection dataBase;

        #endregion

        #region Constructor

        public ContactsDataBase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Contact>().Wait();
        }
        #endregion

        #region Metodos

        public async Task<List<Contact>> GetItemsAsync()
        {
            var data = await dataBase.Table<Contact>().ToListAsync();
            return data;
        }

        public Task<Contact> GetItemAsync(int id)
        {
            var data = dataBase.Table<Contact>()
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return data;
            
        }

        public Task<int> SaveItemAsync (Contact item)
        {
            if (item.Id != 0)
            {
                return dataBase.UpdateAsync(item);
            }
            else
            {
                return dataBase.InsertAsync(item);
            }

        }

        public Task<int> DeleteItemAsync(Contact item)
        {
            return dataBase.DeleteAsync(item);
        }

        public async Task <ObservableCollection <Grouping<string,Contact>>> GetAllGrouped()    
        {
            IList<Contact> contacts = await App.DataBase.GetItemsAsync();
            IEnumerable<Grouping<string, Contact>> sorted = new Grouping<string, Contact>[0];
                if (contacts != null)
                {
                    sorted =
                    from c in contacts
                    orderby c.Nombre
                    group c by c.Nombre[0].ToString()
                    into theGroup
                    select
                    new Grouping<string, Contact>(theGroup.Key, theGroup);
                }
            return new ObservableCollection<Grouping<string, Contact>>(sorted);
        }
        #endregion
    }
}
