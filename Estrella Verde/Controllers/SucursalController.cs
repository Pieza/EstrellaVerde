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
    public class SucursalController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Sucursal.Insert_Sucursal(Convert.ToInt32(form.Get("Id")), form.Get("Provincia"), form.Get("Distrito"), form.Get("Canton"), form.Get("Nombre"));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Sucursal.Modificar_Sucursal(Convert.ToInt32(form.Get("Id")), form.Get("Provincia"), form.Get("Distrito"), form.Get("Canton"), form.Get("Nombre"));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                
                case "Eliminar":
                    {
                        Models.Sucursal.Elimina_Sucursal(Convert.ToInt32(form.Get("Id")));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }

                case "listar":
                    {

                        List<Models.Sucursal> LISTAVACIA = new List<Models.Sucursal>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Sucursal>>(HttpStatusCode.Created, Models.Sucursal.Todos_los_Sucursales());
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
