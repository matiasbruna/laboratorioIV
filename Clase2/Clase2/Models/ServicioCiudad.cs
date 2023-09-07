using Clase2.Services;

namespace Clase2.Models
{
    public class ServicioCiudad :IServicioCiudad
    {
        public List<Ciudad> GetServicioCiudades()
        {
            var listaCiudad = new List<Ciudad>();

            var ciudad01 = new Ciudad()
            {
                ciudadId = 1,
                descripcion = "Ciudad 01"
            };
            var ciudad02 = new Ciudad()
            {
                ciudadId = 2,
                descripcion = "Ciudad 02"
            };
            var ciudad03 = new Ciudad()
            {
                ciudadId = 3,
                descripcion = "Ciudad 03"
            };
            var ciudad04 = new Ciudad()
            {
                ciudadId = 4,
                descripcion = "Ciudad 04"
            }
            ;

            listaCiudad.Add(ciudad01);
            listaCiudad.Add(ciudad02);
            listaCiudad.Add(ciudad03);
            listaCiudad.Add(ciudad04);

            return listaCiudad;

        }




    }
}
