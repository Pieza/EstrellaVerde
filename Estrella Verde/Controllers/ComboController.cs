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
    public class ComboController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Combo.Insert_Combo(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"), Convert.ToInt32(form.Get("Precio")));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Combo.Modificar_Combo(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"), Convert.ToInt32(form.Get("Precio")));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
              
                case "Eliminar":
                    {
                        Models.Combo.Elimina_Combo(Convert.ToInt32(form.Get("Id")));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "listar":
                    {

                        List<Models.Combo> LISTAVACIA = new List<Models.Combo>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Combo>>(HttpStatusCode.Created, Models.Combo.Todos_los_Combos());
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
