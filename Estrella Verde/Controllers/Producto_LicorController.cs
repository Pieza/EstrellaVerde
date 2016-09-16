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
    public class Producto_LicorController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Producto_Licor.Insert_Producto_Licor(Convert.ToInt32(form.Get("Id_Producto")), Convert.ToInt32(form.Get("Id_Licor")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Producto_Licor.Modificar_Producto_Licor(Convert.ToInt32(form.Get("Id_Producto")), Convert.ToInt32(form.Get("Id_Licor")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Eliminar":
                    {
                        Models.Producto_Licor.Elimina_Producto_Licor(Convert.ToInt32(form.Get("Id_Producto")), Convert.ToInt32(form.Get("Id_Licor")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }

                case "listar":
                    {

                        List<Models.Producto_Licor> LISTAVACIA = new List<Models.Producto_Licor>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Producto_Licor>>(HttpStatusCode.Created, Models.Producto_Licor.Todos_los_Producto_Licor());
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
