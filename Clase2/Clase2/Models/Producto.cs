using System.ComponentModel.DataAnnotations;

namespace Clase2.Models
{
    public class Producto
    {
        #region Atributos
        private int id;
        private string descripcion;
        private string categoria;
        private float precio;
        #endregion

        #region Propiedades

        public int Id
        {
            set { id = value; }
            get { return id; }

        }
        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }
        public string Categoria
        {
            set { categoria = value; }
            get { return categoria; }
        }

       [DataType(DataType.Currency)]
        public float? Precio
        {
            get; set; 
            //set { precio = value; }
            //get { return precio; }
        }
        #endregion

        //NO VA
       // public List<Ciudad> listaCiudades = new List<Ciudad>();


    }

}
