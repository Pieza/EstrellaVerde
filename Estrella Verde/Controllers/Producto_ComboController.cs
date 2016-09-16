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
    public class Producto_ComboController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Producto_Combo.Insert_Producto_Combo(Convert.ToInt32(form.Get("Id_Producto")), Convert.ToInt32(form.Get("Id_Combo")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Producto_Combo.Modificar_Producto_Combo(Convert.ToInt32(form.Get("Id_Producto")), Convert.ToInt32(form.Get("Id_Combo")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Eliminar":
                    {
                        Models.Producto_Combo.Elimina_Producto_Combo(Convert.ToInt32(form.Get("Id_Producto")), Convert.ToInt32(form.Get("Id_Combo")));

                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }

                case "listar":
                    {

                        List<Models.Producto_Combo> LISTAVACIA = new List<Models.Producto_Combo>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Producto_Combo>>(HttpStatusCode.Created, Models.Producto_Combo.Todos_los_Producto_Combo());
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

