using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Estrella_Verde.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Producto.Insert_Producto(Convert.ToInt32(form.Get("Id")),form.Get("Nombre"), Convert.ToInt32(form.Get("Precio")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Producto.Modificar_Producto(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"), Convert.ToInt32(form.Get("Precio")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Eliminar":
                    {
                        Models.Producto.Elimina_Producto(Convert.ToInt32(form.Get("Id")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }

                case "listar":
                    {

                        List<Models.Producto> LISTAVACIA = new List<Models.Producto>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Producto>>(HttpStatusCode.Created, Models.Producto.Todos_los_Productos());
                        return response;
                    }
                default:
                    {

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }

                    
            }
        }
    }
}
