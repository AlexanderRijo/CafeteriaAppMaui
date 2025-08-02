using SQLite;

namespace CafeteriaAppMaui.Model
{
    public class Productos
    {
        /*Definir la estructura de la base de datos (Simple)
            ID de producto
            Nombre del producto
            Precio
            Cantidad
            */
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int cantidad { get; set; }
    }
}
