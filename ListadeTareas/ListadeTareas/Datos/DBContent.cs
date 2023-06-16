using ListadeTareas.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ListadeTareas.Datos
{
    public class DBContent
    {
        public SQLiteAsyncConnection Connection { get; set; }
        public DBContent(string path) { 
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<TareaItems>().Wait();

        }

        public async Task<int> InsertItem(TareaItems items)
        {
            return await Connection.InsertAsync(items);
        }

        public async Task<List<TareaItems>> GetTareas()
        {
            return await Connection.Table<TareaItems>().ToListAsync();
        }

        public async Task<int> DeleteTarea(TareaItems items)
        {
            return await Connection.DeleteAsync(items);
        }

    }
}
