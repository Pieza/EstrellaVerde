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
    public class Sucursal_ComboController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Sucursal_Combo.Insert_Sucursal_Combo(Convert.ToInt32(form.Get("Id_Sucursal")), Convert.ToInt32(form.Get("Id_Combo")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Sucursal_Combo.Modificar_Sucursal_Combo(Convert.ToInt32(form.Get("Id_Sucursal")), Convert.ToInt32(form.Get("Id_Combo")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Eliminar":
                    {
                        Models.Sucursal_Combo.Elimina_Sucursal_Combo(Convert.ToInt32(form.Get("Id_Sucursal")), Convert.ToInt32(form.Get("Id_Combo")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }

                case "listar":
                    {

                        List<Models.Sucursal_Combo> LISTAVACIA = new List<Models.Sucursal_Combo>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Sucursal_Combo>>(HttpStatusCode.Created, Models.Sucursal_Combo.Todos_los_Sucursal_Combo());
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
