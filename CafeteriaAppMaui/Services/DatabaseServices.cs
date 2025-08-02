using CafeteriaAppMaui.Model;
using SQLite;
using System.ComponentModel;

namespace CafeteriaAppMaui.Services
{
    public static class DatabaseServices
    {
        static SQLiteAsyncConnection db;

        public static async Task Init ()
        {
            if (db != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "cafeteria.db3");
            db = new SQLiteAsyncConnection(path);
            await db.CreateTableAsync<Productos>(); 
        }

        public static async Task<List<Productos>> GetProductosAsync()
        {
            await Init();
            return await db!.Table<Productos>().ToListAsync();
        }
        public static Task DeleteAllAsync()
        {
            return db!.DeleteAllAsync<Productos>();
        }
        public static async Task DeleteProductoAsync(int productoId)
        {
            await Init();
            await db!.DeleteAsync<Productos>(productoId);
        }

        public static async Task AddProductosAsync(Productos producto)
        {
            await Init();
            await db!.InsertAsync(producto);
        }
    }
}
