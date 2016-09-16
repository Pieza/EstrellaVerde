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
    public class UsuarioController : ApiController
    {
        [HttpPost]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            switch (form.Get("op"))
            {
                case "Insertar":
                    {
                        Models.Usuario.Insert_Usuario(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"), Convert.ToInt32(form.Get("Tipo")), form.Get("Correo"), form.Get("Password"));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "Modificar":
                    {
                        Models.Usuario.Modificar_Usuario(Convert.ToInt32(form.Get("Id")), form.Get("Nombre"), Convert.ToInt32(form.Get("Tipo")), form.Get("Correo"), form.Get("Password"));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
              
                case "Eliminar":
                    {
                        Models.Usuario.Elimina_Usuario(Convert.ToInt32(form.Get("Id")));
                        HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, 1);
                        return Response;
                        break;
                    }
                case "listar":
                    {

                        List<Models.Usuario> LISTAVACIA = new List<Models.Usuario>();

                        HttpResponseMessage response = Request.CreateResponse<List<Models.Usuario>>(HttpStatusCode.Created, Models.Usuario.Todos_los_Usuarios());
                        return response;
                    }
                case "Login":
                    {
                       
                       HttpResponseMessage Response = Request.CreateResponse<int>(HttpStatusCode.Created, Models.Usuario.Login(Convert.ToInt32(form.Get("Id")), form.Get("Password")));
                        return Response;
                        break;
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
