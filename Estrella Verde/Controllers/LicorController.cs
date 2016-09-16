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
    public class LicorController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Licor.Insert_Licor(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Licor.Modificar_Licor(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
               
                case "Eliminar":
                    {
                        Models.Licor.Elimina_Licor(Convert.ToInt32(form.Get("Id")));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "listar":
                    {

                        List<Models.Licor> LISTAVACIA = new List<Models.Licor>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Licor>>(HttpStatusCode.Created, Models.Licor.Todos_los_Licores());
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
