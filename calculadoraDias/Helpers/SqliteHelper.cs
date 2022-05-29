using calculadoraDias.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace calculadoraDias.Helpers
{
    public class SqliteHelper
    {
        SQLiteAsyncConnection db;
        public SqliteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<diasModel>().Wait();
        }

        public Task<int> guardarDia(diasModel dia)
        {
            if (dia.iIdDia == 0)
            {
                return db.InsertAsync(dia);
            }
            else
            {
                return null;
            }
        }

        public Task<List<diasModel>> obtenerDias()
        {
            return db.Table<diasModel>().ToListAsync();
        }
    }
}
