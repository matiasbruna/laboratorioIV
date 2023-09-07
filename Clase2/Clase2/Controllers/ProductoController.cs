using Clase2.Models;
using Clase2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase2.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;

        private readonly IServicioCiudad _servicioCiudad;

        List<int> lista = Enumerable.Range(0, 1000000).ToList();

        public ProductoController(ILogger<ProductoController> logger, IServicioCiudad servicioCiudad)
        {
            _logger = logger;
            _servicioCiudad = servicioCiudad;
        }

        // GET: Producto
        public ActionResult Index(int flag = 0)
        {

            ViewBag.Message = "Crear Producto";



            var listaProductos = new List<Producto>();

            var producto01 = new Producto();
            {
                producto01.Id = 1;
                producto01.Descripcion = "Prueba 01";
                producto01.Precio = (float?)2.80;
                producto01.Categoria = "Inicial";


            }
            var producto02 = new Producto();
            {
                producto02.Id = 2;
                producto02.Descripcion = "Prueba 02";
                producto02.Precio = (float?)5.90;
                producto02.Categoria = "Segundo";
            }

            var producto03 = new Producto();
            {
                producto03.Id = 3;
                producto03.Descripcion = "Prueba 03";
                producto03.Precio = (float?)4.10;
                producto03.Categoria = "Tercero";
            }
            listaProductos.Add(producto01);
            listaProductos.Add(producto02);
            listaProductos.Add(producto03);

            if (listaProductos == null)
            {
                return NotFound();
            }

            if (flag == 0)
            {
                return View(listaProductos);
            }
            else
            {
                var producto = listaProductos.Where(x => x.Id == flag).ToList();

                _logger.LogInformation("Info producto: {0} - {1}",
                    producto.Count() > 0 ? producto.FirstOrDefault().Id : "nulo",
                    producto != null && producto.Count() > 0 ? producto.FirstOrDefault().Descripcion : "nulo",
                    producto.Count() > 0 ? producto.FirstOrDefault().Precio : "nulo");



                List<int> values = new List<int>()
                {
                    9, 26, 77, 75, 73, 77,
                    59, 93, 9, 13, 64, 50,
                };


                //Numeros menores a 50
                IEnumerable<int> result = values.Where(x => x < 50);

                //Numeros pares
                IEnumerable<int> result2 = values.Where(x => x % 2 == 0);

                //Numeros impares
                IEnumerable<int> result3 = values.Where(x => x % 2 != 0);

                //Combinar
                var todosNumeros = result2.Concat(result3);

                //Usando filtros con LINQ Y QUERY expresion sobre un IEnumerable
                IEnumerable<int> menores50 =
                    from value in values
                    where value < 50
                    orderby value descending
                    select value;

                var ciudades = _servicioCiudad.GetServicioCiudades();

                //returnProducto
                return View(ciudades);
            }


        }


        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       [HttpGet]
       [Route("Producto/devolverListaJson/{id?}")]
        public ActionResult<List<Producto>>ListarTodosProductoJSON(int id=0)
        {
            var listaProductos = new List<Producto>();

            var producto01 = new Producto();
            {
                producto01.Id = 1;
                producto01.Descripcion = "Prueba 01";
                producto01.Precio = (float?)2.80;
                producto01.Categoria = "Inicial";
            }
            var producto02 = new Producto();
            {
                producto02.Id = 2;
                producto02.Descripcion = "Prueba 02";
                producto02.Precio = (float?)5.90;
                producto02.Categoria = "Segundo";
            }

            var producto03 = new Producto();
            {
                producto03.Id = 3;
                producto03.Descripcion = "Prueba 03";
                producto03.Precio = (float?)4.10;
                producto03.Categoria = "Tercero";
            }
            listaProductos.Add(producto01);
            listaProductos.Add(producto02);
            listaProductos.Add(producto03);

            if (listaProductos.Count == 0)
            {
                return NoContent();
            }

            return Json(listaProductos);
        }
    }
}
